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
    public class AtendenteController : Controller
    {
        private DbComandaEntities db = new DbComandaEntities();

        


















        //
        // GET: /Atendente/

        public ActionResult Index()
        {
            return View(db.Atendente.ToList());
        }

        //
        // GET: /Atendente/Details/5

        public ActionResult Details(int id = 0)
        {
            Atendente atendente = db.Atendente.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        //
        // GET: /Atendente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Atendente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                db.Atendente.Add(atendente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atendente);
        }

        //
        // GET: /Atendente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Atendente atendente = db.Atendente.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        //
        // POST: /Atendente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atendente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atendente);
        }

        //
        // GET: /Atendente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Atendente atendente = db.Atendente.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        //
        // POST: /Atendente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atendente atendente = db.Atendente.Find(id);
            db.Atendente.Remove(atendente);
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