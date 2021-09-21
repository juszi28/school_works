using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zh_i7p4uq.Model;
using zh_i7p4uq.Persistence;

namespace zh_i7p4uq
{
    public partial class MainWindow : Form
    {
        GameModel model;
        Timer timer;
        IPersistence persistence;

        SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            persistence = new FilePersistence();

            model = new GameModel(persistence);
            model.GameOver += View_GameOver;
            model.Refresh += View_Refresh;

            model.NewGame();
            GenerateTable();

            newGameMenuItem.Click += newGame;
            saveGameMenuItem.Click += View_SaveGame;
            loadGameMenuItem.Click += View_LoadGame;
            pauseMenuItem.Click += Pause;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            StatusLabel.Text = "Vár élete: 3" + " | Eltelt idő: 0" + " | Katonák: 2";
        }

        private void Pause(object sender, EventArgs e)
        {
            Timer_PauseNPlay();
            model.PauseNPlay();
        }

        private void GenerateTable()
        {
            for (int i = 0; i < model.Size; i++)
            {
                for (int j = 0; j < model.Size; j++)
                {
                    Button button = new Button();
                    button.TabIndex = i * model.Size + j;
                    button.BackColor = Color.White;
                    button.Dock = DockStyle.Fill;
                    button.Click += Button_Click;
                    tableLayoutPanel1.Controls.Add(button, i, j);
                }
            }
        }

        private void Timer_PauseNPlay()
        {
            if (timer.Enabled)
            {
                timer.Stop();
                pauseMenuItem.Text = "Play";
            }
            else
            {
                timer.Start();
                pauseMenuItem.Text = "Pause";
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int buttonIndex = (sender as Button).TabIndex;

            int x = buttonIndex / model.Size;
            int y = buttonIndex % model.Size;

            model.PlaceSoldier(x, y);
        }

        private void View_Refresh(object sender, RefreshArgs e)
        {
            for (int i = 0; i < model.Size; i++)
            {
                for (int j = 0; j < model.Size; j++)
                {
                    if(e.Map[i,j] == 0)
                        tableLayoutPanel1.Controls[i * model.Size + j].BackColor = Color.White;
                    else if(e.Map[i,j] == 1)
                        tableLayoutPanel1.Controls[i * model.Size + j].BackColor = Color.Blue;
                    else
                        tableLayoutPanel1.Controls[i * model.Size + j].BackColor = Color.Red;
                }
            }

            StatusLabel.Text = "Vár élete: " + e.CastleHP + " | Eltelt idő: " + e.ElapsedTime + " | Katonák: " + e.SoldierCount;
        }

        private void View_GameOver(object sender, EventArgs e)
        {
            timer.Stop();
            MessageBox.Show("Game Over!");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            model.Step();
        }

        private void newGame(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            model.NewGame();
            GenerateTable();
            if (!timer.Enabled)
                timer.Start();
        }

        private async void View_LoadGame(object sender, EventArgs e)
        {
            if (openFileDialog == null)
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Load Game";
            }

            timer.Stop();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await model.LoadGameAsync(openFileDialog.FileName);

                }
                catch
                {
                    MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    model.NewGame();
                }
            }

            timer.Start();
        }

        private async void View_SaveGame(object sender, EventArgs e)
        {
            if (saveFileDialog == null)
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save Game";
            }

            timer.Stop();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await model.SaveGameAsync(saveFileDialog.FileName);

                }
                catch
                {
                    MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            timer.Start();
        }
    }
}
