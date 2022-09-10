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
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var value = blogManager.GetBlogById(id);

            return PartialView(value);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var value = blogManager.GetList().Where(x => x.BlogId == id).Select(y=>y.AuthorId).FirstOrDefault();
           
            var blogs = blogManager.GetBlogByAuthor(value);
            return PartialView(blogs);
        }
        public ActionResult AuthorList()
        {
            var value = authorManager.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            AuthorValidator validationRules = new AuthorValidator();
            ValidationResult result = validationRules.Validate(author);
            if (result.IsValid)
            {
                authorManager.Add(author);
                return RedirectToAction("AuthorList");
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
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authorManager.GetById(id);


            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            AuthorValidator validationRules = new AuthorValidator();
            ValidationResult result = validationRules.Validate(author);
            if (result.IsValid)
            {
                authorManager.Update(author);
                return RedirectToAction("AuthorList");
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
    }
}