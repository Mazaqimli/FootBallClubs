using FootBallClubs.Commands.AdminWindowCommands;
using FootBallClubs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FootBallClubs.ViewModels
{
    public class AdminWindowViewModel : BaseWindowViewModel
    {
        public AdminWindowViewModel(AdminWindow window) : base(window)
        {
            OpenPlayers = new OpenPlayersCommand(this);
            OpenLeagues = new OpenLeaguesCommand(this);
            OpenClubs = new OpenClubsCommand(this);
        }
        public ICommand OpenPlayers { get; set; }
        public ICommand OpenLeagues { get; set; }
        public ICommand OpenClubs { get; set; }
        public Grid CenterGrid { get; set; }    
    }
}
