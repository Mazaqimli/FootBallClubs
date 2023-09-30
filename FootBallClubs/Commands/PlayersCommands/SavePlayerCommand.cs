using FootballClubs.Core.Domain.Entities;
using FootBallClubs.Models;
using FootBallClubs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.Commands.PlayersCommands
{
    public class SavePlayerCommand : ICommand
    {
        private readonly SavePlayerWindowViewModel _viewModel;

        public SavePlayerCommand(SavePlayerWindowViewModel viewModel)
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
            PlayerModel model = _viewModel.PlayerModel;

            Player player = new Player
            {
                Id = model.Id,
                FullName = model.FullName,
                ClubId = model.ClubId
            };

            if (player.Id > 0)
            { 
                ApplicationContext.DB.PlayerRepository.Update(player);
            }
            else
            {
                ApplicationContext.DB.PlayerRepository.Add(player);

                model.Id = player.Id;

                _viewModel.Parent.PlayerModels.Add(model);

            }
                _viewModel.Window.Close();
        }
    }
}
