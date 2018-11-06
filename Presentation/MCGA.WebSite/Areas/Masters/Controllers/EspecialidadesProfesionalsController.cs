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
    public class EspecialidadesProfesionalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Masters/EspecialidadesProfesionals
        public ActionResult Index()
        {
            var especialidadesProfesionals = db.EspecialidadesProfesionals.Include(e => e.Especialidad).Include(e => e.Profesional);
            return View(especialidadesProfesionals.ToList());
        }

        // GET: Masters/EspecialidadesProfesionals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadesProfesional especialidadesProfesional = db.EspecialidadesProfesionals.Find(id);
            if (especialidadesProfesional == null)
            {
                return HttpNotFound();
            }
            return View(especialidadesProfesional);
        }

        // GET: Masters/EspecialidadesProfesionals/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadId = new SelectList(db.Especialidads, "Id", "descripcion");
            ViewBag.ProfesionalId = new SelectList(db.Profesionals, "Id", "Nombre");
            return View();
        }

        // POST: Masters/EspecialidadesProfesionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EspecialidadId,ProfesionalId,createdon,createdby,changedon,changedby")] EspecialidadesProfesional especialidadesProfesional)
        {
            if (ModelState.IsValid)
            {
                db.EspecialidadesProfesionals.Add(especialidadesProfesional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadId = new SelectList(db.Especialidads, "Id", "descripcion", especialidadesProfesional.EspecialidadId);
            ViewBag.ProfesionalId = new SelectList(db.Profesionals, "Id", "Nombre", especialidadesProfesional.ProfesionalId);
            return View(especialidadesProfesional);
        }

        // GET: Masters/EspecialidadesProfesionals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadesProfesional especialidadesProfesional = db.EspecialidadesProfesionals.Find(id);
            if (especialidadesProfesional == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadId = new SelectList(db.Especialidads, "Id", "descripcion", especialidadesProfesional.EspecialidadId);
            ViewBag.ProfesionalId = new SelectList(db.Profesionals, "Id", "Nombre", especialidadesProfesional.ProfesionalId);
            return View(especialidadesProfesional);
        }

        // POST: Masters/EspecialidadesProfesionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EspecialidadId,ProfesionalId,createdon,createdby,changedon,changedby")] EspecialidadesProfesional especialidadesProfesional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidadesProfesional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadId = new SelectList(db.Especialidads, "Id", "descripcion", especialidadesProfesional.EspecialidadId);
            ViewBag.ProfesionalId = new SelectList(db.Profesionals, "Id", "Nombre", especialidadesProfesional.ProfesionalId);
            return View(especialidadesProfesional);
        }

        // GET: Masters/EspecialidadesProfesionals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadesProfesional especialidadesProfesional = db.EspecialidadesProfesionals.Find(id);
            if (especialidadesProfesional == null)
            {
                return HttpNotFound();
            }
            return View(especialidadesProfesional);
        }

        // POST: Masters/EspecialidadesProfesionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EspecialidadesProfesional especialidadesProfesional = db.EspecialidadesProfesionals.Find(id);
            db.EspecialidadesProfesionals.Remove(especialidadesProfesional);
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
