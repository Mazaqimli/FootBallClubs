using FootBallClubs.Models;
using FootBallClubs.Settings;
using FootBallClubs.ViewModels;
using FootBallClubs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FootBallClubs.Commands.ConfigurationCommands
{
    public class SaveCommand : ICommand
    {
        private readonly ConfigurationViewModel _viewModel;

        public SaveCommand(ConfigurationViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AppSettingsHelper helper = new AppSettingsHelper(ApplicationContext.ConfigurationPath);
            PasswordBox passwordBox = (PasswordBox)parameter;


            ConfigurationModel config = _viewModel.Configuration;    

            AppSettings appSettings = new AppSettings
            {
                WindowsAuthentication = config.WindowsAuthentication,
                DbHost = config.DbHost,
                DbName = config.DbName,
                DbPort = config.DbPort,
                DbType = config.DbType

                
            };

            if(config.WindowsAuthentication == false)
            {
                appSettings.Username = config.Username;
                appSettings.Password = passwordBox.Password;
            }

            helper.SaveSettings(appSettings);

            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            _viewModel.Window.Close();

        }
    }
}
