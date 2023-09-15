using FootballClubs.Core.DataAccessLayer;
using FootballClubs.Core.DataAccessLayer.SqlServer;
using FootballClubs.Core.Domain.Repositories;
using FootBallClubs.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallClubs.Factories
{
    public static class DbFactory
    {
        public static IUnitOfWork Get(AppSettings appSettings)
        {
            switch (appSettings.DbType)
            {
                case FootballClubs.Core.Domain.Enums.DatabaseType.SqlServer:
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.InitialCatalog = appSettings.DbName;
                    builder.DataSource = appSettings.DbHost;
                    builder.IntegratedSecurity = appSettings.WindowsAuthentication;
                    builder.TrustServerCertificate = true;

                    if(appSettings.WindowsAuthentication == false)
                    {
                        builder.UserID = appSettings.Username;
                        builder.Password = appSettings.Password;
                    }


                    string connectionString = builder.ToString();

                    return new SqlUnitOfWork(connectionString);

                case FootballClubs.Core.Domain.Enums.DatabaseType.MySql:
                    return new EmptyUnitOfWork();
                case FootballClubs.Core.Domain.Enums.DatabaseType.InMemory:
                    return new EmptyUnitOfWork();
                default:
                    throw new NotSupportedException($"{appSettings.DbType} not supported");
            }



        }
    }
}
