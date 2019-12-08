using Saklambac.NetFramework.Database;
using Saklambac_Movies_App.Models;
using Saklambac_Movies_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saklambac_Movies_App.Controllers
{
    public class HomeController : Controller
    {

        SaklambacDb<Director> directorDb = new SaklambacDb<Director>();
        SaklambacDb<Movie> movieDb = new SaklambacDb<Movie>();

        public ActionResult Index()
        {
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.NewMovies = movieDb.GetAll().Reverse<Movie>().Take(3).ToList();
            mainViewModel.TopMovies = movieDb.GetAll().OrderByDescending(x => Convert.ToDouble(x.ImdbScore)).Take(3).ToList();
            mainViewModel.TopDirectors = directorDb.GetAll().OrderByDescending(x => Convert.ToDouble(x.Score)).Take(3).ToList();
            return View(mainViewModel);
        }

        public ActionResult Directors()
        {
            var directors = directorDb.GetAll();
            return View(directors);
        }

        public ActionResult Movies()
        {
            var movies = movieDb.GetAll();
            return View(movies);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}