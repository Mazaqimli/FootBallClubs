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
    public class AddPlayerToListCommand : ICommand
    {
        private readonly SaveClubViewModel _viewModel;

        public AddPlayerToListCommand(SaveClubViewModel viewModel)
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
            PlayerModel player = _viewModel.Players[_viewModel.SelectedPlayerToAdd];

            _viewModel.Players.Remove(player);
            _viewModel.SelectedPlayers.Add(player);
        }
    }
}
