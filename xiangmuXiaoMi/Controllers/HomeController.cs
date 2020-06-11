using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using test_mysql.Models;
using test_mysql.EF;

namespace test_mysql.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            //var x = test_mysql.Models.MysqlHelper.ExecuteNonQuery("INSERT INTO `test`.`student`( `name`) VALUES ( 'shab五');");
            return View();
        }
        [HttpPost]
        //要改成string 
        public int user_login(string username, string pwd) {

            string sql = $"SELECT `⁯id` FROM `student` where name='{username}' and pwd='{pwd}'";
            var dt = test_mysql.Models.MysqlHelper.ExecuteScalar(sql);
            if (dt == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            //if (dt.Rows.Count>0)
            //{

            //    student s1 = new student() { Name = username, Pwd = pwd};

            //    return View("~/Views/Home/index.cshtml");
            //        //Newtonsoft.Json.JsonConvert.SerializeObject(s1); /  //  返回用户名称等
            //    //object strid = MysqlHelper.ExecuteScalar("SELECT LAST_INSERT_ID()"); // 找到用户ID
            //}
            //else
            //{

            //    return Content("<script>alert('账号密码错误！'), history.back();</script>");
            //}
            //var x = test_mysql.Models.MysqlHelper.ExecuteNonQuery("INSERT INTO `test`.`student`( `name`) VALUES ( 'username');");
        }
        [HttpGet]
        public ActionResult user_login()
        {
            return View();
        }

        [HttpGet]
        public string getStudentByid(int id)
        {
            student s1 = EFService.GetStudent($"SELECT * FROM `student` where `⁯id`={id}");
            return Newtonsoft.Json.JsonConvert.SerializeObject(s1);
        }

        public ActionResult user_register() {

            return View();
        }
        public ActionResult xiaomi1()
        {
            return View();
        }
        public ActionResult Shopping(){ return PartialView(); }
    }
}