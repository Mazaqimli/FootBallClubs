using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security;
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
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
            };
        }
        public static Country MapCountry(IDataReader reader)
        {
            return new Country
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
            };
        }
        public static Club MapClub(IDataReader reader)
        {
            return new Club
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                TotalPower = (decimal)reader["TotalPower"],
                TacticalPlan = (TacticalPlan)reader["TacticalPlan"],
                LeagueId = (int)reader["LeagueId"],
                CountryId = (int)reader["CountryId"]


            };
        }

        public static Club MapClubJoin(IDataReader reader)
        {
            return new Club
            {

                Id = (int)reader["ClubId"],
                Name = (string)reader["ClubName"],

                CountryId = (int)reader["CountryId"],
                Country = new Country
                {
                    Id = (int)reader["CountryId"],
                    Name = (string)reader["CountryName"],
                },
                LeagueId = (int)reader["LeagueId"],
                League = new League
                {
                    Id = (int)reader["LeagueId"],
                    Name = (string)reader["LeagueName"]
                },
                TotalPower = (decimal)reader["TotalPower"],
                TacticalPlan = (TacticalPlan)reader["TacticalPlan"],
                Player = new Player
                {
                    Id = (int)reader["ClubId"],
                    FullName = (string)reader["FullName"]
                },
            };
        }
        public static User MapUser(IDataReader reader)
        {
            return new User
            {
                Username = (string)reader["username"],
                Email = (string)reader["email"],
                PasswordHash = (string)reader["passwordHash"]
            };
        }
        public static Player MapPlayer(IDataReader reader)
        {
            return new Player
            {
                Id = (int)reader["id"],
                FullName = (string)reader["fullName"],
                ClubId = (int)reader["clubId"]
            };
        }
    }
}
