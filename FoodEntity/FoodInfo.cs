using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEntity
{
    public class FoodInfo
    {
        public int foodID { get; set; }
        public string foodName { get; set; }
        public int foodType_foodTypeID { get; set; }
        public double foodPrice { get; set; }
    }
}
