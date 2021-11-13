using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TB181979_Desafio03.Models;

namespace TB181979_Desafio03.Controllers
{
    public class pedidoesController : Controller
    {
        private tienda db = new tienda();

        // GET: pedidoes
        public ActionResult Index()
        {
            var pedido = db.pedido.Include(p => p.clientes).Include(p => p.productos);
            return View(pedido.ToList());
        }

        // GET: pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.clientesId = new SelectList(db.cliente,"id", "nombres");
            ViewBag.productosId = new SelectList(db.producto, "id", "NombreProducto");
            return View();
        }

        // POST: pedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,clientesId,productosId")] pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientesId = new SelectList(db.cliente, "id", "nombres", pedido.clientes);
            ViewBag.productosId = new SelectList(db.producto, "id", "NombreProducto", pedido.productos);
            return View(pedido);
        }

        // GET: pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientesId = new SelectList(db.cliente, "id", "nombres", pedido.clientes);
            ViewBag.productosId = new SelectList(db.producto, "id", "NombreProducto", pedido.productos);
            return View(pedido);
        }

        // POST: pedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,clientesId,productosId")] pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientesId = new SelectList(db.cliente, "id", "nombres", pedido.clientes);
            ViewBag.productosId = new SelectList(db.producto, "id", "NombreProducto", pedido.productos);
            return View(pedido);
        }

        // GET: pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pedido pedido = db.pedido.Find(id);
            db.pedido.Remove(pedido);
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
