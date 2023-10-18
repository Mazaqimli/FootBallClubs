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
    public class OpenDeleteClubCommand : ICommand
    {
        private readonly ClubsViewModel _viewModel;

        public OpenDeleteClubCommand(ClubsViewModel viewModel)
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
            int index = _viewModel.SelectedClubIndex;

            ClubModel model = _viewModel.ClubModels[index];

            MessageBoxResult result = MessageBox.Show($"Are you sure to delete {model.Name}?", "Delete player", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }
            ApplicationContext.DB.ClubRepository.Delete(model.Id);
            _viewModel.ClubModels.Remove(model);
        }
    }
}
