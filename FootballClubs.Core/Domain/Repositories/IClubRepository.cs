using FootballClubs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Repositories
{
    public interface IClubRepository
    {
        void Add(Club club);
        void Update(Club club);
        void Delete(int id);
        void DeleteByPlayer(int id);
        Club Get(int id);
        List<Club> Get();

        List<Club> GetByClubId(int id);

        List<Club> GetByLeagueId(int id);
        List<Club> GetByCountryId(int id);
    }
}
