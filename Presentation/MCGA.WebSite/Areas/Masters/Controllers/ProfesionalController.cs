using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using WebApplication1.Services.Cache;
using PagedList;
using Microsoft.AspNet.Identity;
using System;
using log4net;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class ProfesionalController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ProfesionalProcess component = new ProfesionalProcess();
        private TipoDocumentoProcess tipoDocumentoComponent = new TipoDocumentoProcess();
        private ProfesionalEspecialidadProcess profesionalEspecialidadIds = new ProfesionalEspecialidadProcess();

        private static ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(ProfesionalController));
        private static int profesionalId { get; set; }
        private static int profesionalIdForDelete { get; set; }

        // GET: Masters/Profesional
        public ActionResult Index()
        {
            //var list = DataCache.Instance.ProfesionalList();
            //return View(list                
            //    .Where(x => x.isdeleted == false)
            //    .OrderBy(x => x.Nombre)
            //    .ToList());
            return RedirectToAction("List");
        }

        public ActionResult ListBase()
        {            
            return View(component
                .Get()
                .Where(x => x.isdeleted == false)
                .OrderBy(x => x.Nombre)
                .ToList());
        }

        public ActionResult List(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            IEnumerable<Profesional> profesionales = component.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                profesionales = profesionales
                    .Where(s => s.Nombre.ToLower().Contains(searchString.ToLower()) || 
                           s.Apellido.ToLower().Contains(searchString.ToLower()))
                    .Where(x => x.isdeleted == false);
            }
            profesionales = profesionales
                .Where(x => x.isdeleted == false)
                .OrderBy(o => o.Nombre);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(profesionales.ToPagedList(pageNumber, pageSize));
        }

        // GET: Masters/Profesional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var profesional = component.GetDetail(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // GET: Masters/Profesional/Create
       // [Route("Crearprofesional", Name = ProfesionalControllerRoute.GetCreate)]
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion");
            return View();
        }

        // POST: Masters/Profesional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula")] Profesional profesional)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    profesional.createdby = User.Identity.GetUserId();
                    component.Create(profesional);
                    DataCache.Instance.Clear();
                    return RedirectToAction("List");
                }

                ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", profesional.TipoDocumentoId);
                return View(profesional);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return View(profesional);
            }
        }

        // GET: Masters/Profesional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var profesional = component.GetDetail(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", profesional.TipoDocumentoId);
            return View(profesional);
        }

        // POST: Masters/Profesional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Profesional profesional)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    profesional.changedby = User.Identity.GetUserId();
                    component.Update(profesional);
                    DataCache.Instance.Clear();
                    return RedirectToAction("List");
                }
                ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", profesional.TipoDocumentoId);
                return View(profesional);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return View(profesional);
            }
        }

        // GET: Masters/Profesional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var profesional = component.GetDetail(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // POST: Masters/Profesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var profesional = component.GetDetail(id);
                profesional.deletedby = User.Identity.GetUserId();
                component.Delete(profesional);
                DataCache.Instance.Clear();
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return RedirectToAction("List");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                component.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Especialidad(int id)
        {
            try
            {
                profesionalId = id;
                var profesional = component.GetDetail(id);
                if (profesional == null)
                {
                    return HttpNotFound();
                }
                ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", profesional.TipoDocumentoId);
                return View(profesional);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return RedirectToAction("List");
            }
        }

        public ActionResult ProfesionalEspecialidad(int id)
        {
            try
            {
                var especialidadProfesional = new EspecialidadesProfesional {
                    EspecialidadId = id,
                    ProfesionalId = profesionalId };
                profesionalEspecialidadIds.Create(especialidadProfesional);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return RedirectToAction("List");
            }
        }

        public JsonResult GetEspecialidades(string Areas, string term)
        {
            var especialidadProcess = new EspecialidadProcess();
            var lista = especialidadProcess.GetAutocompleteWithProfesional(profesionalId, term);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EspecialidadList(int id)
        {
            profesionalIdForDelete = id;
            var especialidades = component.GetEspecialidadesById(id);

            return View(especialidades);
        }

        public ActionResult DeleteEspecialidad(int id)
        {
            try
            {
                component.DeleteEspecialidadOfProfesional(id, profesionalIdForDelete);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return RedirectToAction("List");
            }
        }
    }
}
