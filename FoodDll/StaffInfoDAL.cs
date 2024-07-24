using FoodEntity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDll
{
    public class StaffInfoDAL
    {
        #region 查询员工姓名
        /// <summary>
        /// 查询员工姓名
        /// </summary>
        /// <returns></returns>
        public List<StaffInfos> GetStaffName() { 
            List<StaffInfos> staffInfos = new List<StaffInfos>();
            string sql = string.Format(@"select staffName from staffinfo");
            MySqlDataReader mySqlDataReader = DbHelper.GetDataReader(sql);
            while (mySqlDataReader.Read()) {
                staffInfos.Add(new StaffInfos {
                    staffName = mySqlDataReader["staffName"].ToString()
                });
            }
            return staffInfos;
        }
        #endregion
        #region 添加员工
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="staffID"> 员工ID</param>
        /// <param name="staffName">员工姓名</param>
        /// <param name="staffIDCard">员工身份证号</param>
        /// <param name="staffSex">员工性别</param>
        /// <param name="staffAge">员工年龄</param>
        /// <param name="phone">员工电话</param>
        /// <returns>是否添加成功</returns>
        public int SetStaffInfo(int staffID,string staffName,string staffIDCard,string staffSex,int staffAge,string phone) {
            string sql = string.Format($"insert into staffinfo(staffID,staffName,staffIDCard,staffSex,staffAge,phone) values({staffID},'{staffName}','{staffIDCard}','{staffSex}',{staffAge},'{phone}')");
            int v = DbHelper.CUD(sql);
            return v;
        }
        #endregion
        #region 删除员工
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="staffID">员工ID</param>
        /// <returns>是否删除成功</returns>
        public int DeleteStaffInfo(int staffID) {
            string sql = string.Format($"delete from staffinfo where staffID = {staffID}");
            int v  = DbHelper.CUD(sql);
            return v;
        }
        #endregion
        #region 查找员工信息
        /// <summary>
        /// 查找员工信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStaffInfo() {
            string sql = string.Format(@"select * from staffinfo");
            DataTable dataTable = DbHelper.GetDataTable(sql);
            return dataTable;
        }
        #endregion
        #region 模糊查询员工信息
        public DataTable SelectStaffInfo(string staffID, string staffName, string staffIDCard, string staffSex, string staffAge, string phone) {
            string sql = string.Format($"select * from staffinfo where 1=1");
            if (staffID != "") { 
                int id = Convert.ToInt32(staffID);
                sql += $" and staffID = {id}";
            }
            if (staffName != "")
            {
                sql += $" and staffName like '%{staffName}%'";
            }
            if (staffIDCard != "")
            {
                sql += $" and staffIDCard like '%{staffIDCard}%'";
            }
            if (staffSex != "")
            {
                sql += $" and staffSex like '%{staffSex}%'";
            }
            if (staffAge != "")
            {
                int age = Convert.ToInt32(staffAge);
                sql += $" and staffAge = {age}";
            }
            if (phone != "") {
                sql += $" and phone like '%{phone}%'";
            }
            DataTable dataTable = DbHelper.GetDataTable(sql);
            return dataTable;
        }
        #endregion
        #region 修改员工信息
        public int ChangeStaffInfo(StaffInfos staffInfo) { 
            List<MySqlParameter> list = new List<MySqlParameter>();
            string sql = null;
            if (staffInfo.staffID != 0) {
                sql = string.Format($"update staffinfo set staffID = {staffInfo.staffID}");
                list.Add(new MySqlParameter("staffID",staffInfo.staffID));
                if (staffInfo.staffName != "") {
                    sql += $",staffName = '{staffInfo.staffName}'";
                    list.Add(new MySqlParameter("staffName",staffInfo.staffName));
                }
                if (staffInfo.staffIDCard != "") {
                    sql += $",staffIDCard = '{staffInfo.staffIDCard}'";
                    list.Add(new MySqlParameter("staffIDCard",staffInfo.staffIDCard));
                }
                if (staffInfo.staffSex != "") {
                    sql += $",staffSex = '{staffInfo.staffSex}'";
                    list.Add(new MySqlParameter("staffSex",staffInfo.staffSex));
                }
                if (staffInfo.staffAge != 0) { 
                    sql += $",staffAge = {staffInfo.staffAge}";
                    list.Add(new MySqlParameter("staffAge",staffInfo.staffAge));
                }
                if (staffInfo.phone != "") {
                    sql += $",phone = '{staffInfo.phone}'";
                    list.Add(new MySqlParameter("phone",staffInfo.phone));
                }
                sql += $" where staffID = {staffInfo.staffID}";
                
            }
            int v = DbHelper.CUD(sql, list);
            return v;
        }
        #endregion
    }
}
