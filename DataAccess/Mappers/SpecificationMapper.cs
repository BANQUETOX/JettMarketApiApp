using Dapper;
using DataAccess.Dao;
using DTO.Specifications;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class SpecificationMapper
    {
        internal SqlDao sqlDao = SqlDao.GetInstance();

        public int CreateSpecification(InputSpecification specification)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@name",specification.name);
            parameters.Add("@value",specification.value);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_SPECIFICATION";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public List<DbSpecification> GetAllSpecification(){
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_SPECIFICATIONS";
            var result = sqlDao.QueryProcedure<DbSpecification>(operation);
            return result;
        }

        public int UpdtadeSpecification(DbSpecification specification){
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id",specification.id);
            parameters.Add("@name",specification.name);
            parameters.Add("@value",specification.value);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_UPDATE_SPECIFICATION";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;

        }

        public int DeleteSpecification(int id){
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id",id);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DELTE_SPECIFICATION";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public int AsingSpecificationToProduct(int idSpecification, int idProdcut){
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@idSpecification",idSpecification);
                parameters.Add("@idProduct",idProdcut);
                SqlOperation operation = new SqlOperation();
                operation.procedureName = "SP_ASING_SPECIFICATION_PRODUCT";
                operation.parameters = parameters;
                var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
                return affectedRows;
        }


        public int RemoveSpecificationFromProduct(int idSpecification, int idProdcut){
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@idSpecification",idSpecification);
                parameters.Add("@idProduct",idProdcut);
                SqlOperation operation = new SqlOperation();
                operation.procedureName = "SP_REMOVE_SPECIFICATION_PRODUCT";
                operation.parameters = parameters;
                var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
                return affectedRows;
        }

        public List<DbSpecification> GetProductSpecifications(int idProdcut){
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProduct",idProdcut);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_SPECIFICATION_PRODUCT";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<DbSpecification>(operation);
            return result;
        }
    }
}
