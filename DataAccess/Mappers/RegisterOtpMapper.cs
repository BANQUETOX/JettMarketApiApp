using Dapper;
using DataAccess.Dao;
using DTO.RegistersOtp;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class RegisterOtpMapper
    {
        internal SqlDao sqlDao = SqlDao.GetInstance();

        public int CreateRegisterOtp(RegisterOtp registerOtp)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@otp",registerOtp.otp);
            parameters.Add("@email",registerOtp.email);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_REGISTER_OTP";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }


        public string GetUserRegisterOtp(string email)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email", email);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_REGISTER_OTP_EMAIL";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<string>(operation);
            return result[0];
        }

        public int DeleteRegisterOtp(string email)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email",email);
            SqlOperation operation = new SqlOperation();
            operation.procedureName= "SP_DELETE_REGISTER_OTP";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }
    }
}
