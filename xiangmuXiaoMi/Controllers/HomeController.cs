﻿using System;
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
        
      
     [HttpPost]
        public string Index(string search)
        {
            string sql = $"select * from UserInfo where UserName like '{search}%'";
            var dt = test_mysql.Models.MysqlHelper.ExecuteScalar(sql);
            //if (dt.Columns.Count >= 5)
            //{
            //    return Content("<script>alert('dasdsda')</script>");
            //}
            //else
            //{
            //    return Content("<script>alert('11111')</script>");
            //}
            if (dt == null)
            {
                return "失败";
            }
            else
            {
                return "成功";
            }
        }
        public ActionResult Index()
        {

            //var x = test_mysql.Models.MysqlHelper.ExecuteNonQuery("INSERT INTO `test`.`student`( `name`) VALUES ( 'shab五');");
            return View();
        }
        [HttpPost]
        //要改成string 
        public int user_login(string UserName,string pwd) {
            
            string sql = $"SELECT `⁯UserID` FROM `UserInfo` where UserName='{UserName}' and pwd='{pwd}'";
            var dt = test_mysql.Models.MysqlHelper.ExecuteScalar(sql);
            if (dt==null)
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
            UserInfo s1 = EFService.GetUserInfo($"SELECT * FROM `UserInfo` where UserID={id}");
            return Newtonsoft.Json.JsonConvert.SerializeObject(s1);
        }
       
        public ActionResult user_register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult user_register(string uname,string email,int age,string upwd) {
            
            string sql = $"INSERT INTO `XiaoMiDB`.`UserInfo`(`UserName`, `pwd`, `age`, `Email`) VALUES ('{uname}', '{upwd}', {age}, '{email}');";
            var dt = test_mysql.Models.MysqlHelper.ExecuteNonQuery(sql);
            return Content("<script>alert('注册成功')</script>");
        }
      
    }
}