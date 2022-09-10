using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpGet]

        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            ContactValidator validationRules = new ContactValidator();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {
                c.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contactManager.Add(c);
                return RedirectToAction("Index","Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            
            return View();
        }
        public ActionResult SendBox()
        {
            var value = contactManager.GetList();
            return View(value);
        }
        public ActionResult MessageDetails(int id)
        {
            var value = contactManager.GetById(id);
            return View(value);
        }
    }
}