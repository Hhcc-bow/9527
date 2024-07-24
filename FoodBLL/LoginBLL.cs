using FoodDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL
{
    public class LoginBLL
    {
        private LoginDAL loginDal = new LoginDAL();
        public string GetUserType(string username, string password)
        {
            return loginDal.GetUserType(username, password);
        }

        public bool ValidateLogin(string username, string password)
        {
            // 调用数据访问层的登录验证方法
            return loginDal.ValidateLogin(username, password);
        }

        public bool RegisterUser(string username, string password)
        {
            // 调用数据访问层的注册方法
            return loginDal.RegisterUser(username, password);
        }
        // 生成验证码的方法
        public string GenerateVerificationCode()
        {
            return loginDal.GenerateVerificationCode();
        }

        // 保存验证码到数据库的方法
        public int SaveVerificationCode(string verificationCode)
        {
            return loginDal.SaveVerificationCode(verificationCode);
        }

        // 验证验证码的方法
        public bool VerifyVerificationCode(string inputCode, string generatedCode)
        {
            return loginDal.VerifyVerificationCode(inputCode);
        }
    }
}
