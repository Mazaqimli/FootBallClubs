using FootBallClubs.Models;
using FootBallClubs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FootBallClubs.Commands.LeagueCommands
{
    public class OpenDeleteLeagueCommand : ICommand
    {
        private readonly LeaguesViewModel _viewModel;

        public OpenDeleteLeagueCommand(LeaguesViewModel viewModel)
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
            int index = _viewModel.SelectedLeagueIndex;

            LeagueModel model = _viewModel.LeagueModels[index];

            MessageBoxResult result = MessageBox.Show($"Are you sure to delete {model.Name}?", "Delete league", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }
            ApplicationContext.DB.LeagueRepository.Delete(model.Id);
            _viewModel.LeagueModels.Remove(model);
        }
    }
}
