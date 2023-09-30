using FootBallClubs.ViewModels;
using FootBallClubs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.Commands.ClubCommands
{
    public class OpenSaveClubCommand : ICommand
    {
        private readonly ClubsViewModel _viewModel;

        public OpenSaveClubCommand(ClubsViewModel viewModel)
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
            SaveClubWindow window = new SaveClubWindow();
            SaveClubViewModel viewModel = new SaveClubViewModel(window, _viewModel);

            window.DataContext = viewModel;

            window.Show();
        }
    }
}
