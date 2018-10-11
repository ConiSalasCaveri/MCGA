using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using PagedList;
using Microsoft.AspNet.Identity;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class TurnoController : Controller
    {
        private TurnoProcess process = new TurnoProcess();
        private AfiliadoProcess afiliadoProcess = new AfiliadoProcess();

        // GET: Masters/Turno
        public ActionResult Index()
        {
            return View(process.Get());
        }
        public ActionResult ListBase()
        {
            return View(process.Get().OrderBy(x => x.Fecha).ToList());
        }

        public ActionResult List(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            IEnumerable<Turno> turnos = process.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                turnos = turnos
                    .Where(s => s.Afiliado.Nombre.ToLower().Contains(searchString.ToLower()) ||
                           s.Afiliado.Apellido.ToLower().Contains(searchString.ToLower()));
            }
            turnos = turnos.OrderBy(o => o.Fecha);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(turnos.ToPagedList(pageNumber, pageSize));
        }

        // GET: Masters/Turno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var turno = process.GetDetail(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // GET: Masters/Turno/Create
        public ActionResult Create()
        {
            ViewBag.AfiliadoId = new SelectList(afiliadoProcess.SelectList(), "Id", "Nombre");
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
                turno.createdby = User.Identity.GetUserId();
                process.Create(turno);
                return RedirectToAction("Index");
            }

            ViewBag.AfiliadoId = new SelectList(afiliadoProcess.SelectList(), "Id", "Nombre", turno.AfiliadoId);
            return View(turno);
        }

        // GET: Masters/Turno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var turno = process.GetDetail(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AfiliadoId = new SelectList(afiliadoProcess.SelectList(), "Id", "Nombre", turno.AfiliadoId);
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
                process.Update(turno);
                return RedirectToAction("Index");
            }
            ViewBag.AfiliadoId = new SelectList(afiliadoProcess.SelectList(), "Id", "Nombre", turno.AfiliadoId);
            return View(turno);
        }

        // GET: Masters/Turno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var turno = process.GetDetail(id);
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
            var turno = process.GetDetail(id);
            process.Delete(turno);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            process.Dispose();
        }
    }
}
