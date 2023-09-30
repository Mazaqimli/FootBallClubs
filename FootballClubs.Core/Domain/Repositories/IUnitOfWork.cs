using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {

        public IClubRepository ClubRepository { get; }
        public ILeagueRepository LeagueRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IPlayerRepository PlayerRepository { get; }
        public IUserRepository UserRepository { get; }
        bool IsOnline();
    }
}