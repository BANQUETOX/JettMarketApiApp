using DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserMapper : IMapper<DbUser>
    {
        Task<DbUser> GetById(int id);
        Task<DbUser> GetByEmail(string email);
        Task<int> Create(UserInput user);
        Task<int> Update(DbUser user);
        Task<int> Delete(int id);
    }
}
