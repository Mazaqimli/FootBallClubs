using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer.SqlServer
{
    public class SqlClubRepository : IClubRepository
    {
        private readonly string _connectionString;

        public SqlClubRepository(string connectionStirng)
        {
            _connectionString = connectionStirng;
        }

        public void Add(Club club)
        {
            
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into Clubs(leagueId,countryId) values (@name, @totalPower, @tacticalPlan,@leagueId,@countryId)";

            SqlCommand cmd = new SqlCommand (query, connection);

            cmd.Parameters.AddWithValue("name", club.Name);
            cmd.Parameters.AddWithValue("totalPower", club.TotalPower);
            cmd.Parameters.AddWithValue("tacticalPlan", club.TacticalPlan);
            cmd.Parameters.AddWithValue("leagueId", club.LeagueId);
            cmd.Parameters.AddWithValue("countryId", club.CountryId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Club club)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from clubs where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", club.Id);

            cmd.ExecuteNonQuery();
        }
        public void Update(Club club)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update clubs set name = @name, totalPower = @totalPower , tacticalPlan = @tacticalPla";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public Club Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select cs.Id ClubId , cs.Name ClubName, cs.CountryId, cy.Name CountryName, 
cs.LeagueId, l.Name LeagueName, cs.TotalPower, cs.TacticalPlan
from Clubs cs
join Leagues l on l.Id = cs.LeagueId
join Countries cy on cy.Id = cs.CountryId
where cs.id =@id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapClubJoin(reader);
            }
            return null;
        }

        public List<Club> Get(Club club)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from clubs";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Club> clubs = new List<Club>();

            while (reader.Read())
            {
                Club cb = Mapper.MapClub(reader);
                clubs.Add(cb);
            }
            return clubs;
        }

        public List<Club> GetByLeagueId(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select cs.Id ClubId , cs.Name ClubName, cs.CountryId, cy.Name CountryName, 
cs.LeagueId, l.Name LeagueName, cs.TotalPower, cs.TacticalPlan
from Clubs cs
join Leagues l on l.Id = cs.LeagueId
join Countries cy on cy.Id = cs.CountryId
where l.id =@id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Club> Club = new List<Club>();

            while (reader.Read())
            {
                Club cb = Mapper.MapClubJoin(reader);

                Club.Add(cb);
            }
            return Club;
        }

        public List<Club> GetByCountryId(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select cs.Id ClubId , cs.Name ClubName, cs.CountryId, cy.Name CountryName, 
cs.LeagueId, l.Name LeagueName, cs.TotalPower, cs.TacticalPlan
from Clubs cs
join Leagues l on l.Id = cs.LeagueId
join Countries cy on cy.Id = cs.CountryId
where cy.id =@id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Club> Club = new List<Club>();

            while (reader.Read())
            {
                Club cb = Mapper.MapClubJoin(reader);

                Club.Add(cb);
            }
            return Club;
        }
    }
}
