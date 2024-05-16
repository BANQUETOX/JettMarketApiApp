using Azure.Core;
using DataAccess.Mappers;
using DTO.Users;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class UserManager
    {
        private UserMapper mapper = new UserMapper();

        public void CreateUser(UserInput user)
        {
            _ = mapper.Create(user);
        }

        public async Task<DbUser> GetUserById(int id) { 
         return await mapper.GetById(id);
        }

        public async Task<List<DbUser>> GetUsers()
        {
            return await mapper.GetAll();
        }

        public async Task<DbUser> GetUserByEmail(string email)
        {
            return await mapper.GetByEmail(email);
        }

        public void UpdateUser(DbUser user)
        {
            
            _ = mapper.Update(user);
        }

        public void DeleteUser(int id)
        {
            _ = mapper.Delete(id);

        }

        public async Task<string> Login(string email, string password)
        {
            var result  = await mapper.Login(email, password);
            return result;
        }

        public DbUser CastUserInput(UserInput userInput)
        {
           DbUser user = new DbUser();
            user.name = userInput.name;
            user.lastName = userInput.lastName;
            user.email = userInput.email;
            user.birthDay = userInput.birthDay;
            user.active = null;
            return user;    
        }
    }
}
