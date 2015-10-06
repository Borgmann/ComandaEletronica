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
    public class MesaController : Controller
    {
        private DbComandaEntities db = new DbComandaEntities();

        //
        // GET: /Mesa/

        public ActionResult Index()
        {
            return View(db.Mesa.ToList());
        }

        //
        // GET: /Mesa/Details/5

        public ActionResult Details(int id = 0)
        {
            Mesa mesa = db.Mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        //
        // GET: /Mesa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mesa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                db.Mesa.Add(mesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesa);
        }

        //
        // GET: /Mesa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Mesa mesa = db.Mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        //
        // POST: /Mesa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesa);
        }

        //
        // GET: /Mesa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Mesa mesa = db.Mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        //
        // POST: /Mesa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesa mesa = db.Mesa.Find(id);
            db.Mesa.Remove(mesa);
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