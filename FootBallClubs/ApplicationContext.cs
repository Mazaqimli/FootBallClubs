using FootballClubs.Core.Domain.Enums;
using FootballClubs.Core.Domain.Repositories;
using FootBallClubs.Factories;
using FootBallClubs.Settings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace FootBallClubs
{
    public static class ApplicationContext
    {
        private static AppSettings _defaultSettings = new AppSettings
        {
            DbHost = "localhost",
            DbName = "default",
            DbPort = 1433,
            DbType = DatabaseType.SqlServer,
            Username = "",
            Password = "",
            WindowsAuthentication = true
        };

        public static string ConfigurationPath
        {
            get
            {
                string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                settingsPath = Path.Combine(settingsPath, "FootBallClubs");

                if(Directory.Exists(settingsPath)== false)
                {
                    Directory.CreateDirectory(settingsPath);
                }

                return settingsPath;
            }
        }

        public static AppSettings Settings { get; private set; }
        public static IUnitOfWork DB { get; private set;}
        public static void Initalize()
        {
            Settings = InitalilzeSettings();
            DB = DbFactory.Get(Settings);
        }
        private static AppSettings InitalilzeSettings()
        {
            string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settingsPath = Path.Combine(settingsPath, "FootBallClubs");

            AppSettingsHelper helper = new AppSettingsHelper(settingsPath);

            AppSettings appSettings = helper.GetSettings();

            if(appSettings is null)
            {
                appSettings = _defaultSettings;
            }
            return appSettings;
        } 
    }
}
