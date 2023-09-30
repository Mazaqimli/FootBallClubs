using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer.SqlServer
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(User user)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"insert into users values(@username,@passwordHash,@email)";
            
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("passwordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("email", user.Email);
            cmd.ExecuteNonQuery();
        }

        public User Get(string username)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from users where username = @username";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("username", username);

            SqlDataReader reader = cmd.ExecuteReader();
            
                if (reader.Read())
                {
                    return Mapper.MapUser(reader);
                }
            

            return null;

        }
    }
}
