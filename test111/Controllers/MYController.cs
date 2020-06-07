using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test111.Controllers
{
    public class MYController : Controller
    {
        // GET: MY
        private MovieDBContext db = new MovieDBContext();
        public ActionResult Index(String movieGenre, String searchString)
        {
            /*获取Movie表中的’电影类型’数据，并将其封装在ViewBag中，给视图中的下拉列表使用*/
            var genreList = new List<String>();
            var genreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;
            genreList.AddRange(genreQry.Distinct());
            ViewBag.movieGenre = new SelectList(genreList);

            //获取Movie表中全部数据
            var movies = from m in db.Movies
                         select m;

            //判断参数是否有值，第一次请求参数是空的，所以就显示全部数据；当执行搜索后，表单会把两个参数传过来，就可以对数据过滤了；
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            //将封装好的数据传给视图
            return View(movies);
        }
    }
    }

   