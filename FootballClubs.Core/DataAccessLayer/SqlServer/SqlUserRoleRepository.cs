using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.DataAccessLayer.SqlServer
{
    public class SqlUserRoleRepository : IUserRoleRepository
    {
        private readonly string _connectionString;

        public SqlUserRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserRole> GetByRoleId(int roleId)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            const string query = @"select ur.Id, ur.RoleId, r.Id RoleId, r.Name RoleName, 
                                   ur.UserId, u.Username, u.Email, u.PasswordHash  from UserRoles ur 
                                   join Users u on u.Id = ur.UserId
                                   join Roles r on r.Id = ur.RoleId
                                   where ur.roleId = @roleId";


            SqlCommand cmd = new(query, connection);

            cmd.Parameters.AddWithValue("roleId", roleId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<UserRole> userRoles = new();

            while (reader.Read())
            {
                UserRole userRole = Mapper.MapUserRole(reader);

                userRoles.Add(userRole);

            }
            return userRoles;

        }

        public List<UserRole> GetByUserId(int userId)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            const string query = @"select ur.Id, ur.RoleId, r.Id RoleId, r.Name RoleName, 
                                   ur.UserId, u.Username, u.Email, u.PasswordHash  from UserRoles ur 
                                   join Users u on u.Id = ur.UserId
                                   join Roles r on r.Id = ur.RoleId
                                   where ur.userId = @userId";


            SqlCommand cmd = new(query, connection);

            cmd.Parameters.AddWithValue("userId", userId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<UserRole> userRoles = new();

            while (reader.Read())
            {
                UserRole userRole = Mapper.MapUserRole(reader);

                userRoles.Add(userRole);

            }
            return userRoles;
        }
    }
}
