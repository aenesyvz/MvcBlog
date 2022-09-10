using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var value = blogManager.GetList().ToPagedList(page,6);
            return PartialView(value);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPosts()
        {
            var postTitle1 = blogManager.GetList().OrderByDescending(z=>z.BlogId).Where(x => x.Category.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage1 = blogManager.GetList().OrderByDescending(z=>z.BlogId).Where(x => x.Category.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postDate1 = blogManager.GetList().OrderByDescending(z=>z.BlogId).Where(x => x.Category.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();
            var postId1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 1).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.postTitle1 = postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.postDate1 = postDate1;
            ViewBag.postId1 = postId1;

            var postTitle2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postDate2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 2).Select(y => y.BlogDate).FirstOrDefault();
            var postId2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 2).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.postDate2 = postDate2;
            ViewBag.postId2 = postId2;

            var postTitle3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postDate3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();
            var postId3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 3).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.postDate3 = postDate3;
            ViewBag.postId3 = postId3;

            var postTitle4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postDate4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();
            var postId4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 4).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.postDate4 = postDate4;
            ViewBag.postId4 = postId4;

            var postTitle5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postDate5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 5).Select(y => y.BlogDate).FirstOrDefault();
            var postId5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.Category.CategoryId == 5).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.postDate5 = postDate5;
            ViewBag.postId5 = postId5;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeatured()
        {
            return PartialView();
        }
        /*public PartialViewResult MailSubscribe()
        {
            return PartialView();
        }*/
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var value = blogManager.GetBlogById(id);
            return PartialView(value);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var value = blogManager.GetBlogById(id);
            return PartialView(value);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var value = blogManager.GetBlogByCategory(id);
            var category = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            var description = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.category = category;
            ViewBag.description = description;
            return View(value);
        }
        public ActionResult AdminBlogList()
        {
            var blogList = blogManager.GetList();
            return View(blogList);
        }
        public ActionResult AdminBlogList2()
        {
            var blogList = blogManager.GetList();
            return View(blogList);
        }
        [Authorize(Roles ="A")]
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.GetById(id);
            blogManager.Delete(blog);
            return RedirectToAction("AdminBlogList");
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
            return RedirectToAction("AdminBlogList");
        }
        [AllowAnonymous]
        public ActionResult GetCommentByBlog(int id)
        {
            
            var values = commentManager.CommentByBlog(id);
            return View(values);
        }
        
        public ActionResult AuthorBlogList(int id)
        {
            var value = blogManager.GetBlogByAuthor(id);
            return View(value);
        }
    }
}