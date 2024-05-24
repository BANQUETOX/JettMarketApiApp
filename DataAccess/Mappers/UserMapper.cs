using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DataAccess.Dao;
using DTO.Users;

namespace DataAccess.Mappers
{
    public class UserMapper 
    {
       
        SqlDao sqlDao = SqlDao.GetInstance();
        public int Create(UserInput user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email",user.email);
            parameters.Add("@password",user.password);
            parameters.Add("@name",user.name);
            parameters.Add("@lastName",user.lastName);
            parameters.Add("@birthday",user.birthDay);
            parameters.Add("@active", true);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_USER";
            operation.parameters = parameters;
            int affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
           
        }

        public int Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId",id);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DELETE_USER";
            operation.parameters = parameters;

            int affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public List<DbUser> GetAll()
        {
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_USERS";
            var result = sqlDao.QueryProcedure<DbUser>(operation);
            /*var users = buildUsers(result);*/
            return result;
        }

        public DbUser GetByEmail(string email)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email",email);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_USER_EMAIL";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<DbUser>(operation);
            if (result.Count() > 0)
            {
                return result[0];
            }
            else
            {
                return new DbUser();
            }
        }

        public DbUser GetById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id",id);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_USER_ID";
            operation.parameters = parameters;  
            var result = sqlDao.QueryProcedure<DbUser>(operation);
            return result[0];

        }

        public int Update(DbUser user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userId", user.id);
            parameters.Add("@name",user.name);
            parameters.Add("@lastName", user.lastName);
            parameters.Add("@email",user.email);
            parameters.Add("@birthday", user.birthDay);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_UPDATE_USER";
            operation.parameters = parameters;
            int affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public string Login(string email, string password)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email",email);
            parameters.Add("@password",password);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_LOGIN";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<string>(operation);
            return result[0];
        }

        public int UpdatePassword(int idUser, string newPassword)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idUser",idUser);
            parameters.Add("@newPassword",newPassword);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_UPDATE_USER_PASSWORD";
            operation.parameters = parameters;  
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;

        }

       
    }
}
