using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Awari.Model;

namespace Awari.ViewModel
{
    public class AwariViewModel : ViewModelBase
    {
        #region Fields
        private AwariGameModel model;
        private int height;
        private int width;
        #endregion

        #region Properties
        public DelegateCommand NewSmallGameCommand { get; private set; }
        public DelegateCommand NewMediumGameCommand { get; private set; }
        public DelegateCommand NewLargeGameCommand { get; private set; }
        public DelegateCommand SaveGameCommand { get; private set; }
        public DelegateCommand LoadGameCommand { get; private set; }
        public ObservableCollection<AwariField> Fields { get; set; }
        public int Height 
        { 
            get { return height; } 
            set
            {
                height = value;
                OnPropertyChanged();
            }
        }
        public int Width 
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged();
            }
        }

        #endregion
        public AwariViewModel(AwariGameModel m)
        {
            model = m;
            model.GameStep += new EventHandler<EventArgs>(Model_GameStep);
            model.GameOver += new EventHandler<AwariEventArgs>(Model_GameOver);
            model.GameCreated += new EventHandler(Model_GameCreated);
            model.GameLoaded += new EventHandler(Model_GameLoaded);

            NewSmallGameCommand = new DelegateCommand(param => OnNewSmallGame());
            NewMediumGameCommand = new DelegateCommand(param => OnNewMediumGame());
            NewLargeGameCommand = new DelegateCommand(param => OnNewLargeGame());
            SaveGameCommand = new DelegateCommand(param => OnSaveGame());
            LoadGameCommand = new DelegateCommand(param => OnLoadGame());

            Fields = new ObservableCollection<AwariField>();

            SetupTable();

            Width = 6 * 50 + 4 * 20;
            Height = 3 * 50 + 4 * 20;

            model.NewGame(8);
        }

        #region Private Functions
        private void RefreshTable()
        {
            foreach (AwariField field in Fields)
            {
                if (field.X == (model.BinNumber / 2) + 1 && field.Y == 1)
                {
                    field.Text = model.Table[model.BinNumber / 2].ToString();
                }

                else if (field.X == 0 && field.Y == 1)
                {
                    field.Text = model.Table[model.BinNumber + 1].ToString();
                }

                else if (field.Y == 2)
                {
                    field.Text = model.Table[field.X-1].ToString();
                }

                else
                {
                    field.Text = model.Table[model.BinNumber + 1 - field.X].ToString();
                }
            }
        }

        private void SetupTable()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < model.BinNumber / 2 + 2; ++j)
                {
                    if ((i == 0 || i == 2) && j > 0 && j < model.BinNumber / 2 + 1)
                    {
                        Fields.Add(new AwariField
                        {
                            IsEnabled = (i == 0) ? false : true,
                            Text = "6",
                            X = j,
                            Y = i,
                            PosX = 20 + 50 * j,
                            PosY = 20 + 50 * i,
                            Color = (i == 0) ? Brushes.Blue : Brushes.Red,
                            StepCommand = new DelegateCommand(param => StepGame(Convert.ToInt32(param))),
                            Size = (model.BinNumber / 2) + 2,
                            Number = (i == 2) ? j : (model.BinNumber + 1 - j)
                        });
                    }

                    if (i == 1 && (j == 0 || j == model.BinNumber / 2 + 1))
                    {
                        Fields.Add(new AwariField
                        {
                            IsEnabled = false,
                            Text = "0",
                            X = j,
                            Y = i,
                            PosX = 20 + 50 * j,
                            PosY = 20 + 50 * i,
                            Color = (j == 0) ? Brushes.Blue : Brushes.Red,
                            StepCommand = null,
                            Size = (model.BinNumber / 2) + 2,
                            Number = (j == 0) ? model.BinNumber + 1 : model.BinNumber / 2
                        });
                    }
                }
            }
        }

        private void StepGame(int index)
        {
            model.StepGame(index);
        }

        private void ChangeButtonDisables()
        {
            for(int i = 0; i < Fields.Count; ++i)
            {
                if(Fields[i].Y == 0 || Fields[i].Y == 2)
                {
                    Fields[i].IsEnabled = (Fields[i].IsEnabled == true) ? false : true;
                }
            }    
        }

        private void Model_GameOver(object sender, AwariEventArgs e)
        {
            foreach (AwariField field in Fields) //gombok letiltása
            {
                field.IsEnabled = false;
            }
        }

        private void Model_GameCreated(object sender, EventArgs e)
        {
            Fields.Clear();
            SetupTable();

            RefreshTable();
        }

        private void Model_GameStep(object sender, EventArgs e)
        {
            RefreshTable();

            if(!model.SecondTurn)
            {
                ChangeButtonDisables();
            }
        }
        private void Model_GameLoaded(object sender, EventArgs e)
        {
            Fields.Clear();
            SetupTable();

            RefreshTable();
        }
        #endregion

        #region Events

        public event EventHandler NewSmallGame;

        public event EventHandler NewMediumGame;

        public event EventHandler NewLargeGame;

        public event EventHandler LoadGame;

        public event EventHandler SaveGame;
        private void OnLoadGame()
        {
            if (LoadGame != null)
                LoadGame(this, EventArgs.Empty);
        }

        private void OnSaveGame()
        {
            if (SaveGame != null)
                SaveGame(this, EventArgs.Empty);
        }

        private void OnNewSmallGame()
        {
            if (LoadGame != null)
                NewSmallGame(this, EventArgs.Empty);
        }

        private void OnNewMediumGame()
        {
            if (LoadGame != null)
                NewMediumGame(this, EventArgs.Empty);
        }

        private void OnNewLargeGame()
        {
            if (LoadGame != null)
                NewLargeGame(this, EventArgs.Empty);
        }
        #endregion
    }
}
