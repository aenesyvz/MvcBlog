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
    public class SubscribeMailController : Controller
    {
        // GET: SubscribeMail
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            SubscribeMailManager subscribeMailManager = new SubscribeMailManager(new EfMailDal());
            subscribeMailManager.Add(p);
            return PartialView();
        }
    }
}