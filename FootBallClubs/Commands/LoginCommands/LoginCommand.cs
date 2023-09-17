using FootballClubs.Core.Domain.Entities;
using FootBallClubs.Utils;
using FootBallClubs.ViewModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FootBallClubs.Commands.LoginCommands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginWindowViewModel _loginWindowViewModel;

        public LoginCommand(LoginWindowViewModel loginWindowViewModel)
        {
            _loginWindowViewModel = loginWindowViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true; 
        }

        public void Execute(object? parameter)
        {

            string username = _loginWindowViewModel.LoginModel.Username;

            User user = ApplicationContext.DB.UserRepository.Get(username);

            if(user == null)
            {
                this.Fail(username);
                return;
            }

            string password = ((PasswordBox)parameter).Password;
            string passwordHash = HashHelper.Hash(password);

            if(user.PasswordHash != passwordHash)
            {
                this.Fail(username);
                return;
            }

            MessageBox.Show("logged in");

        }
        private void Fail(string username)
        {
            _loginWindowViewModel.LoginModel = new Models.LoginModel
            {
                Password = string.Empty,
                Username = username
            };
            _loginWindowViewModel.ErrorVisibility = Visibility.Visible;
        }
    }
}
