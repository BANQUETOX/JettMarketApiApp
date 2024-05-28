using Dapper;
using DataAccess.Dao;
using DTO.Products;
using DTO.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class ProductTypeMapper
    {
        internal SqlDao sqlDao = SqlDao.GetInstance();  
        
        public int CreateProductType(InputProductType productType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@name",productType.name);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_PRODUCT_TYPE";
            operation.parameters = parameters;
            var affectedRows =  sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public List<DbProductType> GetAllProductTypes()
        {
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_PRODUCT_TYPES";
            var result = sqlDao.QueryProcedure<DbProductType>(operation);
            return result;
        }

        public int UpdateProductType (DbProductType productType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProductType",productType.id);
            parameters.Add("@newName",productType.name);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_UPDATE_PRODUCT_TYPE";
            operation.parameters = parameters;  
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public int DeleteProductType(int idProductType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProductType",idProductType);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DELETE_PRODUCT_TYPE";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure (operation);
            return affectedRows;
        }


        public int AsingTypeToProduct(int idProduct, int idType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProduct", idProduct);
            parameters.Add("@idType",idType);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_ASING_PRODUCT_TYPE";
            operation.parameters = parameters;
            var rowsAffected = sqlDao.ExecuteStoredProcedure(operation);
            return rowsAffected;
        }

        public int RemoveTypeToProduct(int idProduct, int idType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProduct", idProduct);
            parameters.Add("@idType", idType);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_REMOVE_PRODUCT_TYPE";
            operation.parameters = parameters;
            var rowsAffected = sqlDao.ExecuteStoredProcedure(operation);
            return rowsAffected;
        }
    }
}
