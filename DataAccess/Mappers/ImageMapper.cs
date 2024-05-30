using Dapper;
using DataAccess.Dao;
using DTO.Images;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers{
    public class ImageMapper{
        internal SqlDao sqlDao = SqlDao.GetInstance();


        public int CreateImage(InputImage inputImage){
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@imageValue",inputImage.imageValue);
            parameters.Add("@idProduct",inputImage.idProduct);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_IMAGE";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;

        }

        public List<DbImage> GetAllImages(){
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_IMAGES";
            var result = sqlDao.QueryProcedure<DbImage>(operation);
            return result;

        }

        public List<DbImage> GetProductImages(int idProduct){
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idProduct",idProduct);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_IMAGE_PRODUCT";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<DbImage>(operation);
            return result;
        }

        public int UpdateImage(DbImage image){
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id",image.id);
            parameters.Add("@imageValue", image.imageValue);
            parameters.Add("@idProduct", image.idProduct);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_UPDATE_IMAGE";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public int DeleteImage(int id){
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id",id);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DELETE_IMAGE";
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }
    }
}