using Azure.Core;
using DataAccess.Mappers;
using DTO.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
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
            var userExist = ExistUser(user.email);
            
            if (userExist)
            {
                throw new Exception("The email is already registered");
            }
            else if (!IsValidEmail(user.email)) {
                throw new Exception("Not valid email format");
            }
            _ = mapper.Create(user);
        }

        public DbUser GetUserById(int id) {
            var existUser = ExistUser(id);
            if (!existUser){
                throw new Exception("User not found");
            }   
            return mapper.GetById(id);
        }

        public List<DbUser> GetUsers()
        {
            return mapper.GetAll();
        }

        public  DbUser GetUserByEmail(string email)
        {
           var existUser = ExistUser(email);
           if (!existUser){
            throw new Exception("User not found");
           }
            return mapper.GetByEmail(email);
        }

        public void UpdateUser(DbUser user)
        {
            var existUser = ExistUser(user.id);
            if (!existUser){
                throw new Exception("User doesn't exist");
            } 
            _ = mapper.Update(user);
        }

        public void DeleteUser(int id)
        {
            var existUser = ExistUser(id);
            if (!existUser){
                throw new Exception("No user to delete");
            }
            _ = mapper.Delete(id);

        }

        public string Login(string email, string password)
        {
            var existUser = ExistUser(email);
            if (!existUser){
                throw new Exception("Invalid credentials");
            }
            var result  = mapper.Login(email, password);
            return result;
        }

        public void UpdatePassword(int idUser, string newUser) { 
            mapper.UpdatePassword(idUser, newUser);
        
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

        // public DbUser CastUserInput(UserInput userInput)
        // {
        //    DbUser user = new DbUser();
        //     user.name = userInput.name;
        //     user.lastName = userInput.lastName;
        //     user.email = userInput.email;
        //     user.birthDay = userInput.birthDay;
        //     user.active = null;
        //     return user;    
        // }

        public bool ExistUser(int id){
            var userFound = mapper.GetById(id);
            if (userFound.id == 0){
                return false;
            }
            return true;
            

        }
        public bool ExistUser(string email){
            var userFound = mapper.GetByEmail(email);
            if (userFound.id == 0){
                return false;
            }
            return true;
        }
    }
}
