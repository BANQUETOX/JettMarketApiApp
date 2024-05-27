using Azure.Core;
using DataAccess.Mappers;
using DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class ProductManager
    {
        internal ProductMapper mapper = new ProductMapper();    

        public void CreateProduct(ProductInput product)
        {
            mapper.CreateProduct(product);
        }
        public void UpdateProduct(DbProduct product)
        {
            mapper.UpdateProduct(product);
        }
        public void DeleteProduct(int idProduct) {
            mapper.DeleteProduct(idProduct);
        }

        public List<DbProduct> GetAllProducts() { 
            return mapper.GetAllProducts();
        }

        public List<DbProduct> GetProductsInStock()
        {
            return mapper.GetInStockProducts();
        }

        public List<DbProduct> GetProductsAvailable()
        {
            return mapper.GetAvailableProducts();
        }

        public List<DbProduct> GetProductsInStockAvailables()
        {
            return mapper.GetAvailableInStockProducts();
        }

        


    }
}
