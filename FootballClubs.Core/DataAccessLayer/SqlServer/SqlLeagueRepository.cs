using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer.SqlServer
{
    public class SqlLeagueRepository : ILeagueRepository
    {
        private readonly string _connectionString;

        public SqlLeagueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(League league)
        {
            using SqlConnection connection = new SqlConnection(_connectionString) ;
            connection.Open();

            const string query = "insert into leagues value(@name)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name" ,league.Name);

            cmd.ExecuteNonQuery();

        }

        public void Delete(League id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Delete from leagues where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public void Update(League league)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Update leagues set name = @name where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", league.Id);
            cmd.Parameters.AddWithValue("name", league.Name);

            cmd.ExecuteNonQuery();
        }

        public League Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Select * from leagues where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {

                return Mapper.MapLeague(reader);
                }
            return null;
        }

        public List<League> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Select * from leagues";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<League> result = new List<League>();

            while (reader.Read())
            {
                League league = Mapper.MapLeague(reader);
                result.Add(league);
            }

            return result; 
        }
    }
}
