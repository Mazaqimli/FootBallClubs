using FootballClubs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Repositories
{
    public interface ICountryRepository
    {
        void Add(Country country);
        void Update(Country country);
        void Delete(Country country);

        Country Get(int id);
        List<Country> Get();
    }
}
