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
    public class LoginViewModel : BaseWindowViewModel
    {
        public LoginViewModel(Window window) : base(window)
        {
        }
        public LoginModel LoginModel { get; set; }
        public ICommand Login { get; set; }

    }
}
