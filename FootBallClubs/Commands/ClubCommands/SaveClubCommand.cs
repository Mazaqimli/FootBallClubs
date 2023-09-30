using FootballClubs.Core.Domain.Entities;
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
    public class SaveClubCommand : ICommand
    {
        private readonly SaveClubViewModel _viewModel;

        public SaveClubCommand(SaveClubViewModel viewModel)
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
            Club club = new Club
            {
                Name = _viewModel.ClubModel.Name,
                TacticalPlan = _viewModel.ClubModel.TacticalPlan,
                TotalPower = _viewModel.ClubModel.TotalPower,
                LeagueId = _viewModel.ClubModel.LeagueId,
                CountryId = _viewModel.ClubModel.CountryId,
            };

            ApplicationContext.DB.ClubRepository.Add(club);
            _viewModel.ClubModel.Id = club.Id;

            foreach(PlayerModel model in _viewModel.SelectedPlayers)
            {
                Player player = new Player
                {
                    ClubId = club.Id,
                };

                ApplicationContext.DB.PlayerRepository.Add(player);
            }
            _viewModel.Parent.ClubModels.Add(_viewModel.ClubModel);
            _viewModel.Window.Close();
        }
    }
}
