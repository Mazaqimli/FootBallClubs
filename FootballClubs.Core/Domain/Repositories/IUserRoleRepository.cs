using FootballClubs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Repositories
{
    public interface IUserRoleRepository
    {
        List<UserRole> GetByUserId(int userId);

        List<UserRole> GetByRoleId(int roleId);
    }
}
