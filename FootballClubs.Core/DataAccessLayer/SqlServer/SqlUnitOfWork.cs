using FootballClubs.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IClubRepository ClubRepository => new SqlClubRepository(_connectionString);

        public ILeagueRepository LeagueRepository => new SqlLeagueRepository(_connectionString);

        public ICountryRepository CountryRepository => new SqlCountryRepository(_connectionString);
        public IPlayerRepository PlayerRepository => new SqlPlayerRepository(_connectionString);
        public IUserRepository  UserRepository => new SqlUserRepository(_connectionString);
        public bool IsOnline()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
