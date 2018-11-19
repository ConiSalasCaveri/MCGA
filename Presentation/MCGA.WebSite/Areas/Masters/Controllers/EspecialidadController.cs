using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using PagedList;
using WebApplication1.Services.Cache;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class EspecialidadController : Controller
    {        
        private EspecialidadProcess component = new EspecialidadProcess();

        // GET: Masters/Especialidad
        public ActionResult Index()
        {            
            return RedirectToAction("List");
        }

        public ActionResult List(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            IEnumerable<Especialidad> especialidades = component.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                especialidades = especialidades
                    .Where(s => s.descripcion.ToLower().Contains(searchString.ToLower()));                    
            }
            especialidades = especialidades                
                .OrderBy(o => o.descripcion);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(especialidades.ToPagedList(pageNumber, pageSize));
        }

        // GET: Masters/Especialidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var especialidad = component.GetDetail(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // GET: Masters/Especialidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/Especialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion,frecuencia,TipoEspecialidadId")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                component.Create(especialidad);
                DataCache.Instance.Clear();
                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        // GET: Masters/Especialidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var especialidad = component.GetDetail(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Masters/Especialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion,frecuencia,TipoEspecialidadId")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                component.Update(especialidad);
                DataCache.Instance.Clear();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        // GET: Masters/Especialidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var especialidad = component.GetDetail(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Masters/Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var especialidad = component.GetDetail(id);
            component.Delete(especialidad);
            DataCache.Instance.Clear();
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
