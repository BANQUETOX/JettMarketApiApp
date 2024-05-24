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


    }
}
