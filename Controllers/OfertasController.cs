using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogdOferta.Models;

namespace BlogdOferta.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class OfertasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ofertas
        public ActionResult Index()
        {
            var ofertas = db.Ofertas.Include(o => o.Categorias).Include(o => o.Negocios);
            return View(ofertas.ToList());
        }

        // GET: Ofertas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        // GET: Ofertas/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NomCate");
            ViewBag.NegocioID = new SelectList(db.Negocios, "NegocioID", "NomNeg");
            return View();
        }

        // POST: Ofertas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OfertaID,CategoriaID,NegocioID,DescripcionOfer,ImagenNeg,Precio,Existencia,Porcentaje,Estado,FechaOferInicial,FechaOferFinal")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Ofertas.Add(oferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NomCate", oferta.CategoriaID);
            ViewBag.NegocioID = new SelectList(db.Negocios, "NegocioID", "NomNeg", oferta.NegocioID);
            return View(oferta);
        }

        // GET: Ofertas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NomCate", oferta.CategoriaID);
            ViewBag.NegocioID = new SelectList(db.Negocios, "NegocioID", "NomNeg", oferta.NegocioID);
            return View(oferta);
        }

        // POST: Ofertas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfertaID,CategoriaID,NegocioID,DescripcionOfer,ImagenNeg,Precio,Existencia,Porcentaje,Estado,FechaOferInicial,FechaOferFinal")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "NomCate", oferta.CategoriaID);
            ViewBag.NegocioID = new SelectList(db.Negocios, "NegocioID", "NomNeg", oferta.NegocioID);
            return View(oferta);
        }

        // GET: Ofertas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        // POST: Ofertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oferta oferta = db.Ofertas.Find(id);
            db.Ofertas.Remove(oferta);
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
