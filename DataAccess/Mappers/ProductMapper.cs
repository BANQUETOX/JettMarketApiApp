using Dapper;
using DataAccess.Dao;
using DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class ProductMapper
    {
        internal SqlDao sqlDao = SqlDao.GetInstance();

        public int CreateProduct(ProductInput product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@price",product.price);
            parameters.Add("@name",product.name);
            parameters.Add("@description",product.description);
            parameters.Add("@quantity",product.quantity);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_PRODUCT";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public List<DbProduct> GetAllProducts()
        {
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_PRODUCTS";
            var result = sqlDao.QueryProcedure<DbProduct>(operation);
            return result;
        }

        public List<DbProduct> GetAvailableProducts()
        {
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_PRODUCTS_AVAILABLE";
            var result = sqlDao.QueryProcedure<DbProduct>(operation);
            return result;
        }
        public List<DbProduct> GetInStockProducts()
        {
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_PRODUCT_STOCK";
            var result = sqlDao.QueryProcedure<DbProduct>(operation);
            return result;
        }

        public List<DbProduct> GetAvailableInStockProducts()
        {
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_PRODUCT_AVAILABLE_STOCK";
            var result = sqlDao.QueryProcedure<DbProduct>(operation);
            return result;
        }


        public int UpdateProduct(DbProduct product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProduct",product.id);
            parameters.Add("@price", product.price);
            parameters.Add("@name", product.name);
            parameters.Add("@description", product.description);
            parameters.Add("@quantity",product.quantity);
            parameters.Add("@available", product.available);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_UPDATE_PRODUCT";
            operation.parameters = parameters;  
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);    
            return affectedRows;
        }

        public int DeleteProduct(int idProduct)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProduct", idProduct);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DELETE_PRODUCT";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }
        public int DisableProduct(int idProduct)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProduct",idProduct);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DISABLE_PRODUCT";
            operation.parameters = parameters;
            var affectedRows  = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }


    }
}
