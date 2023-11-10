using FootballClubs.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer
{
    public class EmptyUnitOfWork : IUnitOfWork
    {
        public IClubRepository ClubRepository => throw new NotImplementedException();

        public ILeagueRepository LeagueRepository => throw new NotImplementedException();

        public ICountryRepository CountryRepository => throw new NotImplementedException();
        public IPlayerRepository PlayerRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => throw new NotImplementedException();

        public IRoleRepository RoleRepository => throw new NotImplementedException();

        public IUserRoleRepository UserRoleRepository => throw new NotImplementedException();

        public bool IsOnline()
        {
            return false;
        }
    }
}
