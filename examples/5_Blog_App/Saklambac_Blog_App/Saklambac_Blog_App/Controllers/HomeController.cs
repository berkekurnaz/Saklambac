using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Saklambac.NetCore.Database;
using Saklambac_Blog_App.Models;

namespace Saklambac_Blog_App.Controllers
{
    public class HomeController : Controller
    {

        SaklambacDb<Blog> blogDb = new SaklambacDb<Blog>();

        public IActionResult Index()
        {
            var blogPosts = blogDb.GetAll();
            return View(blogPosts);
        }

        public IActionResult Detail(string Id)
        {
            var blogPost = blogDb.GetOneById(Id);
            return View(blogPost);
        }

    }
}