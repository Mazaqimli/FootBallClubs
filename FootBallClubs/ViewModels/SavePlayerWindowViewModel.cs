using FootBallClubs.Commands.PlayersCommands;
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
    public class SavePlayerWindowViewModel : BaseWindowViewModel
    {
        public SavePlayerWindowViewModel(Window window, PlayersViewModel parent) : base(window)
        {
            PlayerModel = new PlayerModel();    
            SavePlayer = new SavePlayerCommand(this);
            Parent = parent;
        }
        public PlayerModel PlayerModel { get; set; }
        public ICommand SavePlayer { get; set; }
        public PlayersViewModel Parent { get; set; }
    }
}
