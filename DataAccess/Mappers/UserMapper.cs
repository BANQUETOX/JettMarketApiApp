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
        public async Task<int> Create(UserInput user)
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

        public async Task<int> Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId",id);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DELETE_USER";
            operation.parameters = parameters;

            int affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public async Task<List<DbUser>> GetAll()
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

        public async Task<DbUser> GetById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id",id);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_USER_ID";
            operation.parameters = parameters;  
            var result = sqlDao.QueryProcedure<DbUser>(operation);
            return result[0];

        }

        public async Task<int> Update(DbUser user)
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

        public async Task<string> Login(string email, string password)
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
    }
}
