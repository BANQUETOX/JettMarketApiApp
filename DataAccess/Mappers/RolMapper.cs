using Dapper;
using DataAccess.Dao;
using DTO.Rols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class RolMapper
    {
        SqlDao sqlDao = SqlDao.GetInstance();


        public  List<DbRol> GetAllRols()
        {
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_ROLS";
            var result = sqlDao.QueryProcedure<DbRol>(operation);
            return result;
        }
        public DbRol GetRolById(int id)
        {
            DynamicParameters parameters = new DynamicParameters(); 
            parameters.Add("@id", id);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_ROL_ID";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<DbRol>(operation);
            return result[0];
        }

        public int AsingAdminRol(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId",userId);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_ASING_ADMIN";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public int RemoveAdminRol(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_REMOVE_ADMIN";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }
        public int AsingCustomerRol(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_ASING_CUSTOMER";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;

        }
        public int RemoveCustomerRol(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_REMOVE_CUSTOMER";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }
    }
}
