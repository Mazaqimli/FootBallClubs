using FootBallClubs.ViewModels;
using FootBallClubs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.Commands.AdminWindowCommands
{
    public class OpenLeaguesCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenLeaguesCommand(AdminWindowViewModel viewModel)
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
            LeaguesControl control = new LeaguesControl();

            LeaguesViewModel leaguesViewModel = new LeaguesViewModel();
            leaguesViewModel.Load();

            control.DataContext = leaguesViewModel;

            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
