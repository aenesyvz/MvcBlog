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
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var value = commentManager.CommentByBlog(id);
            return PartialView(value);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.Status = true;
            commentManager.Add(c);
            return PartialView();
        }
        public ActionResult AdminCommentListTrue()
        {
            var value = commentManager.CommentByStatusTrue();
            return View(value);
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        public ActionResult AdminCommentListFalse()
        {
            var value = commentManager.CommentByStatusFalse();
            return View(value);
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}