using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using PagedList;
using Microsoft.AspNet.Identity;
using System;
using System.Globalization;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class TurnoController : Controller
    {
        private TurnoProcess process = new TurnoProcess();
        private AfiliadoProcess afiliadoProcess = new AfiliadoProcess();
        private EspecialidadProcess especialidadProcess = new EspecialidadProcess();
        private ProfesionalProcess profesionalProcess = new ProfesionalProcess();

        static int EspecialidadId { get; set; }
        static int ProfesionalId { get; set; }

        // GET: Masters/Turno
        public ActionResult Index()
        {
            return View(process.Get());
        }
        public ActionResult ListBase()
        {
            return View(process.Get().OrderBy(x => x.Fecha).ToList());
        }

        public ActionResult ListaDeTurnos(string currentFilter, string searchString, int? page)
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

        public ActionResult TomarTurno()
        {
            return View("TomarTurno");
        }

        public ActionResult TurnoEstudio()
        {
            return View("TurnoEstudio");
        }

        public ActionResult TurnoProfesional()
        {
            return View("TurnoProfesional");
        }

        public ActionResult ListaTurnos(int estudioId, int? page)
        {
            IEnumerable<ProfesionalDummy> profesionals = profesionalProcess.GetByEspecialidad(estudioId);
            EspecialidadId = estudioId;
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(profesionals.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ListaTurnosEspecialidad(int profesionalId, int? page)
        {
            IEnumerable<EspecialidadDummy> profesionals = especialidadProcess.GetByProfesional(profesionalId);
            ProfesionalId = profesionalId;
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(profesionals.ToPagedList(pageNumber, pageSize));
        }
        //TODO: hacer lo de turnos pero buscando por profesional, que de especialidades
        //public ActionResult ListaTurnosProfesional(int estudioId, int? page)
        //{
        //    IEnumerable<ProfesionalDummy> profesionals = profesionalProcess.GetByEspecialidad(estudioId);
        //    EspecialidadId = estudioId;
        //    int pageSize = 3;
        //    int pageNumber = (page ?? 1);
        //    return View(profesionals.ToPagedList(pageNumber, pageSize));
        //}

        public ActionResult DetalleTurno(int id, bool isProfesional)
        {
            if (isProfesional)
            {
                ProfesionalId = id;
            }
            else {
                EspecialidadId = id;
            }            
            // GET PROFESIONAL ID FOR PROPERTY
            return View("DetalleTurno");
        }

        public ActionResult List(int currentId, int searchId, int? page)
        {
            if (searchId != 0)
                page = 1;
            else
                searchId = currentId;

            ViewBag.CurrentFilter = searchId;
            IEnumerable<ProfesionalDummy> profesionals = profesionalProcess.GetByEspecialidad(4);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(profesionals.ToPagedList(pageNumber, pageSize));
        }

        public JsonResult GetEspecialidades(string Areas, string term)
        {
            var lista = especialidadProcess.GetAutocomplete(term);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProfesionales(string Areas, string term)
        {
            var lista = profesionalProcess.GetAutocomplete(term);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAfiliados(string Areas, string term)
        {
            var lista = afiliadoProcess.GetAutocomplete(term);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Register(string dia, string hora, string observaciones, int afiliadoId)

        {
            var especialidadProfesionalId = process.getEspecialidadProfesionalId(ProfesionalId, EspecialidadId);
            string format = "MM/dd/yyyy";

            //var turno = new Turno {
            //    Fecha = DateTime.ParseExact(dia, format, CultureInfo.InvariantCulture),
            //    Hora = TimeSpan.Parse(hora),
            //    Observaciones = observaciones,
            //    EspecialidadProfesionalId = especialidadProfesionalId,
            //    AfiliadoId = 4,
            //    createdon = DateTime.Now,
            //    changedon = DateTime.Now
            //};

            //process.Create(turno);
            return View("home");
        }
    }
}
