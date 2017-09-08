using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperasWebSites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            return View("Index");
        }

        public ActionResult About()
        {
            return View("");
        }

        [HttpGet]
        public PartialViewResult _MyRefresh()
        {
            return PartialView("_MyRefresh");
        }

    }
}
