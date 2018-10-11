using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.WebSite.Models;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class TipoEspecialidadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Masters/TipoEspecialidad
        public ActionResult Index()
        {
            return View(db.TipoEspecialidads.ToList());
        }

        // GET: Masters/TipoEspecialidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEspecialidad tipoEspecialidad = db.TipoEspecialidads.Find(id);
            if (tipoEspecialidad == null)
            {
                return HttpNotFound();
            }
            return View(tipoEspecialidad);
        }

        // GET: Masters/TipoEspecialidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/TipoEspecialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] TipoEspecialidad tipoEspecialidad)
        {
            if (ModelState.IsValid)
            {
                db.TipoEspecialidads.Add(tipoEspecialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEspecialidad);
        }

        // GET: Masters/TipoEspecialidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEspecialidad tipoEspecialidad = db.TipoEspecialidads.Find(id);
            if (tipoEspecialidad == null)
            {
                return HttpNotFound();
            }
            return View(tipoEspecialidad);
        }

        // POST: Masters/TipoEspecialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoEspecialidad tipoEspecialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEspecialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEspecialidad);
        }

        // GET: Masters/TipoEspecialidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEspecialidad tipoEspecialidad = db.TipoEspecialidads.Find(id);
            if (tipoEspecialidad == null)
            {
                return HttpNotFound();
            }
            return View(tipoEspecialidad);
        }

        // POST: Masters/TipoEspecialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEspecialidad tipoEspecialidad = db.TipoEspecialidads.Find(id);
            db.TipoEspecialidads.Remove(tipoEspecialidad);
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
