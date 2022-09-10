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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var value = categoryManager.GetList();
            return View(value);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var value = categoryManager.GetList();
            return PartialView(value);
        }
        public ActionResult AdminCategoryList()
        {
            var value = categoryManager.GetAll();
            return View(value);
        }
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                categoryManager.Add(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            Category category = categoryManager.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                categoryManager.Update(p);
                return RedirectToAction("AdminCategoryList");
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
        public ActionResult DeleteCategory(int id)
        {
            categoryManager.CategoryStatusFalseBL(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryStatusTrue(int id)
        {
            categoryManager.CategoryStatusTrueBL(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}