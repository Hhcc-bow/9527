using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodEntity;
using FoodDll;
using System.Data;

namespace FoodBLL
{
    public class FoodList
    {
        FoodInfoDAL dal = new FoodInfoDAL();
        OrderFoodDAL orderDal = new OrderFoodDAL();
        public List<FoodType> AddParent() {
            var foodTypes = dal.AddParent();
            foreach (var foodType in foodTypes) {
                foodType.foodInfos = dal.AddChildren(foodType.foodTypeID).ToList();
            }
            return foodTypes;
        }

        public List<FoodInfo> SelectFood() {
            return dal.SelectFood();
        }
        public int OrderFood(string foodName, int foodID, double foodPrice, string staff, string remark,int desk_id,int number) {
            return orderDal.AddOrder( foodName,  foodID,  foodPrice,  staff, remark, desk_id,number);
        }
        public int DeleteOrder(string foodName, int foodID, double foodPrice, string staff, string remark,int desk_id,int number) {
            return orderDal.DeleteOrder(foodName, foodID, foodPrice, staff, remark,desk_id, number);
        }
        public DataTable GetOrder(int desk_id) { 
            return orderDal.GetOrder(desk_id);
        }
        public void  DeleteOrder(int desk_id)
        {
            orderDal.DeleteOrder(desk_id);
        }
    }
}
