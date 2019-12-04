using Saklambac.NetFramework.Database;
using Saklambac_Contact_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Saklambac_Contact_App.Controllers
{
    public class HomeController : Controller
    {

        SaklambacDb<Contact> saklambacDb = new SaklambacDb<Contact>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.CreatedDate = DateTime.Now.ToShortDateString();
            saklambacDb.Add(contact);
            return RedirectToAction("Index");
        }

        public ActionResult Messages()
        {
            List<Contact> messages = saklambacDb.GetAll();
            return View(messages);
        }

        public ActionResult Detail(string Id)
        {
            Contact message = saklambacDb.GetOneById(Id);
            return View(message);
        }

        public ActionResult Delete(string Id)
        {
            Contact message = saklambacDb.GetOneById(Id);
            return View(message);
        }

        [HttpPost]
        public ActionResult Delete(Contact contact, FormCollection formCollection)
        {
            saklambacDb.DeleteWithId(contact.Id);
            return RedirectToAction("Messages");
        }

    }
}