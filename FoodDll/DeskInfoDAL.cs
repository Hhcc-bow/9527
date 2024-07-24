using FoodEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDll
{
    public class DeskInfoDAL
    {
        public List<DeskInfo> SelectDeskInfo()
        {
            List<DeskInfo> list = new List<DeskInfo>();

            DataTable dt = DbHelper.GetDataTable("Select * from desk");
            foreach (DataRow dr in dt.Rows)
            {
                DeskInfo deskInfo = new DeskInfo();
                deskInfo.Name = dr["desk_name"] == DBNull.Value ? null : dr["desk_name"].ToString();
                deskInfo.Id = dr["desk_id"] == DBNull.Value ? default(int) : Convert.ToInt32(dr["desk_id"]);
                deskInfo.Type = dr["desk_type"] == DBNull.Value ? null : dr["desk_type"].ToString();
                deskInfo.Fee = dr["desk_fee"] == DBNull.Value ? default(int) : Convert.ToInt32(dr["desk_fee"]);
                deskInfo.Position = dr["desk_position"] == DBNull.Value ? null : dr["desk_position"].ToString();
                deskInfo.Notes = dr["desk_notes"] == DBNull.Value ? null : dr["desk_notes"].ToString();
                list.Add(deskInfo);
            }
            return list;
        }
        public void DeleteDeskInfo(int deskId)
        {
            DbHelper.CUD($"delete form desk where id={deskId}");

        }
    }
}
