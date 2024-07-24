using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FoodDll
{
    /// <summary>
    /// 数据库辅助类
    /// </summary>
    public  class DbHelper
    {
        //连接字符串
        static string conStr = @"server=localhost;uid=root;pwd=root;database=foodordersystem";
            
            //System.Configuration.ConfigurationManager.ConnectionStrings["foodordersystem"].ToString();
        #region 增、删、改
        /// <summary>
        /// 增、删、改（普通SQL语句）
        /// </summary>
        /// <param name="sql">普通SQL语句</param>
        /// <returns>受影响的行数</returns>
        public static int CUD(string sql) { 
            MySqlConnection conn = null;
            try
            {
                //创建连接对象
                conn = new MySqlConnection(conStr);
                //打开数据连接
                conn.Open();
                //创建命令对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { 
                conn.Close();
            }
        }
        #endregion

        #region 增、删、改（参数化的SQL语句）
        /// <summary>
        /// 增、删、改（参数化的SQL语句）
        /// </summary>
        /// <param name="sql">带@参数的SQL语句</param>
        /// <param name="mySqlParameters">存储mysqlParameter对象的集合</param>
        /// <returns>受影响行数</returns>
        public static int CUD(string sql,List<MySqlParameter> mySqlParameters) {
            MySqlConnection conn = null;
            try
            {
                //创建连接对象
                conn = new MySqlConnection(conStr);
                //打开数据连接
                conn.Open();
                //创建命令对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddRange(mySqlParameters.ToArray());//ToArray()用于将集合转化为数组
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 执行查询操作，返回MysqlDataReader对象
        /// <summary>
        /// 执行查询操作，返回MysqlDataReader对象
        /// </summary>
        /// <param name="sql">普通sql语句</param>
        /// <returns>MysqlDataReader对象</returns>
        public static MySqlDataReader GetDataReader(string sql) {
            try
            {
                MySqlConnection con = new MySqlConnection(conStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                //CommandBehavior.CloseConnection用于设置当MysqlDataReader关闭时会自动关闭连接
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex) { 
                return null;
            }
        }
        #endregion

        #region 执行查询操作，返回MysqlDataReader对象（参数化的SQL语句）
        /// <summary>
        /// 执行查询操作，返回MysqlDataReader对象（参数化的SQL语句）
        /// </summary>
        /// <param name="sql">带@参数的sql语句</param>
        /// <param name="mySqlParameters">存储mysqlParameter对象的集合</param>
        /// <returns>MysqlDataReader对象</returns>
        public static MySqlDataReader GetDataReader(string sql,List<MySqlParameter> mySqlParameters)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddRange(mySqlParameters.ToArray());
                //CommandBehavior.CloseConnection用于设置当MysqlDataReader关闭时会自动关闭连接
                MySqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dataReader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 执行查询操作，返回DataTable对象
        /// <summary>
        /// 执行查询操作，返回DataTable对象
        /// </summary>
        /// <param name="sql">普通sql语句</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetDataTable(string sql) { 
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql,conn);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                return table;
            }
            catch
            {
                return null;
            }
            finally { 
                conn.Close();
            }
        }
        #endregion

        #region 执行查询操作，返回DataTable对象(参数化sql语句)
        /// <summary>
        /// 执行查询操作，返回DataTable对象(参数化sql语句)
        /// </summary>
        /// <param name="sql">带@参数的sql语句</param>
        /// <param name="mySqlParameters">储存MysqlParamete对象的集合</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetDataTable(string sql,List<MySqlParameter> mySqlParameters)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddRange(mySqlParameters.ToArray());
                dataAdapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 执行查询语句，返回第一行第一个单元格中的数据
        /// <summary>
        /// 执行查询语句，返回第一行第一个单元格中的数据
        /// </summary>
        /// <param name="sql">普通sql语句</param>
        /// <returns>返回第一行第一个单元格中的数据</returns>
        public static object GetScalar(string sql) {
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(conStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql,con);
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally { 
            con.Close();
            }
        }
        #endregion

        #region 执行查询语句，返回第一行第一个单元格中的数据（参数化的sql语句）
        /// <summary>
        /// 执行查询语句，返回第一行第一个单元格中的数据（参数化的sql语句）
        /// </summary>
        /// <param name="sql">带@参数的sql语句</param>
        /// <param name="mySqlParameters">储存MysqlParameter对象的集合</param>
        /// <returns>返回第一行第一个单元格中的数据</returns>
        public static object GetScalar(string sql,List<MySqlParameter> mySqlParameters)
        {
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(conStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddRange(mySqlParameters.ToArray());
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
