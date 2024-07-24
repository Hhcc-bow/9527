using FoodEntity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodDll
{
    public class DeskUiInfoDAL
    {
        public List<DeskUiInfo> SelectUiInfo(DeskUiInfo searchCriteria)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            List<DeskUiInfo> resultList = new List<DeskUiInfo>();
            string sql = "SELECT * FROM desk WHERE 1 = 1";

            if (!string.IsNullOrEmpty(searchCriteria.Name))
            {
                sql += " AND desk_name = @Name";
                parameters.Add(new MySqlParameter("@Name", searchCriteria.Name));
            }
            if (searchCriteria.Id != 0)
            {
                sql += " AND desk_id = @Id";
                parameters.Add(new MySqlParameter("@Id", searchCriteria.Id));
            }
            if (!string.IsNullOrEmpty(searchCriteria.Type))
            {
                sql += " AND desk_type = @Type";
                parameters.Add(new MySqlParameter("@Type", searchCriteria.Type));
            }
            if (!string.IsNullOrEmpty(searchCriteria.Position))
            {
                sql += " AND desk_position = @Position";
                parameters.Add(new MySqlParameter("@Position", searchCriteria.Position));
            }
            if (!string.IsNullOrEmpty(searchCriteria.Notes))
            {
                sql += " AND desk_notes = @Notes";
                parameters.Add(new MySqlParameter("@Notes", searchCriteria.Notes));
            }
            if (searchCriteria.Fee != 0)
            {
                sql += " AND desk_fee = @Fee";
                parameters.Add(new MySqlParameter("@Fee", searchCriteria.Fee));
            }

            DataTable dt = DbHelper.GetDataTable(sql, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DeskUiInfo deskInfo = new DeskUiInfo();

                    deskInfo.Id = dr["desk_id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["desk_id"]);
                    deskInfo.Name = dr["desk_name"] == DBNull.Value ? null : dr["desk_name"].ToString();
                    deskInfo.Type = dr["desk_type"] == DBNull.Value ? null : dr["desk_type"].ToString();
                    deskInfo.Position = dr["desk_position"] == DBNull.Value ? null : dr["desk_position"].ToString();
                    deskInfo.Notes = dr["desk_notes"] == DBNull.Value ? null : dr["desk_notes"].ToString();
                    deskInfo.Fee = dr["desk_fee"] == DBNull.Value ? 0 : Convert.ToInt32(dr["desk_fee"]);

                    resultList.Add(deskInfo);
                }
            }

            return resultList;
        }
        public int UpdateUiInfo(DeskUiInfo deskUiinfo)
        {
            List<MySqlParameter> list = new List<MySqlParameter>();
            string sql = null;
            if (deskUiinfo.Id != 0)
            {
                sql = "update desk set where desk_id=@Id";
                sql = sql.Insert(sql.IndexOf("set") + 4, "desk_id = @Id ");
                list.Add(new MySqlParameter("Id", deskUiinfo.Id));
                if (!string.IsNullOrEmpty(deskUiinfo.Name))
                {
                    sql = sql.Insert(sql.IndexOf("set") + 4, "desk_name = @Name, ");
                    list.Add(new MySqlParameter("Name", deskUiinfo.Name));
                }
                if (!string.IsNullOrEmpty(deskUiinfo.Type))
                {
                    sql = sql.Insert(sql.IndexOf("set") + 4, "desk_type = @Type,");
                    list.Add(new MySqlParameter("Type", deskUiinfo.Type));
                }
                if (!string.IsNullOrEmpty(deskUiinfo.Position))
                {
                    sql = sql.Insert(sql.IndexOf("set") + 4, "desk_Position= @Position,");
                    list.Add(new MySqlParameter("Position", deskUiinfo.Position));
                }
                if (!string.IsNullOrEmpty(deskUiinfo.Notes))
                {
                    sql = sql.Insert(sql.IndexOf("set") + 4, " desk_Notes = @Notes,");
                    list.Add(new MySqlParameter("Notes", deskUiinfo.Notes));
                }
                if (deskUiinfo.Fee != 0)
                {
                    sql = sql.Insert(sql.IndexOf("set") + 4, "desk_fee = @Fee,");
                    list.Add(new MySqlParameter("Fee", deskUiinfo.Fee));
                }
            }
            int a = DbHelper.CUD(sql, list);
            return a;
        }
        public int DeleteUiInfo(DeskUiInfo deskUiinfo)
        {
            List<MySqlParameter> list = new List<MySqlParameter>();
            string sql = null;
            if (deskUiinfo.Id != 0)
            {
                sql = "delete from desk where desk_id=@Id";
                list.Add(new MySqlParameter("Id", deskUiinfo.Id));
            }
            int a = DbHelper.CUD(sql, list);
            return a;
        }
        public int InsertUiInfo(DeskUiInfo deskUiinfo)
        {
            string sql = "insert into desk (desk_id) value (@Id)";
            List<MySqlParameter> list = new List<MySqlParameter>();
            if (deskUiinfo.Id != 0)
            {
                list.Add(new MySqlParameter("Id", deskUiinfo.Id));
                if (!string.IsNullOrEmpty(deskUiinfo.Name))
                {
                    sql = sql.Insert(sql.IndexOf("(") + 1, "desk_name,");
                    sql = sql.Insert(sql.LastIndexOf("(") + 1, "@Name,");
                    list.Add(new MySqlParameter("Name", deskUiinfo.Name));
                }
                if (!string.IsNullOrEmpty(deskUiinfo.Type))
                {
                    sql = sql.Insert(sql.IndexOf("(") + 1, "desk_type,");
                    sql = sql.Insert(sql.LastIndexOf("(") + 1, "@Type,");
                    list.Add(new MySqlParameter("Type", deskUiinfo.Type));
                }
                if (!string.IsNullOrEmpty(deskUiinfo.Position))
                {
                    sql = sql.Insert(sql.IndexOf("(") + 1, "desk_position,");
                    sql = sql.Insert(sql.LastIndexOf("(") + 1, "@Position,");
                    list.Add(new MySqlParameter("Position", deskUiinfo.Position));
                }
                if (!string.IsNullOrEmpty(deskUiinfo.Notes))
                {
                    sql = sql.Insert(sql.IndexOf("(") + 1, "desk_notes,");
                    sql = sql.Insert(sql.LastIndexOf("(") + 1, "@Notes,");
                    list.Add(new MySqlParameter("Notes", deskUiinfo.Notes));
                }
                if (deskUiinfo.Fee != 0)
                {
                    sql = sql.Insert(sql.IndexOf("(") + 1, "desk_fee,");
                    sql = sql.Insert(sql.LastIndexOf("(") + 1, "@Fee,");
                    list.Add(new MySqlParameter("Fee", deskUiinfo.Fee));
                }
            }
            int a = DbHelper.CUD(sql, list);
            return a;
        }
    }
}
