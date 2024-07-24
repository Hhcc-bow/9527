using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FoodEntity;
using MySql.Data.MySqlClient;

namespace FoodDll
{
    public class FoodInfoDAL
    {
        #region 查找菜品的种类
        public List<FoodType> AddParent() {
            List<FoodType> foodTypes = new List<FoodType>();
            string sql = "select foodTypeID,foodType from foodtype;";
            MySqlDataReader mySqlDataReader = DbHelper.GetDataReader(sql);
            while (mySqlDataReader.Read()) {
                foodTypes.Add(new FoodType
                {
                    foodTypeID = mySqlDataReader.GetInt32("foodTypeID"),
                    foodType = mySqlDataReader.GetString("foodType")
                });
            }
            return foodTypes;
        }
        #endregion

        #region 查找菜单中菜品的名字
        public List<FoodInfo> AddChildren(int pid) { 
            List<FoodInfo> foodInfos = new List<FoodInfo>();
            string sql = $"select foodName ,foodType_foodTypeID,foodTypeID, foodtype.foodType from foodinfo join foodtype on foodinfo.foodType_foodTypeID = foodtype.foodTypeID where foodType_foodTypeID = {pid}; ";
            MySqlDataReader mySqlDataReader = DbHelper.GetDataReader(sql);
            while (mySqlDataReader.Read()) {
                foodInfos.Add(new FoodInfo
                {
                    foodType_foodTypeID = mySqlDataReader.GetInt32("foodType_foodTypeID"),
                    foodName = mySqlDataReader.GetString("foodName")
                });
            }
            return foodInfos;
        }
        #endregion

        #region 查找菜品的名字、编号和价格
        public List<FoodInfo> SelectFood() {
            List<FoodInfo> foodInfos = new List<FoodInfo>();
            string sql = string.Format(@"select foodID,foodName,foodPrice from foodinfo");
            MySqlDataReader mySqlDataReader = DbHelper.GetDataReader(sql);
            while (mySqlDataReader.Read()) {
                foodInfos.Add(new FoodInfo {
                    foodID = Convert.ToInt32(mySqlDataReader["foodID"]),
                    foodName = mySqlDataReader["foodName"].ToString(),
                    foodPrice = Convert.ToInt32(mySqlDataReader["foodPrice"])
                });
            }
            return foodInfos;
        }
        #endregion
    }
}
