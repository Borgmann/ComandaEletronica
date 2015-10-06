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
    public class PedidoController : Controller
    {
        private DbComandaEntities db = new DbComandaEntities();

        //
        // GET: /Pedido/

        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.Atendente).Include(p => p.Cliente).Include(p => p.Comanda).Include(p => p.Mesa);
            return View(pedido.ToList());
        }

        //
        // GET: /Pedido/Details/5

        public ActionResult Details(int id = 0)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        //
        // GET: /Pedido/Create

        public ActionResult Create()
        {
            ViewBag.Id_Atendente = new SelectList(db.Atendente, "Id", "Nome");
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Telefone");
            ViewBag.Id_Comanda = new SelectList(db.Comanda, "Id", "Id");
            ViewBag.Id_Mesa = new SelectList(db.Mesa, "Id", "Numero");
            return View();
        }

        //
        // POST: /Pedido/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Atendente = new SelectList(db.Atendente, "Id", "Nome", pedido.Id_Atendente);
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Telefone", pedido.Id_Cliente);
            ViewBag.Id_Comanda = new SelectList(db.Comanda, "Id", "Id", pedido.Id_Comanda);
            ViewBag.Id_Mesa = new SelectList(db.Mesa, "Id", "Numero", pedido.Id_Mesa);
            return View(pedido);
        }

        //
        // GET: /Pedido/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Atendente = new SelectList(db.Atendente, "Id", "Nome", pedido.Id_Atendente);
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Telefone", pedido.Id_Cliente);
            ViewBag.Id_Comanda = new SelectList(db.Comanda, "Id", "Id", pedido.Id_Comanda);
            ViewBag.Id_Mesa = new SelectList(db.Mesa, "Id", "Numero", pedido.Id_Mesa);
            return View(pedido);
        }

        //
        // POST: /Pedido/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Atendente = new SelectList(db.Atendente, "Id", "Nome", pedido.Id_Atendente);
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Telefone", pedido.Id_Cliente);
            ViewBag.Id_Comanda = new SelectList(db.Comanda, "Id", "Id", pedido.Id_Comanda);
            ViewBag.Id_Mesa = new SelectList(db.Mesa, "Id", "Numero", pedido.Id_Mesa);
            return View(pedido);
        }

        //
        // GET: /Pedido/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        //
        // POST: /Pedido/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
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