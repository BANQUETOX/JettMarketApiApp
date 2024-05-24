using Azure.Core;
using DataAccess.Mappers;
using DTO.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppLogic
{
    public class UserManager
    {
        private UserMapper mapper = new UserMapper();

        public void CreateUser(UserInput user)
        {
            DbUser userFound = mapper.GetByEmail(user.email);
            if (userFound.email != null)
            {
                throw new Exception("The email is already registered");
            }
            else if (!IsValidEmail(user.email)) {
                throw new Exception("Not valid email format");
            }
            _ = mapper.Create(user);
        }

        public DbUser GetUserById(int id) { 
         return mapper.GetById(id);
        }

        public async List<DbUser> GetUsers()
        {
            return mapper.GetAll();
        }

        public  DbUser GetUserByEmail(string email)
        {
            return mapper.GetByEmail(email);
        }

        public void UpdateUser(DbUser user)
        {
            
            _ = mapper.Update(user);
        }

        public void DeleteUser(int id)
        {
            _ = mapper.Delete(id);

        }

        public string Login(string email, string password)
        {
            var result  = mapper.Login(email, password);
            return result;
        }

        internal bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Define a regular expression pattern for a valid email
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                // Check the email with the regex
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                // If an exception occurs during regex processing, consider the email invalid
                return false;
            }
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
