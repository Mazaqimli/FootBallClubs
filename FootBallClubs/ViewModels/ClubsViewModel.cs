using FootballClubs.Core.Domain.Entities;
using FootBallClubs.Commands.ClubCommands;
using FootBallClubs.Commands.PlayersCommands;
using FootBallClubs.Models;
using FootBallClubs.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.ViewModels
{
    public class ClubsViewModel : IDataLoader
    {
        public ClubsViewModel() 
        {
            OpenAddClub = new OpenSaveClubCommand(this);
            OpenUpdateClub = new OpenSaveClubCommand(this).SetUpdate();
            OpenDeleteClub = new OpenDeleteClubCommand(this);
        }
        public ObservableCollection<ClubModel> ClubModels { get; set; }
        public ICommand OpenAddClub { get; set; }
        public ICommand OpenUpdateClub { get; set; }
        public ICommand OpenDeleteClub { get; set; }
        public int SelectedClubIndex { get; set; }
        public void Load()
        {
            ClubModels = new ObservableCollection<ClubModel>();

            List<Club> clubs = ApplicationContext.DB.ClubRepository.Get();


            foreach (Club club in clubs)
            {
                ClubModel model = new()
                {
                    Id = club.Id,
                    Name = club.Name,
                    TotalPower = club.TotalPower,
                    TacticalPlan = club.TacticalPlan,
                    LeagueId = club.LeagueId,
                    CountryId = club.CountryId
                };
                ClubModels.Add(model);
            }

        }
    }
}
