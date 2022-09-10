using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author author )
        {
            Context context = new Context();
            var value = context.Authors.FirstOrDefault(x => x.Mail == author.Mail && x.Password == author.Password);
            if(value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Mail, false);
                Session["Mail"] = value.Mail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin");
            }
           
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            Context context = new Context();
            var value = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["UserName"] = value.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }

        }
    }
}