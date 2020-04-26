using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Forms;

namespace DataConn
{
    class DataBaseSys
    {

        public DataBaseSys() { }

        public static MySqlConnection conn;

        //打开数据库连接
        public static void OpenConn()
        {
            string SqlCon = "server=localhost;user id=root;password = 123456;database=adress";
            conn = new MySqlConnection(SqlCon);
            conn.Open();
        }
        //关闭数据库连接
        public static void CloseConn()
        {
            if (conn.State.ToString().ToLower() == "open")
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //读取数据
        public static MySqlDataReader GetDataReaderValue(string sql, params MySqlParameter[] dic)
        {
            OpenConn();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddRange(dic);
            MySqlDataReader dr = cmd.ExecuteReader();
           
            return dr;
        }
        //返回DataSet
        public static DataSet GetDataSetValue(string sql, string tableName, params MySqlParameter[] dic)
        {
            OpenConn();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddRange(dic);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();           
            da.Fill(ds, tableName);
            CloseConn();
            return ds;
        }
        //返回DataView
        public static DataView GetDataViewValue(string sql, string tableName, params MySqlParameter[] dic)
        {
            OpenConn();
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddRange(dic);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            CloseConn();
            return ds.Tables[0].DefaultView;
        }
        //返回DataTable
        public static DataTable GetDataTableValue(string sql, params MySqlParameter[] dic)
        {
            OpenConn();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddRange(dic);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CloseConn();
            return dt;
        }
        //执行一个Sql操作：添加，删除，更新操作
        public static bool ExecuteNonQuery(string sql, params MySqlParameter[] dic)
        {
            try
            {
                OpenConn();
                MySqlCommand cmd;
                cmd = new MySqlCommand(sql, conn);
               cmd.Parameters.AddRange(dic);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConn();
            }
        }
        //执行一个Sql操作：添加，删除，更新操作，返回受影响行数
        public int ExecuteNonQueryCount(string sql, params MySqlParameter[] dic)
        {
            OpenConn();
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddRange(dic);
            int value = cmd.ExecuteNonQuery();
            return value;
        }
        //执行一条返回第一条记录第一列的SqlCommand命令
        public object ExecuteScalar(string sql, params MySqlParameter[] dic)
        {
            OpenConn();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddRange(dic);
            object value = cmd.ExecuteScalar();
            return value;
        }
        //返回记录数
        public int SqlServerRecordCount(string sql, params MySqlParameter[] dic)
        {
            OpenConn();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.Parameters.AddRange(dic);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            int RecordCount = 0;
            while (dr.Read())
            {
                RecordCount++;
            }
            CloseConn();
            return RecordCount;
        }
        //判断是否为数字
        public static bool GetSafeValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            foreach (char ch in value)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

