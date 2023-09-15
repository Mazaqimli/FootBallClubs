
using FootBallClubs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FootBallClubs.Commands.ConfigurationCommands
{
    public class CancelCommand : ICommand
    {
        private readonly ConfigurationViewModel _viewModel;

        public CancelCommand(ConfigurationViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.Window.Close();

            Application.Current.Shutdown();
        }
    }
}
