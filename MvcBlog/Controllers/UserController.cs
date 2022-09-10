using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: Login
        UserManager userManager = new UserManager();
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public ActionResult Index()
        {
           
            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var value = userManager.GetAuthorByMail(p);
            return PartialView(value);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userManager.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context context = new Context();
            int id = context.Authors.Where(x => x.Mail == p).Select(y=>y.AuthorId).FirstOrDefault();
            var value = userManager.GetBlogByAuthor(id);
            return View(value);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> authors = (from y in context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = y.AuthorName,
                                                Value = y.AuthorId.ToString()
                                            }).ToList();
            ViewBag.authors = authors;
            Blog blog = blogManager.GetById(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog blog)
        {
            blogManager.Update(blog);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> authors = (from y in context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = y.AuthorName,
                                                Value = y.AuthorId.ToString()
                                            }).ToList();
            ViewBag.authors = authors;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blogManager.Add(blog);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin","Login");
        }
        public ActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.GetById(id);
            blogManager.Delete(blog);
            return RedirectToAction("BlogList");
        }
    }
}