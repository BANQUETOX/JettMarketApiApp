using Azure.Core;
using DataAccess.Mappers;
using DTO.Specifications;
using Microsoft.Identity.Client.AppConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppLogic{
    public class SpecificationManager {
        internal SpecificationMapper mapper = new SpecificationMapper();

        public void CreateSpecification(InputSpecification specification){
            mapper.CreateSpecification(specification);
        }

        public List<DbSpecification> GetSpecifications(){
            return mapper.GetAllSpecification();
        }

        public void UpdtadeSpecification(DbSpecification specification){
            mapper.UpdtadeSpecification(specification);
        }
        public void DeleteSpecification(int id){
            mapper.DeleteSpecification(id);
        }

        public void AsingSpecificationToProduct(int idSpecification, int idProdcut){
            mapper.AsingSpecificationToProduct(idSpecification,idProdcut);
        }

        public void  RemoveSpecificationFromProduct(int idSpecification, int idProdcut){
            mapper.RemoveSpecificationFromProduct(idSpecification,idProdcut);
        }
         public List<DbSpecification> GetProductSpecification(int idProdcut){
            return mapper.GetProductSpecifications(idProdcut);
        }

    }
}