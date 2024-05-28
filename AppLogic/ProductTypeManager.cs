using DataAccess.Mappers;
using DTO.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class ProductTypeManager
    {
        internal ProductTypeMapper mapper = new ProductTypeMapper();

        public void CreateProductType(InputProductType productType)
        {
            mapper.CreateProductType(productType);
        }

        public List<DbProductType> GetAllProductTypes()
        {
            return mapper.GetAllProductTypes();
        }

        public void UpdateProductType(DbProductType productType)
        {
            mapper.UpdateProductType(productType);
        }
        public void DeleteProductType(int idProductType)
        {
            mapper.DeleteProductType(idProductType);
        }

        public void AsingProductType(int idProduct, int idType)
        {
            mapper.AsingTypeToProduct(idProduct, idType);
        }
        public void RemoveProductType(int idProduct, int idType)
        {
            mapper.RemoveTypeToProduct(idProduct, idType);
        }
    }
}
