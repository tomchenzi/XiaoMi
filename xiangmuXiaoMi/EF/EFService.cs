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
        public static UserInfo GetUserInfo(string sql)
        {
            DataTable dt = MysqlHelper.ExecuteTable(sql);
            UserInfo s1 = new UserInfo();
            foreach (DataRow row in dt.Rows)
            {

                s1.UserName = row["UserName"].ToString();
                s1.pwd = row["pwd"].ToString();
                s1.UserID = int.Parse(row["UserID"].ToString());
                s1.Email= row["Email"].ToString();
                s1.age = int.Parse(row["age"].ToString());
            }
            return s1;

        }
    }
}