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

            const string query = "insert into clubs output inserted.id values (@name, @totalPower, @tacticalPlan,@leagueId,@countryId)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", club.Name);
            cmd.Parameters.AddWithValue("totalPower", club.TotalPower);
            cmd.Parameters.AddWithValue("tacticalPlan", club.TacticalPlan);
            cmd.Parameters.AddWithValue("leagueId", club.LeagueId);
            cmd.Parameters.AddWithValue("countryId", club.CountryId);

            club.Id = (int)cmd.ExecuteScalar();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from clubs where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
        public void Update(Club club)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update clubs set name = @name, totalPower = @totalPower , tacticalPlan = @tacticalPlan";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", club.Name);
            cmd.Parameters.AddWithValue("totalPower", club.TotalPower);
            cmd.Parameters.AddWithValue("tacticalPlan", club.TacticalPlan);

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

        public List<Club> Get()
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
        public List<Club> GetByClubId(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select cs.Id ClubId , cs.Name ClubName, cs.CountryId, cy.Name CountryName, 
cs.LeagueId, pl.FullName, l.Name LeagueName, cs.TotalPower, cs.TacticalPlan
from Clubs cs
join Leagues l on l.Id = cs.LeagueId
join Countries cy on cy.Id = cs.CountryId
join Players pl on pl.ClubId = cs.Id
where cy.id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Club> clubs = new List<Club>();

            while (reader.Read())
            {
                Club club = Mapper.MapClubJoin(reader);

                clubs.Add(club);
            }
            return clubs;

            //public List<Club> Get()
            //{
            //    throw new NotImplementedException();
            //}
        }

        public void DeleteByPlayer(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from clubs where id = @clubId";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("clubId", id);

            cmd.ExecuteNonQuery();
        }
    }
}
