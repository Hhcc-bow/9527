using FoodDll;
using FoodEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL
{
    public class DeskInfoBLL
    {
        DeskInfoDAL deskDal = new DeskInfoDAL();
        public List<DeskInfo> SelectDeskInfoBLL()
        {
            return deskDal.SelectDeskInfo();
        }
        public void DeleteDeskInfoBLL(int deskId)
        {
            deskDal.DeleteDeskInfo(deskId);
        }
    }
}
