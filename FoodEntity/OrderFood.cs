using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEntity
{
    public class OrderFood
    {
        public int foodID { get; set; }
        public string foodName { get; set; }
        public double foodPrice { get; set; }
        public string staff {  get; set; }
        public string remark {  get; set; }
        public int desk_id {  get; set; } 
        public int number {  get; set; }
    }
}
