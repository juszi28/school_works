using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zh_i7p4uq.Persistence;

namespace zh_i7p4uq.Model
{
    class GameModel
    {
        private IPersistence dataAccess;
        private int[,] map;
        private int castleHP;
        private Random random;
        private int enemyHitCount;
        private int soldierCount;
        private int elapsedTime;
        private List<(int, int)> enemies;
        private bool timerState;
        
        public int Size { get; set; }
        public int Soldier { get { return soldierCount; } }

        public event EventHandler<RefreshArgs> Refresh;
        public event EventHandler GameOver;
        public GameModel(IPersistence persistence)
        {
            dataAccess = persistence;
            random = new Random();
            enemies = new List<(int, int)>();
        }

        public void NewGame()
        {
            enemies.Clear();
            Size = 10;
            map = new int[Size,Size];

            soldierCount = 2;
            enemyHitCount = 0;
            castleHP = 3;
            elapsedTime = 0;

            for(int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; j++)
                {
                    map[i, j] = 0;
                }
            }

            timerState = true;
        }

        public void Step() //a játék folytatása
        {
            //eddigi ellenfelek mozgatása
            for (int i = 0; i < enemies.Count; i++)
            {
                int prevEnemiesCount = enemies.Count;

                map[enemies[i].Item1, enemies[i].Item2] = 0;
                int x = enemies[i].Item1; x--;
                if (x == -1)
                {
                    castleHP--;
                    enemies.Remove(enemies[i]);
                }

                else
                {
                    (int, int) newCoords = (x, enemies[i].Item2);
                    enemies.Remove(enemies[i]);
                    enemies.Insert(i, (newCoords));
                    //csekkolni az ütközéseket
                    if (map[enemies[i].Item1, enemies[i].Item2] == 1)
                    {
                        map[enemies[i].Item1, enemies[i].Item2] = 0;
                        ++enemyHitCount;
                        enemies.Remove(enemies[i]);
                    }
                    else if (inMap(enemies[i].Item1, enemies[i].Item2 - 1) && map[enemies[i].Item1, enemies[i].Item2 - 1] == 1)
                    {
                        map[enemies[i].Item1, enemies[i].Item2] = 0;
                        ++enemyHitCount;
                        enemies.Remove(enemies[i]);
                    }
                    else if (inMap(enemies[i].Item1, enemies[i].Item2 + 1) && map[enemies[i].Item1 + 1, enemies[i].Item2 + 1] == 1)
                    {
                        map[enemies[i].Item1, enemies[i].Item2] = 0;
                        ++enemyHitCount;
                        enemies.Remove(enemies[i]);
                    }
                    else
                        map[enemies[i].Item1, enemies[i].Item2] = 2;

                }

                if (prevEnemiesCount > enemies.Count)
                {
                    i = i - (prevEnemiesCount - enemies.Count);
                }

                if (enemyHitCount >= 3)
                {
                    ++soldierCount;
                    enemyHitCount -= 3;
                }
            }

            //új ellenfelek spawnolása
            int enemyCount = random.Next(0, 3);

            for (int i = 0; i < enemyCount; ++i)
            {
                (int, int) enemyCoord = GenerateEnemy();
                map[enemyCoord.Item1, enemyCoord.Item2] = 2;
                enemies.Add(enemyCoord);
            }

            ++elapsedTime;
            OnRefresh();

            if (castleHP <= 0)
                OnGameOver();
        }

        public void PauseNPlay()
        {
            timerState = timerState ? false : true;
        }

        private void OnGameOver()
        {
            GameOver?.Invoke(this, new EventArgs());
        }

        public void PlaceSoldier(int x, int y)
        {
            if (timerState)
            {
                if (soldierCount > 0 && map[x, y] == 0)
                {
                    --soldierCount;
                    map[x, y] = 1; // 1 a katona, 2 az ellenség
                    OnRefresh();
                }
                else
                    return;
            }
        }

        public async Task LoadGameAsync(string path)
        {
            if (dataAccess == null)
                throw new InvalidOperationException("No data access is provided!");

            //betöltés
            State table = await dataAccess.LoadAsync(path);
            castleHP = table.CastleHP;
            elapsedTime = table.ElapsedTime;
            enemyHitCount = table.EnemyHitCount;
            soldierCount = table.SoldierCount;
            enemies = table.Enemies;
            map = table.Map;
            OnRefresh();
        }

        public async Task SaveGameAsync(string path)
        {
            if (dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            State table = new State(castleHP, elapsedTime, enemyHitCount, soldierCount, enemies, map);

            await dataAccess.SaveAsync(path, table);
        }

        private (int, int) GenerateEnemy()
        {
            int y = random.Next(0, Size);

            while (map[Size-1, y] != 0)
            {
                y = random.Next(0, Size);
            }

            return (Size-1, y);
        }

        private bool inMap(int x, int y)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size;
        }
        private void OnRefresh()
        {
            Refresh?.Invoke(this, new RefreshArgs(castleHP, soldierCount, map, elapsedTime));
        }
    }
}
