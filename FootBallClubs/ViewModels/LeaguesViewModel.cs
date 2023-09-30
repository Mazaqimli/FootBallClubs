using FootballClubs.Core.Domain.Entities;
using FootBallClubs.Commands.LeagueCommands;
using FootBallClubs.Models;
using FootBallClubs.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FootBallClubs.ViewModels
{
    public class LeaguesViewModel : IDataLoader
    {
        public LeaguesViewModel() 
        {
            this.OpenAddLeague = new OpenSaveLeagueCommand(this);
            this.OpenUpdateLeague = new OpenSaveLeagueCommand(this).SetAsUpdate();
            this.OpenDeleteLeague = new OpenDeleteLeagueCommand(this);
        }
        public ObservableCollection<LeagueModel> LeagueModels { get; set; }
        public ICommand OpenAddLeague{ get; set; }
        public ICommand OpenUpdateLeague { get; set; }
        public ICommand OpenDeleteLeague { get; set; }

        public int SelectedLeagueIndex { get; set; }

        public void Load()
        {
            List<League> leagues = ApplicationContext.DB.LeagueRepository.Get();

            LeagueModels = new ObservableCollection<LeagueModel>();

            foreach(League a in leagues)
            {
                LeagueModel model = new LeagueModel
                {
                    Id = a.Id,
                    Name = a.Name
                };
                LeagueModels.Add(model);
            }
        }
    }
}
