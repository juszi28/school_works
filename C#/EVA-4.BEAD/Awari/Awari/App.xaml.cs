using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Awari.View;
using Awari.Model;
using Awari.Persistence;
using Awari.ViewModel;
using Microsoft.Win32;

namespace Awari
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields
        private MainWindow mainWindow;
        private AwariGameModel model;
        private AwariViewModel viewModel;
        private IAwariDataAccess dataAccess;
        #endregion
        public App()
        {
            Startup += App_Startup;
        }

        #region Functions
        private void App_Startup(object sender, StartupEventArgs e)
        {
            model = new AwariGameModel(8, new AwariFileDataAccess());
            model.GameOver += new EventHandler<AwariEventArgs>(Model_GameOver);

            viewModel = new AwariViewModel(model);
            viewModel.NewSmallGame += new EventHandler(ViewModel_NewSmallGame);
            viewModel.NewMediumGame += new EventHandler(ViewModel_NewMediumGame);
            viewModel.NewLargeGame += new EventHandler(ViewModel_NewLargeGame);
            viewModel.SaveGame += new EventHandler(ViewModel_SaveGame);
            viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);

            mainWindow = new MainWindow();
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }

        private void Model_GameOver(object sender, AwariEventArgs e)
        {
            if (e.BluePot > e.RedPot)
            {
                MessageBox.Show("The blue player has won!");
            }
            else if (e.BluePot < e.RedPot)
            {
                MessageBox.Show("The red player has won!");
            }
            else
            {
                MessageBox.Show("It is a draw!");
            }
        }

        private void ViewModel_NewSmallGame(object sender, EventArgs e)
        {
            model.NewGame(4);
            viewModel.Width = (model.BinNumber / 2 + 2) * 50 + 4 * 20;
            viewModel.Height = 3 * 50 + 4 * 20;
        }
        private void ViewModel_NewMediumGame(object sender, EventArgs e)
        {
            model.NewGame(8);
            viewModel.Width = (model.BinNumber / 2 + 2) * 50 + 4 * 20;
            viewModel.Height = 3 * 50 + 4 * 20;
        }

        private void ViewModel_NewLargeGame(object sender, EventArgs e)
        {
            model.NewGame(12);
            viewModel.Width = (model.BinNumber / 2 + 2) * 50 + 4 * 20;
            viewModel.Height = 3 * 50 + 4 * 20;
        }
        #endregion

        #region Persistence Functions
        private async void ViewModel_SaveGame(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save game";
                saveFileDialog.Filter = "Awari games(*.awrg)|*.awrg";

                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        await model.SaveGameAsync(saveFileDialog.FileName);
                    }
                    catch (AwariDataException)
                    {
                        MessageBox.Show("Couldn't save the game!" + Environment.NewLine + "Bad path or can't write in that directory!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Couldn't save the game!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ViewModel_LoadGame(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Load game";
                openFileDialog.Filter = "Awari games(*.awrg)|*.awrg";

                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        await model.LoadGameAsync(openFileDialog.FileName);
                    }
                    catch (AwariDataException)
                    {
                        MessageBox.Show("Couldn't load the game!" + Environment.NewLine + "Bad path or file format!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        model.NewGame(model.BinNumber);
                    }

                    viewModel.Width = (model.BinNumber / 2 + 2) * 50 + 4 * 20;
                    viewModel.Height = 3 * 50 + 4 * 20;
                    
                }
            }
            catch
            {
                MessageBox.Show("Couldn't load the game!" + Environment.NewLine + "Bad path or file format!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
