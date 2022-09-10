using DataAccessLayer.Concrete;
using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeResult()
        {
            return Json(categoryList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult VisualizeResult2()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> categoryList()
        {
            List<Class1> c = new List<Class1>();
            c.Add(new Class1()
            {
                CategoryName = "Teknoloji",
                BlogCount = 14
            });
            c.Add(new Class1()
            {
                CategoryName = "Spor",
                BlogCount = 5
            });
            c.Add(new Class1()
            {
                CategoryName = "Kitap",
                BlogCount = 18
            });
            return c;
        }
        public List<Class2> BlogList()
        {
            List<Class2> cs = new List<Class2>();
            using(var c = new Context())
            {
                cs = c.Blogs.Select(x => new Class2
                {
                    BlogName = x.BlogTitle,
                    Rating = x.BlogRating
                }).ToList();
            }
            return cs;
        }
        public ActionResult Chart1()
        {
            return View();
        }
    }
}