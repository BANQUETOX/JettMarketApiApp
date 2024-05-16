using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class SqlDao
    {
        private static SqlDao instance = new SqlDao();
        public string connectionString = "Server=DESKTOP-VVRVS5O;Database=JettMarketDb;Trusted_Connection=True; Encrypt=False";

        public static SqlDao GetInstance()
        {
            if (instance == null)
            {
                instance = new SqlDao();
            }
            return instance;
        }

        public int ExecuteStoredProcedure(SqlOperation operation) {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                int rowsAffected = connection.Execute(operation.procedureName,operation.parameters, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<T> QueryProcedure<T>(SqlOperation operation)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var result = connection.Query<T>(operation.procedureName, operation.parameters, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return (List<T>)result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
