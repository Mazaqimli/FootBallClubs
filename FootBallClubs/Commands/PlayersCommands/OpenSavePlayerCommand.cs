using FootBallClubs.ViewModels;
using FootBallClubs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.Commands.PlayersCommands
{
    public class OpenSavePlayerCommand : ICommand
    {
        private readonly PlayersViewModel _viewModel;

        private bool _isUpdate;

        public OpenSavePlayerCommand(PlayersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public OpenSavePlayerCommand SetForUpdate()
        {
            _isUpdate = true;
            return this; 

        }

        public void Execute(object? parameter)
        {
            SavePlayerWindow window = new SavePlayerWindow();
            SavePlayerWindowViewModel viewModel = new SavePlayerWindowViewModel(window, _viewModel);

            window.DataContext = viewModel;

            if (_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedPlayerIndex;

                viewModel.PlayerModel = _viewModel.PlayerModels[selectedIndex];
            }

            window.Show();
        }
    }
}
