using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Awari.Persistence;

namespace Awari.Model
{
    public enum Player { RedPlayer, BluePlayer }
    public class AwariGameModel
    {
        #region Fields
        private int[] table;
        private int binNumber;
        private Player currentPlayer;
        private bool secondTurn;
        private Player lastPlayer;
        private IAwariDataAccess dataAccess;
        private bool isWon;
        private bool isDraw;
        private int moveCount;
        #endregion

        #region Properties
        public int[] Table { get { return table; } }
        public int BinNumber { get { return binNumber; } set { binNumber = value; } }
        public Player CurrentPlayer { get { return currentPlayer; } }
        public bool SecondTurn { get { return secondTurn; } }
        public bool Won { get { return isWon; } }
        public bool Draw { get { return isDraw; } }
        public int MoveCount { get { return moveCount; } }
        #endregion
        public AwariGameModel(int bins, IAwariDataAccess dataAcc)
        {
            dataAccess = dataAcc;
            binNumber = bins; 
        }

        #region Public Functions
        public void NewGame()
        {
            table = new int[binNumber + 2]; // a tálkák száma és a két gyűjtőtálka

            for (int i = 0; i < table.Length; i++) // minden tálkában 6 kavics van
            {
                table[i] = 6;
            }

            table[binNumber / 2] = 0; // a gyűjtőtálkákban, viszont kezdetkor 0 kavics van.
            table[binNumber + 1] = 0;

            currentPlayer = Player.RedPlayer;
            lastPlayer = Player.RedPlayer;

            isWon = false;
            isDraw = false;
            secondTurn = false;
            moveCount = 0;
        }

        public void StepGame(int binIndex)
        {
            int actualIndex = binIndex - 1; //x koordináta a rajzon
            if(currentPlayer == Player.BluePlayer)
            {
                actualIndex = binNumber - actualIndex; //az egy tömbben való ábrázolás miatt kell az átalakítás
                int i = actualIndex + 1;
                while(table[actualIndex] != 0 && i + 1 <= binNumber + 2) //ameddig nem nulla a mostani helyen a kavicsok száma és nem lépjük túl az indexeket
                {
                    if (table[actualIndex] == 1 && i > binNumber / 2 && table[i] == 0) //spec. eset: amikor az utolsó kavics egy üres saját tálkába esik
                    {
                        table[actualIndex]--;
                        table[binNumber + 1] = table[binNumber + 1] + 1 + table[i - 2 * (i - (binNumber / 2))];
                        table[i - 2 * (i - (binNumber / 2))] = 0;
                        i++;
                    }

                    else if (table[actualIndex] == 1 && i == binNumber + 1 && !secondTurn) //spec. eset: amikor az utolsó kavics a gyűjtőtálkába esik
                    {
                        table[actualIndex]--;
                        table[i]++;
                        secondTurn = true;
                        i++;
                    }

                    else
                    {
                        if (i != actualIndex)
                        {
                            table[i]++;
                            table[actualIndex]--;
                        }

                        i++;

                        if (i + 1 > binNumber + 2)
                        {
                            i = 0;
                        }
                    }
                }
            }

            else
            {
                int i = actualIndex + 1;
                while (table[actualIndex] != 0 && i + 1 <= binNumber + 2)
                {
                    if (table[actualIndex] == 1 && i <= binNumber / 2 && table[i] == 0)
                    {
                        table[actualIndex]--;
                        table[binNumber / 2] = table[binNumber / 2] + 1 + table[i + 2 * ((binNumber / 2) - i)];
                        table[i + 2 * ((binNumber / 2) - i)] = 0;
                        ++i;
                    }

                    else if (table[actualIndex] == 1 && i == binNumber / 2 && !secondTurn)
                    {
                        table[actualIndex]--;
                        table[i]++;
                        secondTurn = true;
                        i++;
                    }

                    else
                    {
                        if (i != actualIndex)
                        {
                            table[i]++;
                            table[actualIndex]--;
                        }

                        i++;

                        if (i + 1 > binNumber + 2)
                        {
                            i = 0;
                        }
                    }
                }
            }

            ++moveCount;

            if (lastPlayer == currentPlayer)
                secondTurn = false;

            OnGameStep();
            lastPlayer = currentPlayer;
            if(!secondTurn) currentPlayer = (Player)(((int)currentPlayer + 1) % 2);

            if(checkGameOver())
            {
                if (table[binNumber + 1] > table[binNumber / 2])
                    isWon = true;
                else if (table[binNumber + 1] < table[binNumber / 2])
                    isWon = true;
                else
                    isDraw = false;
                OnGameOver();
            }
        }

        public async Task LoadGameAsync(String path)
        {
            if (dataAccess == null)
                throw new InvalidOperationException("No data access is provided!");

            int cp = 0;
            int lp = 0;
            (binNumber, cp , secondTurn, lp, table) = await dataAccess.LoadAsync(path);
            currentPlayer = (Player)cp;
            lastPlayer = (Player)lp;
        }
        public async Task SaveGameAsync(String path)
        {
            if (dataAccess == null)
                throw new InvalidOperationException("No data access is provided!");

            int st = 0;
            if (secondTurn) st = 1;

            await dataAccess.SaveAsync(path, table, (int)currentPlayer, st, (int)lastPlayer);
        }
        #endregion

        #region Private Functions
        private bool checkGameOver()
        {
            bool end = true;
            for (int i = 0; i < binNumber / 2 && end; ++i)
            {
                if (table[i] > 0)
                    end = false;
            }

            if (end)
                return end;

            end = true;
            for(int i = 0; i < binNumber / 2 && end; ++i)
            {
                if (table[binNumber - i] > 0)
                    end = false;
            }

            return end;
        }

        #endregion

        #region Events
        public event EventHandler<EventArgs> GameStep;

        public event EventHandler<AwariEventArgs> GameOver;
        #endregion

        #region EventHandlers
        private void OnGameStep()
        {
            if(GameStep != null)
            {
                GameStep(this, new EventArgs());
            }
        }
        private void OnGameOver()
        {
            if(GameOver != null)
            {
                GameOver(this, new AwariEventArgs(table[binNumber+1], table[binNumber/2]));
            }
        }

        #endregion
    }
}
