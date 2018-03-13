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
    public class NegociosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Negocios
        public ActionResult Index()
        {
            return View(db.Negocios.ToList());
        }

        // GET: Negocios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        // GET: Negocios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Negocios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NegocioID,NomNeg,DomNeg,ImagenNeg,LocalizacionNeg,EstadoNeg")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Negocios.Add(negocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(negocio);
        }

        // GET: Negocios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        // POST: Negocios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NegocioID,NomNeg,DomNeg,ImagenNeg,LocalizacionNeg,EstadoNeg")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(negocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(negocio);
        }

        // GET: Negocios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Negocio negocio = db.Negocios.Find(id);
            db.Negocios.Remove(negocio);
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
