using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Enums;
using FootBallClubs.Commands.ClubCommands;
using FootBallClubs.Models;
using FootBallClubs.ViewModels.Abstract;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FootBallClubs.ViewModels
{
    public class SaveClubViewModel : BaseWindowViewModel, IDataLoader
    {
        public SaveClubViewModel(Window window, ClubsViewModel parent) : base(window)
        {
            AddPlayerToList = new AddPlayerToListCommand(this);
            DeletePlayerFromList = new DeletePlayerFromListCommand(this);
            SaveClub = new SaveClubCommand(this);
            Parent = parent;

        }
        public ClubsViewModel Parent { get; set; }
        public ICommand SaveClub { get; set; }
        public ICommand AddPlayerToList { get; set; }
        public ICommand DeletePlayerFromList { get; set; }

        public ClubModel ClubModel { get; set; } = new ClubModel();

        public ObservableCollection<PlayerModel> Players { get; set; } = new();
        public ObservableCollection<PlayerModel> SelectedPlayers { get; set; } = new();
        public int SelectedPlayerToAdd { get; set; }
        public int SelectedPlayerToDelete { get; set; }

        public List<TacticalPlan> TacticalPlan { get; set; }


        public void Load()
        {
            List<Player> players = ApplicationContext.DB.PlayerRepository.Get();

            this.Players = new ObservableCollection<PlayerModel>();

            foreach (Player player in players)
            {
                PlayerModel model = new()
                {
                    Id = player.Id,
                    FullName = player.FullName,
                    ClubId = player.ClubId
                };
                this.Players.Add(model);
            }

            TacticalPlan = Enum.GetValues(typeof(TacticalPlan)).Cast<TacticalPlan>().ToList();
        }
    }
}
