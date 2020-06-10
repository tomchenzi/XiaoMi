using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace test_mysql.Models
{
    public static class MysqlHelper
    {
        private static string connStr = "Server=47.107.64.53;Database=test;Uid=root;Pwd=root;";
        /// <summary>
        /// 返回配置文件中指定的连接
        /// </summary>
        /// <returns>配置文件中指定的连接</returns>
        /// <summary>
        /// 执行增删改sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>受影响行数</returns>
        public static int ExecuteNonQuery(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql,conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
       
       
 
        /// <summary>
        /// 执行sql语句，返回第一行第一列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>第一行第一列</returns>
        public static Object ExecuteScalar(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    try
                    {
                        object i = cmd.ExecuteScalar();
                        return i;
                    }
                    catch (Exception)
                    {

                        return null;
                    }
                    
                }
            }
        }
        

        
        /// <summary>
        /// 执行sql语句，返回一个DataTable（查询）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteTable(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {

                using (MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }

            }
        }
       
    }
}