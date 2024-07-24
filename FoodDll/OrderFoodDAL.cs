using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDll
{
    public class OrderFoodDAL
    {
        #region 添加选择的菜品
        public int AddOrder(string foodName,int foodID,double foodPrice,string staff,string remark,int desk_id,int number) {
            string sql = string.Format($"insert into orderfood(foodName,foodID,foodPrice,staff,remark,desk_id,number) values('{foodName}',{foodID},{foodPrice},'{staff}','{remark}',{desk_id},{number})");
            int v = DbHelper.CUD(sql);
            return v;
        }
        #endregion

        #region 删除选择的菜品
        public int DeleteOrder(string foodName, int foodID, double foodPrice, string staff, string remark,int desk_id,int number) {
            string sql = string.Format($"delete from orderfood where foodName = '{foodName}' and foodID = {foodID} and foodPrice = {foodPrice} and staff = '{staff}' and remark = '{remark}' and desk_id = {desk_id} and number = {number}");
            int v = DbHelper.CUD(sql);
            return v;
        }
        #endregion

        #region 显示选择的菜品信息
        public DataTable GetOrder(int desk_id) {
            string sql = string.Format($"select * from orderfood where desk_id = {desk_id}");
            DataTable dataTable = DbHelper.GetDataTable(sql);
            return dataTable;
        }
        public void  DeleteOrder(int desk_id)
        {
            string sql = $"delete from orderfood where desk_id = {desk_id}";
            DbHelper.CUD(sql);
        }
        #endregion
    }
}
