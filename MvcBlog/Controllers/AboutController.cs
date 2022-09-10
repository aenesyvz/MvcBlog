using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var value = aboutManager.GetList();
            return View(value);
        }
        public PartialViewResult Footer()
        {
            var value = aboutManager.GetList();

            return PartialView(value);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
            var value = authorManager.GetList();
            return PartialView(value);
        }
        [HttpGet]
        public ActionResult UpdateAbout()
        {
            var value = aboutManager.GetList();
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            aboutManager.Update(about);
            return RedirectToAction("UpdateAbout");
        }
    }
}