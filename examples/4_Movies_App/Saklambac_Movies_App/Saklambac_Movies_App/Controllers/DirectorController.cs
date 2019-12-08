using Saklambac.NetFramework.Database;
using Saklambac_Movies_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saklambac_Movies_App.Controllers
{
    public class DirectorController : Controller
    {

        SaklambacDb<Director> directorDb = new SaklambacDb<Director>();



        public ActionResult Detail(string Id)
        {
            return View(directorDb.GetOneById(Id));
        }



        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Director director)
        {
            directorDb.Add(director);
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Update(string Id)
        {
            return View(directorDb.GetOneById(Id));
        }

        [HttpPost]
        public ActionResult Update(string Id, Director director)
        {
            var updateDirector = directorDb.GetOneById(Id);
            directorDb.Update(updateDirector, director);
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Delete(string Id)
        {
            return View(directorDb.GetOneById(Id));
        }

        [HttpPost]
        public ActionResult Delete(string Id, Director director)
        {
            directorDb.Delete(director);
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public JsonResult GetDirectorsList()
        {
            var directors = directorDb.GetAll();
            return Json(directors, JsonRequestBehavior.AllowGet);
        }

    }
}