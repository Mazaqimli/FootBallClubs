using FootballClubs.Core.Domain.Entities;
using FootBallClubs.Models;
using FootBallClubs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallClubs.Commands.LeagueCommands
{
    public class SaveLeagueCommand : ICommand
    {
        private readonly SaveLeagueWindowViewModel _viewModel;

        public SaveLeagueCommand(SaveLeagueWindowViewModel viewModel)
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
            LeagueModel model = _viewModel.LeagueModel;

            League league = new League
            {
                Id = model.Id,
                Name = model.Name,
            };

            if(league.Id > 0)
            {
                ApplicationContext.DB.LeagueRepository.Update(league);
            }
            else
            {
                ApplicationContext.DB.LeagueRepository.Add(league);
                model.Id = league.Id;

                _viewModel.Parent.LeagueModels.Add(model);
            }
            _viewModel.Window.Close();
        }
    }
}
