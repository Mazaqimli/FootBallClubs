using FootBallClubs.Models;
using FootBallClubs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.Commands.ClubCommands
{
    public class DeletePlayerFromListCommand : ICommand
    {
        private readonly SaveClubViewModel _viewModel;

        public DeletePlayerFromListCommand(SaveClubViewModel viewModel)
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
            PlayerModel playerToDelete = _viewModel.SelectedPlayers[_viewModel.SelectedPlayerToDelete];

            _viewModel.SelectedPlayers.Remove(playerToDelete);
            _viewModel.Players.Add(playerToDelete);
        }
    }
}
