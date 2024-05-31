using DataAccess.Mappers;
using DTO.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class ImageManager
    {
        internal ImageMapper mapper = new ImageMapper();

        public void CreateImage(InputImage image)
        {
            mapper.CreateImage(image);
        }

        public List<DbImage> GetAllImages()
        {
            return mapper.GetAllImages();
        }

        public List<DbImage> GetProductImages(int idProduct)
        {
            return mapper.GetProductImages(idProduct);
        }

        public void UpdateImage (DbImage image)
        {
            mapper.UpdateImage(image);
        }
        public void DeleteImage(int id)
        {
            mapper.DeleteImage(id);
        }
    }
}
