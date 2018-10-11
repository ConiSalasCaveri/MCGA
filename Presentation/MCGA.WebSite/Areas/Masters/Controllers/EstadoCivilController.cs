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

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class EstadoCivilController : Controller
    {
        private EstadoCivilProcess process = new EstadoCivilProcess();
        // GET: Masters/EstadoCivil
        public ActionResult Index()
        {
            return View(process.Get());
        }

        // GET: Masters/EstadoCivil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estadoCivil = process.GetDetail(id);
            if (estadoCivil == null)
            {
                return HttpNotFound();
            }
            return View(estadoCivil);
        }

        // GET: Masters/EstadoCivil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/EstadoCivil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
                process.Create(estadoCivil);
                return RedirectToAction("Index");
            }

            return View(estadoCivil);
        }

        // GET: Masters/EstadoCivil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estadoCivil = process.GetDetail(id);
            if (estadoCivil == null)
            {
                return HttpNotFound();
            }
            return View(estadoCivil);
        }

        // POST: Masters/EstadoCivil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
                process.Update(estadoCivil);
                return RedirectToAction("Index");
            }
            return View(estadoCivil);
        }

        // GET: Masters/EstadoCivil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estadoCivil = process.GetDetail(id);
            if (estadoCivil == null)
            {
                return HttpNotFound();
            }
            return View(estadoCivil);
        }

        // POST: Masters/EstadoCivil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var estadoCivil = process.GetDetail(id);
            process.Delete(estadoCivil);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                process.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
