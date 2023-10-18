using FootballClubs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Repositories
{
    public interface IPlayerRepository
    {
        void Add(Player player);
        void Update(Player player);
        void Delete(int id);
        Player Get(int id);
        List<Player> Get();
    }
}
