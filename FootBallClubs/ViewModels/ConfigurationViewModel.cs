using FootballClubs.Core.Domain.Enums;
using FootBallClubs.Commands.ConfigurationCommands;
using FootBallClubs.Models;
using FootBallClubs.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FootBallClubs.ViewModels
{
    public class ConfigurationViewModel : BaseWindowViewModel
    {
        public ConfigurationViewModel(Window window) : base(window)
        {
            AppSettings currentSettings = ApplicationContext.Settings;

            Configuration = new ConfigurationModel
            {
                WindowsAuthentication = currentSettings.WindowsAuthentication,
                DbHost = currentSettings.DbHost,
                DbName = currentSettings.DbName,
                DbPort = currentSettings.DbPort,
                DbType = currentSettings.DbType,
                Username = currentSettings.Username,
            };

            SupportedDbTypes = Enum.GetValues(typeof(DatabaseType)).Cast<DatabaseType>().ToList();
            /*new List<DatabaseType>
            {
                DatabaseType.MySql,
                DatabaseType.SqlServer,
                DatabaseType.InMemory
            };*/
            Save = new SaveCommand(this);
            Cancel = new CancelCommand(this);
        }

        public ConfigurationModel Configuration { get; set; }
        public List<DatabaseType> SupportedDbTypes { get; set; }
        public ICommand Cancel { get; set; }
        public ICommand Save { get; set; }
    }
}
