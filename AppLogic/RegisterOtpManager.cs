using DataAccess.Mappers;
using DTO.RegistersOtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class RegisterOtpManager
    {
        internal RegisterOtpMapper mapper = new RegisterOtpMapper();


        public string GetUserOtp(string email)
        {
            return mapper.GetUserRegisterOtp(email);
        }
        public void CreateRegisterOtp(string email)
        {
            RegisterOtp registerOtp = new RegisterOtp();
            registerOtp.email = email;
            registerOtp.otp = OtpGenerator.GenerateOtp();
            mapper.CreateRegisterOtp(registerOtp);

        }

        public void DeleteRegisterOtp(string email)
        {
            mapper.DeleteRegisterOtp(email);
        }

        public bool ValidateInputOtp(string email, string inputOtp)
        {
            string dbRegisterOtp = GetUserOtp(email);
            return dbRegisterOtp == inputOtp;
        }

        
    }
}
