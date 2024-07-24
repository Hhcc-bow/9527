using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDll
{
    public class LoginDAL
    {
        public string GenerateVerificationCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] code = new char[4];
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }
            return new string(code);
        }

        // 保存验证码到数据库的方法
        public int SaveVerificationCode(string verificationCode)
        {

            string sql = $"INSERT INTO VerificationCodes (Code) VALUES (@Code)";
            var cud = DbHelper.CUD(sql, new List<MySqlParameter>
            {
                new MySqlParameter("@Code", verificationCode)
            });
            return cud;
        }

        // 验证验证码是否存在于数据库的方法
        public bool VerifyVerificationCode(string inputCode)
        {

            string sql = $"SELECT COUNT(*) FROM VerificationCodes WHERE Code = @Code";
            int count = Convert.ToInt32(DbHelper.GetScalar(sql, new List<MySqlParameter>
            {
                new MySqlParameter("@Code", inputCode)
            }));
            return count > 0;
        }

        public string GetUserType(string username, string password)
        {
            string sql = $"select UserType from Users where username = @LoginName and password = @LoginPwd";
            object result = DbHelper.GetScalar(sql, new List<MySqlParameter>
            {
                new MySqlParameter("@LoginName", username),
                new MySqlParameter("@LoginPwd", password)
            });
            return result == null ? null : Convert.ToString(result);
        }

        public bool ValidateLogin(string username, string password)
        {


            string sql = $"select count(1) from Users where username = @LoginName and password = @LoginPwd";
            int index = Convert.ToInt32(DbHelper.GetScalar(sql, new List<MySqlParameter>
            {
                new MySqlParameter("@LoginName", username),
                new MySqlParameter("@LoginPwd", password)
            }));
            return index > 0;


        }

        public bool RegisterUser(string username, string password)
        {
            string insertSql = $"INSERT INTO Users (username, password) VALUES (@LoginName, @LoginPwd)";
            int rowsAffected = DbHelper.CUD(insertSql, new List<MySqlParameter>
            {
                new MySqlParameter("@LoginName", username),
                new MySqlParameter("@LoginPwd", password)
            });
            return rowsAffected > 0;
        }
    }
}
