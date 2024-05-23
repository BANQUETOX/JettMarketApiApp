using Dapper;
using DataAccess.Dao;
using DTO.PasswordOtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class PasswordOtpMapper
    {
        internal SqlDao sqlDao = SqlDao.GetInstance();

        public int CreatePasswordOtp(PasswordOtp passwordOtp)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@otp", passwordOtp.otp);
            parameters.Add("@userEmail", passwordOtp.email);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_PASSWORD_OTP";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public string GetUserPasswordOtp(string userEmail)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userEmail",userEmail);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_PASSWORD_OTP_EMAIL";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<string>(operation);
            return result[0];
        }

        public int DeletePasswordOtp(int idUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idUser",idUser);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DELETE_PASSWORD_OTP";
            operation.parameters = parameters;  
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);    
            return affectedRows;

        }
    }
}
