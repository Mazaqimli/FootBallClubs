using FootBallClubs.Models;
using FootBallClubs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FootBallClubs.Commands.PlayersCommands
{
    public class OpenDeletePlayerCommand : ICommand
    {
        private readonly PlayersViewModel _viewModel;

        public OpenDeletePlayerCommand(PlayersViewModel viewModel)
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
            int index = _viewModel.SelectedPlayerIndex;

            PlayerModel model = _viewModel.PlayerModels[index];

            MessageBoxResult result = MessageBox.Show($"Are you sure to delete {model.FullName}?", "Delete player", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }
            ApplicationContext.DB.PlayerRepository.Delete(model.Id);
            _viewModel.PlayerModels.Remove(model);
        }
    }
}
