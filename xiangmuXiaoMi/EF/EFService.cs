using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using test_mysql.Models;

namespace test_mysql.EF
{
    public class EFService
    {
        public static student GetStudent(string sql)
        {
            DataTable dt = MysqlHelper.ExecuteTable(sql);
            student s1 = new student();
            foreach (DataRow row in dt.Rows)
            {

                s1.Name = row["name"].ToString();
                s1.Pwd = row["pwd"].ToString();
                s1.Id = int.Parse(row["id"].ToString());

            }
            return s1;

        }
    }
}