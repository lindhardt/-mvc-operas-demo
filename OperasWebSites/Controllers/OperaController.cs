using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OperasWebSites.Models;
using System.Web.UI;
using OperasWebSites.GeocodeService;
using BingMapsRESTToolkit;

namespace OperasWebSites.Controllers
{
    public class OperaController : Controller
    {
        private OperasDB contextDB = new OperasDB();

        //
        // GET: /Opera/
        [OutputCache( Duration = 600, Location = OutputCacheLocation.Server, VaryByParam ="none")]
        public ActionResult Index()
        {
            return View("Index", contextDB.Operas.ToList());
        }

        public ActionResult Details(int id)
        {
            Opera opera = contextDB.Operas.Find(id);
            if (opera != null)
            {
                LocationCheckerServiceClient client = null;

                Location response = null;

                try
                {
                    client = new LocationCheckerServiceClient();
                    response = client.GetLocation("Copenhagen");

                    var coor = response.GeocodePoints.FirstOrDefault().GetCoordinate();

                    opera.GeocodeResult = "" + coor.Longitude +":" + coor.Latitude;

                }
                catch ( Exception e)
                {
                    opera.GeocodeResult = "Error: " + e.Message;
                }


                return View("Details", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult DetailsByTitle(string title)
        {
            Opera opera = (Opera)(from o in contextDB.Operas
                                  where o.Title == title
                                  select o).FirstOrDefault();
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View("Details", opera);
        }

        [Authorize]
        public ActionResult Create()
        {
            Opera newOpera = new Opera();
            return View("Create", newOpera);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Opera newOpera)
        {
            if (ModelState.IsValid)
            {
                newOpera.CreatedBy = User.Identity.Name;
                contextDB.Operas.Add(newOpera);
                contextDB.SaveChanges();
                Response.RemoveOutputCacheItem(Url.Action("Index"));
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", newOpera);
            }
        }
    }
}
