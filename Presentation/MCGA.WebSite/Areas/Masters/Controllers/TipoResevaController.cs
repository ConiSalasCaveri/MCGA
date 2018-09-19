﻿using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class TipoResevaController : Controller
    {        
        private TipoReservaProcess component = new TipoReservaProcess();

        // GET: Masters/TipoReseva
        public ActionResult Index()
        {
            return View(component.Get());
        }

        // GET: Masters/TipoReseva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoReseva = component.GetDetail(id);
            if (tipoReseva == null)
            {
                return HttpNotFound();
            }
            return View(tipoReseva);
        }

        // GET: Masters/TipoReseva/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/TipoReseva/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] TipoReseva tipoReseva)
        {
            if (ModelState.IsValid)
            {
                component.Create(tipoReseva);
                return RedirectToAction("Index");
            }

            return View(tipoReseva);
        }

        // GET: Masters/TipoReseva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoReseva = component.GetDetail(id);
            if (tipoReseva == null)
            {
                return HttpNotFound();
            }
            return View(tipoReseva);
        }

        // POST: Masters/TipoReseva/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoReseva tipoReseva)
        {
            if (ModelState.IsValid)
            {
                component.Update(tipoReseva);
                return RedirectToAction("Index");
            }
            return View(tipoReseva);
        }

        // GET: Masters/TipoReseva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoReseva = component.GetDetail(id);
            if (tipoReseva == null)
            {
                return HttpNotFound();
            }
            return View(tipoReseva);
        }

        // POST: Masters/TipoReseva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tipoReseva = component.GetDetail(id);
            component.Delete(tipoReseva);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                component.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
