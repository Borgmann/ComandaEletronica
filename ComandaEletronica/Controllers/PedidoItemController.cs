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
    public class PedidoItemController : Controller
    {
        private DbComandaEntities db = new DbComandaEntities();

        //
        // GET: /PedidoItem/

        public ActionResult Index()
        {
            var pedidoitem = db.PedidoItem.Include(p => p.Pedido).Include(p => p.Produto);
            return View(pedidoitem.ToList());
        }

        //
        // GET: /PedidoItem/Details/5

        public ActionResult Details(int id = 0)
        {
            PedidoItem pedidoitem = db.PedidoItem.Find(id);
            if (pedidoitem == null)
            {
                return HttpNotFound();
            }
            return View(pedidoitem);
        }

        //
        // GET: /PedidoItem/Create

        public ActionResult Create()
        {
            ViewBag.Id_Pedido = new SelectList(db.Pedido, "Id", "Id");
            ViewBag.Id_Produto = new SelectList(db.Produto, "Id", "Nome");
            return View();
        }

        //
        // POST: /PedidoItem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoItem pedidoitem)
        {
            if (ModelState.IsValid)
            {
                db.PedidoItem.Add(pedidoitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Pedido = new SelectList(db.Pedido, "Id", "Id", pedidoitem.Id_Pedido);
            ViewBag.Id_Produto = new SelectList(db.Produto, "Id", "Nome", pedidoitem.Id_Produto);
            return View(pedidoitem);
        }

        //
        // GET: /PedidoItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PedidoItem pedidoitem = db.PedidoItem.Find(id);
            if (pedidoitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Pedido = new SelectList(db.Pedido, "Id", "Id", pedidoitem.Id_Pedido);
            ViewBag.Id_Produto = new SelectList(db.Produto, "Id", "Nome", pedidoitem.Id_Produto);
            return View(pedidoitem);
        }

        //
        // POST: /PedidoItem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoItem pedidoitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Pedido = new SelectList(db.Pedido, "Id", "Id", pedidoitem.Id_Pedido);
            ViewBag.Id_Produto = new SelectList(db.Produto, "Id", "Nome", pedidoitem.Id_Produto);
            return View(pedidoitem);
        }

        //
        // GET: /PedidoItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PedidoItem pedidoitem = db.PedidoItem.Find(id);
            if (pedidoitem == null)
            {
                return HttpNotFound();
            }
            return View(pedidoitem);
        }

        //
        // POST: /PedidoItem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoItem pedidoitem = db.PedidoItem.Find(id);
            db.PedidoItem.Remove(pedidoitem);
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