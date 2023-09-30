using FootBallClubs.ViewModels;
using FootBallClubs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;

namespace FootBallClubs.Commands.AdminWindowCommands
{
    public class OpenPlayersCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenPlayersCommand(AdminWindowViewModel viewModel)
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
            PlayersControl control = new PlayersControl();

            PlayersViewModel playersViewModel = new PlayersViewModel();
            playersViewModel.Load();

            control.DataContext = playersViewModel;

            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
