using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.Entity;

namespace test_mysql.Models
{
    public class student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        
    }
}