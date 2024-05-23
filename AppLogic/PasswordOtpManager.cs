using DataAccess.Mappers;
using DTO.PasswordOtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class PasswordOtpManager
    {
        internal PasswordOtpMapper mapper = new PasswordOtpMapper();

        public void CreatePasswordOtp(string email)
        {
            PasswordOtp passwordOtp = new PasswordOtp();
            passwordOtp.email = email;
            passwordOtp.otp = OtpGenerator.GenerateOtp();
            mapper.CreatePasswordOtp(passwordOtp);
        }

        public bool ValidateOtp(string userEmail, string otpInput)
        {
            string dbOtp = mapper.GetUserPasswordOtp(userEmail);
            return dbOtp == otpInput;
        }

        public void DeletePasswordOtp(int idUser)
        {
            mapper.DeletePasswordOtp(idUser);
        }
    }
}
