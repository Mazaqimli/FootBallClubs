using FootBallClubs.ViewModels;
using FootBallClubs.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.Commands.LeagueCommands
{
    public class OpenSaveLeagueCommand : ICommand
    {
        private readonly LeaguesViewModel _viewModel;
        private bool _isUpdate;
        public OpenSaveLeagueCommand(LeaguesViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public OpenSaveLeagueCommand SetAsUpdate()
        {
            _isUpdate = true; 

            return this;
        }
        public void Execute(object? parameter)
        {
            SaveLeagueWindow window = new SaveLeagueWindow();
            SaveLeagueWindowViewModel viewModel = new (window, _viewModel);

            window.DataContext = viewModel;

            if (_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedLeagueIndex;

                viewModel.LeagueModel = _viewModel.LeagueModels[selectedIndex];
            }
            window.Show();

        }
    }
}
