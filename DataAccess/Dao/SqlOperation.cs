using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class SqlOperation
    {

        public string procedureName {  get; set; }
        public DynamicParameters parameters { get; set; }

    }
}
