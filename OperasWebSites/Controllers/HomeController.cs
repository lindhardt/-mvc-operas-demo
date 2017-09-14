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

        public ContentResult getBackground()
        {
            string style;

            if(Session["BackgroundColor"] != null )
            {
                style = String.Format("background-color: {0}", Session["BackgroundColor"]);
            } else
            {
                style = "background-color: #dc9797";
            }

            return Content(style);
        }

        public ActionResult SetBackground(string color)
        {
            Session["BackgroundColor"] = color;
            return View("Index");
        }

    }
}
