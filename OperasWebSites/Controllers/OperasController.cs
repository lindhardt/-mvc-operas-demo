using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OperasWebSites.Models;

namespace OperasWebSites.Controllers
{
    public class OperasController : Controller
    {
        private OperasDB db = new OperasDB();

        // GET: Operas
        public ActionResult Index()
        {
            return View(db.Operas.ToList());
        }

        // GET: Operas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opera opera = db.Operas.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }

            // MVC 4 +
            ViewBag.OperaTitle = opera.Title;

            // MVC 3 -
            ViewData["OperaTitle"] = opera.Title;

            return View(opera);
        }

        // GET: Operas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperaID,Title,Year,Composer")] Opera opera)
        {
            if (ModelState.IsValid)
            {
                db.Operas.Add(opera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opera);
        }

        // GET: Operas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opera opera = db.Operas.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View(opera);
        }

        // POST: Operas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperaID,Title,Year,Composer")] Opera opera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }

        // GET: Operas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opera opera = db.Operas.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View(opera);
        }

        // POST: Operas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = db.Operas.Find(id);
            db.Operas.Remove(opera);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
