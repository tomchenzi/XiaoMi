﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_mysql.Models
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string pwd { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
    }
}