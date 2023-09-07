using FootballClubs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static League MapLeague(IDataReader reader)
        {
            return new League
            {
                Id = (int)reader["id"],
                Name = (string)reader["name"],
            };
        }
        public static Country MapCountry(IDataReader reader)
        {
            return new Country
            {
                Id = (int)reader["id"],
                Name = (string)reader["name"],
            };
        }
    }
}
