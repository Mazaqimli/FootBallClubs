using FootBallClubs.Commands.LeagueCommands;
using FootBallClubs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FootBallClubs.ViewModels
{
    public class SaveLeagueWindowViewModel : BaseWindowViewModel
    {
        public SaveLeagueWindowViewModel(Window window, LeaguesViewModel parent) : base(window)
        {
            this.LeagueModel = new LeagueModel();
            this.Parent = parent;
            this.SaveLeague = new SaveLeagueCommand(this);
        }

        public LeagueModel LeagueModel { get; set; }
        public ICommand SaveLeague { get; set; }
        public LeaguesViewModel Parent { get; set; }
    }
}
