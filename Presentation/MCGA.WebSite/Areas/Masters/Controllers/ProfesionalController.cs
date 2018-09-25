using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using WebApplication1.Services.Cache;
using PagedList;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class ProfesionalController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ProfesionalProcess component = new ProfesionalProcess();
        private TipoDocumentoProcess tipoDocumentoComponent = new TipoDocumentoProcess();

        // GET: Masters/Profesional
        public ActionResult Index()
        {            
            var list = DataCache.Instance.ProfesionalList();
            return View(list);
        }

        public ActionResult ListBase()
        {            
            return View(component.Get().OrderBy(x => x.Nombre).ToList());
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
                           s.Apellido.ToLower().Contains(searchString.ToLower()));
            }
            profesionales = profesionales.OrderBy(o => o.Nombre);
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
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                component.Create(profesional);
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", profesional.TipoDocumentoId);
            return View(profesional);
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
            if (ModelState.IsValid)
            {
                component.Update(profesional);
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", profesional.TipoDocumentoId);
            return View(profesional);
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
            var profesional = component.GetDetail(id);
            component.Delete(profesional);
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
