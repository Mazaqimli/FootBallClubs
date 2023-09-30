using FootballClubs.Core.Domain.Entities;
using FootBallClubs.Commands.PlayersCommands;
using FootBallClubs.Models;
using FootBallClubs.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FootBallClubs.ViewModels
{
    public class PlayersViewModel : IDataLoader
    {
        public PlayersViewModel()
        {
            this.OpenAddPlayer = new OpenSavePlayerCommand(this);
            this.OpenUpdatePlayer = new OpenSavePlayerCommand(this).SetForUpdate();
            this.OpenDeletePlayer = new OpenDeletePlayerCommand(this);
        }

        public ObservableCollection<PlayerModel> PlayerModels { get; set; }
        public ICommand OpenAddPlayer { get; set; }
        public ICommand OpenUpdatePlayer { get; set; }
        public ICommand OpenDeletePlayer { get; set; }
        public int SelectedPlayerIndex { get; set; } 

        public void Load()
        {
            this.PlayerModels = new ObservableCollection<PlayerModel>();
            List<Player> players = ApplicationContext.DB.PlayerRepository.Get();


            foreach (Player player in players)
            {
                PlayerModel model = new PlayerModel
                {
                    Id = player.Id,
                    FullName = player.FullName,
                    ClubId = player.ClubId
                };
                this.PlayerModels.Add(model);
            }
        }
    }
}
