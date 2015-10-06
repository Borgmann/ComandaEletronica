using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComandaEletronica.Models;

namespace ComandaEletronica.Controllers
{
    public class ConfigController : Controller
    {
        private DbComandaEntities db = new DbComandaEntities();

        //
        // GET: /Config/

        public ActionResult Index()
        {
            return View(db.Config.ToList());
        }

        //
        // GET: /Config/Details/5

        public ActionResult Details(int id = 0)
        {
            Config config = db.Config.Find(id);
            if (config == null)
            {
                return HttpNotFound();
            }
            return View(config);
        }

        //
        // GET: /Config/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Config/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Config config)
        {
            if (ModelState.IsValid)
            {
                db.Config.Add(config);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(config);
        }

        //
        // GET: /Config/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Config config = db.Config.Find(id);
            if (config == null)
            {
                return HttpNotFound();
            }
            return View(config);
        }

        //
        // POST: /Config/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Config config)
        {
            if (ModelState.IsValid)
            {
                db.Entry(config).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(config);
        }

        //
        // GET: /Config/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Config config = db.Config.Find(id);
            if (config == null)
            {
                return HttpNotFound();
            }
            return View(config);
        }

        //
        // POST: /Config/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Config config = db.Config.Find(id);
            db.Config.Remove(config);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}