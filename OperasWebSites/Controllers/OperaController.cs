using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OperasWebSites.Models;

namespace OperasWebSites.Controllers
{
    public class OperaController : Controller
    {
        private OperasDB _contextDB = new OperasDB();

        // GET: Opera
        public ActionResult Index()
        {
            return View("Index", _contextDB.Operas.ToList());
        }

        // GET: Opera Details
        public ActionResult Details(int id)
        {
            Opera opera = _contextDB.Operas.Find(id);

            if (opera != null)
            {
                return View("Details", opera);
            }

            return HttpNotFound();
        }

        // GET: Create new Opera
        public ActionResult Create()
        {
            Opera newOpera = new Opera();
            return View("Create", newOpera);
        }

        // POST: Post form for new Opera
        [HttpPost]
        public ActionResult Create( Opera newOpera )
        {
            if( ModelState.IsValid )
            {
                _contextDB.Operas.Add(newOpera);
                _contextDB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", newOpera);
        }
    }
}