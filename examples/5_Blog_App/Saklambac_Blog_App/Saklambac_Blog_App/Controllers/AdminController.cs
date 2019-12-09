using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Saklambac.NetCore.Database;
using Saklambac_Blog_App.Models;

namespace Saklambac_Blog_App.Controllers
{
    public class AdminController : Controller
    {

        SaklambacDb<Blog> blogDb = new SaklambacDb<Blog>();



        /* LIST ALL BLOG POSTS */
        public IActionResult Index()
        {
            var blogs = blogDb.GetAll();
            return View(blogs);
        }



        /* ADD NEW BLOG POST */
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            blogDb.Add(blog);
            return RedirectToAction("Index", "Admin");
        }



        /* UPDATE BLOG POST */
        public IActionResult Update(string Id)
        {
            var blog = blogDb.GetOneById(Id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult Update(string Id, Blog blog)
        {
            var updateBlog = blogDb.GetOneById(Id);
            blogDb.Update(updateBlog, blog);
            return RedirectToAction("Index", "Admin");
        }



        /* DELETE BLOG POST */
        public IActionResult Delete(string Id)
        {
            var blog = blogDb.GetOneById(Id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult Delete(string Id, Blog blog)
        {
            blogDb.Delete(blog);
            return RedirectToAction("Index", "Admin");
        }



        /* LIST ALL BLOG POSTS */
        public IActionResult Statistics()
        {
            ViewBag.BlogPostsCount = blogDb.GetAll().Count;
            return View();
        }

    }
}