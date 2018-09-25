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
    public class TurnoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Masters/Turno
        public ActionResult Index()
        {
            var turnoes = db.Turnoes.Include(t => t.Afiliado);
            return View(turnoes.ToList());
        }

        // GET: Masters/Turno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turnoes.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // GET: Masters/Turno/Create
        public ActionResult Create()
        {
            ViewBag.AfiliadoId = new SelectList(db.Afiliadoes, "Id", "Nombre");
            return View();
        }

        // POST: Masters/Turno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora,AfiliadoId,EspecialidadProfesionalId,reserva,Observaciones,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                db.Turnoes.Add(turno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AfiliadoId = new SelectList(db.Afiliadoes, "Id", "Nombre", turno.AfiliadoId);
            return View(turno);
        }

        // GET: Masters/Turno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turnoes.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AfiliadoId = new SelectList(db.Afiliadoes, "Id", "Nombre", turno.AfiliadoId);
            return View(turno);
        }

        // POST: Masters/Turno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora,AfiliadoId,EspecialidadProfesionalId,reserva,Observaciones,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AfiliadoId = new SelectList(db.Afiliadoes, "Id", "Nombre", turno.AfiliadoId);
            return View(turno);
        }

        // GET: Masters/Turno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turnoes.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // POST: Masters/Turno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turno turno = db.Turnoes.Find(id);
            db.Turnoes.Remove(turno);
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
