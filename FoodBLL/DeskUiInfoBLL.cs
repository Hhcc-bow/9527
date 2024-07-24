using FoodDll;
using FoodEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL
{
    public class DeskUiInfoBLL
    {
        DeskUiInfoDAL deskUiInfo = new DeskUiInfoDAL();
        public List<DeskUiInfo> SelectUiInfoBLL(DeskUiInfo deskUiinfo)
        {
            return deskUiInfo.SelectUiInfo(deskUiinfo);
        }
        public int UpdateUiInfoBLL(DeskUiInfo deskUiinfo)
        {
            return deskUiInfo.UpdateUiInfo(deskUiinfo);
        }
        public int DeleteUiInfoBLL(DeskUiInfo deskUiinfo)
        {
            return deskUiInfo.DeleteUiInfo(deskUiinfo);
        }
        public int InsertUiInfoBLL(DeskUiInfo deskUiinfo)
        {
            return deskUiInfo.InsertUiInfo(deskUiinfo);
        }
    }
}
