using FootballClubs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Repositories
{
    public interface ILeagueRepository
    {
        void Add(League league);
        void Update(League league);
        void Delete(League id);
        League Get(int id);
        List<League>Get();
    }
}
