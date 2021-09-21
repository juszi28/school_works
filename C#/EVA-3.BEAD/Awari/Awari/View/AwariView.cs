using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awari.Model;
using Awari.View;
using Awari.Persistence;

namespace Awari
{
    public partial class AwariView : Form
    {
        #region Fields
        private IAwariDataAccess dataAccess;
        private AwariGameModel model;
        private Button[,] buttonGrid;
        #endregion
        public AwariView()
        {
            InitializeComponent();
        }

        #region Private Functions
        private void ButtonGrid_MouseClick(object sender, MouseEventArgs e)
        {
            int binIndex = ((sender as Button).Location.X - 20) / 50;

            model.StepGame(binIndex);
        }
        private void GenerateTable()
        {
            Controls.Clear();
            Controls.Add(menuStrip1);
            buttonGrid = new Button[3, model.BinNumber/2 + 2];
            for(int i = 0; i < 3; ++i)
                for(int j = 0; j < model.BinNumber / 2 + 2; ++j)
                {
                    if((i == 0 || i == 2) && j > 0 && j < model.BinNumber / 2 + 1)
                    {
                        buttonGrid[i, j] = new Button();
                        buttonGrid[i, j].Location = new Point(20 + 50 * j, 20 + 50 * i);
                        buttonGrid[i, j].Size = new Size(40, 40);
                        buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                        buttonGrid[i, j].Text = "6";
                        buttonGrid[i, j].Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
                        buttonGrid[i, j].ForeColor = Color.White;
                        buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);

                        if (i == 0)
                        {
                            buttonGrid[i, j].BackColor = Color.Blue;
                            buttonGrid[i, j].Enabled = false;
                        }
                        else
                            buttonGrid[i, j].BackColor = Color.Red;

                        Controls.Add(buttonGrid[i, j]);
                    }

                    if(i == 1 && (j == 0 || j == model.BinNumber / 2 + 1))
                    {
                        buttonGrid[i, j] = new Button();
                        buttonGrid[i, j].Location = new Point(20 + 50 * j, 20 + 50 * i);
                        buttonGrid[i, j].Size = new Size(50, 50);
                        buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                        buttonGrid[i, j].Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
                        buttonGrid[i, j].ForeColor = Color.White;
                        buttonGrid[i, j].Enabled = false;
                        if (j == 0)
                            buttonGrid[i, j].BackColor = Color.Blue;
                        else
                            buttonGrid[i, j].BackColor = Color.Red;

                        Controls.Add(buttonGrid[i, j]);
                    }
                }
        }

        private void AwariView_Load(object sender, EventArgs e)
        {
            dataAccess = new AwariFileDataAccess();
            model = new AwariGameModel(8, dataAccess);
            model.GameStep += new EventHandler<EventArgs>(GameAdvance);
            model.GameOver += new EventHandler<AwariEventArgs>(GameOver);

            GenerateTable();
            this.Size = new Size(6 * 50 + 4 * 20, 3 * 50 + 4 * 20);
            this.MinimumSize = new Size(6 * 50 + 4 * 20, 3 * 50 + 4 * 20);
            this.MaximumSize = new Size(6 * 50 + 4 * 20, 3 * 50 + 4 * 20);
            model.NewGame();

            newGameMenuItem.Click += new EventHandler(newGameMenuItem_Click);
            saveGameMenuItem.Click += new EventHandler(saveGameMenuItem_Click);
            loadGameMenuItem.Click += new EventHandler(loadGameMenuItem_Click);
        }

        private void SetupTable()
        {
            for (int i = 0; i < model.Table.Length; ++i)
            {
                if (i == model.BinNumber / 2)
                {
                    buttonGrid[1, (model.BinNumber / 2) + 1].Text = model.Table[i].ToString();
                }

                else if (i == model.BinNumber + 1)
                {
                    buttonGrid[1, 0].Text = model.Table[i].ToString();
                }

                else if (i < model.BinNumber / 2)
                {
                    buttonGrid[2, i + 1].Text = model.Table[i].ToString();
                }

                else
                {
                    buttonGrid[0, (model.BinNumber / 2 + 1) - (i - (model.BinNumber / 2))].Text = model.Table[i].ToString();
                }
            }
        }

        private void ChangeButtonDisables()
        {
            for (int i = 0; i < model.BinNumber / 2; ++i)
            {
                buttonGrid[0, i + 1].Enabled = (buttonGrid[0, i + 1].Enabled == false) ? true : false;
                buttonGrid[2, i + 1].Enabled = (buttonGrid[2, i + 1].Enabled == false) ? true : false;
            }
        }
        #endregion

        #region GameEvents
        private void GameAdvance(object sender, EventArgs e)
        {
            SetupTable();

            if (!model.SecondTurn)
            {
                ChangeButtonDisables();
            }
        }
        private void GameOver(object sender, AwariEventArgs e)
        {
            foreach(Button button in buttonGrid)
            {
                if(button != null)
                    button.Enabled = false;
            }

            if(e.BluePot > e.RedPot)
            {
                MessageBox.Show("The blue player has won!");
            }
            else if(e.BluePot < e.RedPot)
            {
                MessageBox.Show("The red player has won!");
            }
            else
            {
                MessageBox.Show("It is a draw!");
            }
        }

        #endregion

        #region MenuEvents
        private void newGameMenuItem_Click(object sender, EventArgs e)
        {
            NewGameForm form = new NewGameForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                model.BinNumber = form.bins;
                model.NewGame();
                GenerateTable();
                this.Size = new Size((form.bins / 2 + 2)  * 50 + 4 * 20, 3 * 50 + 4 * 20);
                this.MinimumSize = new Size((form.bins / 2 + 2) * 50 + 4 * 20, 3 * 50 + 4 * 20);
                this.MaximumSize = new Size((form.bins / 2 + 2) * 50 + 4 * 20, 3 * 50 + 4 * 20);
            }
        }
        private async void saveGameMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save game";
            saveFileDialog.Filter = "Awari games(*.awrg)|*.awrg";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await model.SaveGameAsync(saveFileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Couldn't save the game!" + Environment.NewLine + "Bad path or can't write in that directory!", "Error!" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void loadGameMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load game";
            openFileDialog.Filter = "Awari games(*.awrg)|*.awrg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await model.LoadGameAsync(openFileDialog.FileName);
                }
                catch(AwariDataException)
                {
                    MessageBox.Show("Couldn't load the game!" + Environment.NewLine + "Bad path or file format!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    model.NewGame();
                }

                GenerateTable();
                SetupTable();
                this.Size = new Size((model.BinNumber / 2 + 2) * 50 + 4 * 20, 3 * 50 + 4 * 20);
                this.MinimumSize = new Size((model.BinNumber / 2 + 2) * 50 + 4 * 20, 3 * 50 + 4 * 20);
                this.MaximumSize = new Size((model.BinNumber / 2 + 2) * 50 + 4 * 20, 3 * 50 + 4 * 20);
            }
        }

        #endregion
    }
}
