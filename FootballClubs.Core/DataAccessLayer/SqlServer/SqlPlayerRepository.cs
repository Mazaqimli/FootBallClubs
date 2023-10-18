using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer.SqlServer
{
    public class SqlPlayerRepository : IPlayerRepository
    {
        private readonly string _connectionString;

        public SqlPlayerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Player player)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into players output inserted.id values(@fullName ,@clubId)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("fullName", player.FullName);
            cmd.Parameters.AddWithValue("clubId", player.ClubId);

            player.Id = (int)cmd.ExecuteScalar();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from players where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
        public void Update(Player player)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update players set fullName = @fullName, clubId = @clubId where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", player.Id);
            cmd.Parameters.AddWithValue("fullName", player.FullName);
            cmd.Parameters.AddWithValue("clubId", player.ClubId);

            cmd.ExecuteNonQuery();
        }
        public Player Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from players where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapPlayer(reader);
            }

            return null;
        }

        public List<Player> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from players";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Player> players = new List<Player>();

            while (reader.Read())
            {
                Player player = Mapper.MapPlayer(reader);

                players.Add(player);
            }

            return players;
        }
    }
}
