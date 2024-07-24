using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEntity
{
    public class FoodType
    {
        public int foodTypeID { set; get; }
        public string foodType { set; get; }
        public List<FoodInfo> foodInfos { set; get; }
    }
}
