using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using MCGA.WebSite.Models;
using PagedList;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class ProfesionalEspecialidadController : Controller
    {
        private ProfesionalEspecialidadProcess process = new ProfesionalEspecialidadProcess();
        private ProfesionalProcess profesionalProcess = new ProfesionalProcess();

        // GET: Masters/ProfesionalEspecialidad
        public ActionResult Index()
        {         
            return View(process.Get().ToList());
        }

        // GET: Masters/ProfesionalEspecialidad/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Profesional profesional = db.Profesionals.Find(id);
            //if (profesional == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: Masters/ProfesionalEspecialidad/Create
        public ActionResult Create()
        {
            //ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumentoes, "Id", "descripcion");
            return View();
        }

        // POST: Masters/ProfesionalEspecialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Profesional profesional)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Profesionals.Add(profesional);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumentoes, "Id", "descripcion", profesional.TipoDocumentoId);
            return View();
        }

        // GET: Masters/ProfesionalEspecialidad/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Profesional profesional = db.Profesionals.Find(id);
            //if (profesional == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumentoes, "Id", "descripcion", profesional.TipoDocumentoId);
            return View();
        }

        // POST: Masters/ProfesionalEspecialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Profesional profesional)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(profesional).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumentoes, "Id", "descripcion", profesional.TipoDocumentoId);
            return View();
        }

        // GET: Masters/ProfesionalEspecialidad/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Profesional profesional = db.Profesionals.Find(id);
            //if (profesional == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Masters/ProfesionalEspecialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Profesional profesional = db.Profesionals.Find(id);
            //db.Profesionals.Remove(profesional);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        public ActionResult ListaTurnos(int estudioId)
        {
            IEnumerable<ProfesionalDummy> profesionals = profesionalProcess.GetByEspecialidad(estudioId);            
            return View(profesionals);
        }

        public JsonResult GetProfesionales(string Areas, string term)
        {
            var lista = profesionalProcess.GetAutocomplete(term);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}
