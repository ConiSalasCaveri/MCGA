using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using Microsoft.AspNet.Identity;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class AgendaController : Controller
    {
        private AgendaProcess component = new AgendaProcess();
        private TipoDiaProcess tipoDiaComponent = new TipoDiaProcess();


        // GET: Masters/Agenda
        public ActionResult Index()
        {            
            return View(component.Get());
        }

        // GET: Masters/Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenda = component.GetDetail(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: Masters/Agenda/Create
        public ActionResult Create()
        {
            ViewBag.TipoDiaId = new SelectList(tipoDiaComponent.SelectList(), "Id", "descripcion");
            return View();
        }

        // POST: Masters/Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EspecialidadProfesionalId,TipoDiaId,fecha_desde,fecha_hasta,hora_desde,hora_hasta,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                agenda.createdby = User.Identity.GetUserId();
                component.Create(agenda);
                return RedirectToAction("Index");
            }

            ViewBag.TipoDiaId = new SelectList(tipoDiaComponent.SelectList(), "Id", "descripcion", agenda.TipoDiaId);
            return View(agenda);
        }

        // GET: Masters/Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenda = component.GetDetail(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDiaId = new SelectList(tipoDiaComponent.SelectList(), "Id", "descripcion", agenda.TipoDiaId);
            return View(agenda);
        }

        // POST: Masters/Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EspecialidadProfesionalId,TipoDiaId,fecha_desde,fecha_hasta,hora_desde,hora_hasta,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                agenda.changedby = User.Identity.GetUserId();
                component.Update(agenda);
                return RedirectToAction("Index");
            }
            ViewBag.TipoDiaId = new SelectList(tipoDiaComponent.SelectList(), "Id", "descripcion", agenda.TipoDiaId);
            return View(agenda);
        }

        // GET: Masters/Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenda = component.GetDetail(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Masters/Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var agenda = component.GetDetail(id);
            agenda.deletedby = User.Identity.GetUserId();
            component.Delete(agenda);
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
