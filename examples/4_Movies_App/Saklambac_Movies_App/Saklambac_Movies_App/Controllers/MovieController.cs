using Saklambac.NetFramework.Database;
using Saklambac_Movies_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saklambac_Movies_App.Controllers
{
    public class MovieController : Controller
    {

        SaklambacDb<Movie> movieDb = new SaklambacDb<Movie>();



        public ActionResult Detail(string Id)
        {
            return View(movieDb.GetOneById(Id));
        }



        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            movieDb.Add(movie);
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Update(string Id)
        {
            return View(movieDb.GetOneById(Id));
        }

        [HttpPost]
        public ActionResult Update(string Id, Movie movie)
        {
            var updateMovie = movieDb.GetOneById(Id);
            movieDb.Update(updateMovie, movie);
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Delete(string Id)
        {
            return View(movieDb.GetOneById(Id));
        }

        [HttpPost]
        public ActionResult Delete(string Id, Movie movie)
        {
            movieDb.Delete(movie);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Search(string movieName)
        {
            var movies = movieDb.GetAll().Where(x => x.Name.Contains(movieName)).ToList();
            return View(movies);
        }

    }
}