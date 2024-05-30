using Dapper;
using DataAccess.Dao;
using DTO.Specifications;
using System;
using System.Collections.Generic;
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
        }
    }
}
