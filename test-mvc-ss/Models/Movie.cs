using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using System.Data.Entity;

namespace test_mvc_ss.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        [Display(Name = "reas Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}",ApplyFormatInEditMode =true)]
        public DateTime reasdata { get; set; }
        public string gren { get; set; }
        public decimal price { get; set; }

    }
    public class MovieDBContext : DbContext
    {
    public DbSet<Movie> Movies { get; set; }
    }
}