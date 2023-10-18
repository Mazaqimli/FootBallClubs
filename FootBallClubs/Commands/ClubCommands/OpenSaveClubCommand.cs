using FootballClubs.Core.Domain.Entities;
using FootBallClubs.Models;
using FootBallClubs.ViewModels;
using FootBallClubs.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.Commands.ClubCommands
{
    public class OpenSaveClubCommand : ICommand
    {
        private readonly ClubsViewModel _viewModel;
        private bool _isUpdate;

        public OpenSaveClubCommand(ClubsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public OpenSaveClubCommand SetUpdate()
        {
            _isUpdate = true;

            return this;
        }


        public void Execute(object? parameter)
        {
            SaveClubWindow window = new SaveClubWindow();
            SaveClubViewModel viewModel = new SaveClubViewModel(window, _viewModel);
            List<Player> allPlayers = ApplicationContext.DB.PlayerRepository.Get();

            if (_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedClubIndex;

                viewModel.ClubModel = _viewModel.ClubModels[selectedIndex];

                List<Club> clubs = ApplicationContext.DB.ClubRepository.GetByClubId(viewModel.ClubModel.Id);

                foreach(Club club in clubs)
                {
                    viewModel.SelectedPlayers.Add(new Models.PlayerModel
                    {
                        Id = club.Player.Id,
                    });

                    allPlayers.RemoveAll(x => x.Id == club.Player.Id);
                }
            }

            viewModel.Load(allPlayers);
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
