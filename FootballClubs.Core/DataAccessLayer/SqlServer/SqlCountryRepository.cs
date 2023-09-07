using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer.SqlServer
{
    public class SqlCountryRepository : ICountryRepository
    {
        private readonly string _connectionString;

        public SqlCountryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Country country)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into countries values(name)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", country.Name);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Country country )
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from countries where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", country.Id);

            cmd.ExecuteNonQuery();
        }
        public void Update(Country country)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update countries set name = @name";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", country.Name);
            cmd.Parameters.AddWithValue("id", country.Id);
        }
        public Country Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from countries where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapCountry(reader);
            }

            return null;
        }

        public List<Country> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from countries";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Country> countries = new List<Country>();

            while (reader.Read())
            {
                Country country = Mapper.MapCountry(reader);

                countries.Add(country);
            }

            return countries;
        }

    }
}
