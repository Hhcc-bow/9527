using FoodDll;
using FoodEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBLL
{
    public class StaffBLL
    {
        StaffInfoDAL dal = new StaffInfoDAL();
        public List<StaffInfos> GetStaffName() { 
            return dal.GetStaffName();
        }
        public int GetStaffInfo(int staffID, string staffName, string staffIDCard, string staffSex, int staffAge, string phone) {
            return dal.SetStaffInfo(staffID, staffName, staffIDCard, staffSex, staffAge, phone);
        }
        public int DeleteStaffInfo(int staffID) {
            return dal.DeleteStaffInfo(staffID);
        }

        public DataTable GetStaffInfo() { 
            return dal.GetStaffInfo();
        }

        public DataTable SelectStaffInfo(string staffID, string staffName, string staffIDCard, string staffSex, string staffAge, string phone) {
            return dal.SelectStaffInfo(staffID,staffName,staffIDCard,staffSex,staffAge,phone);
        }
        public int ChangeStaffInfo(StaffInfos staffInfo) {
            return dal.ChangeStaffInfo(staffInfo);
        }
    }
}
