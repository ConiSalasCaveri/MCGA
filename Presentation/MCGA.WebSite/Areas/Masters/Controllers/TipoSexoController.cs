using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using WebApplication1.Services.Cache;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class TipoSexoController : Controller
    {
        private TipoSexoProcess component = new TipoSexoProcess();

        // GET: Masters/TipoSexo
        public ActionResult Index()
        {
            var list = DataCache.Instance.TipoSexoList();
            return View(list);
        }

        // GET: Masters/TipoSexo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoSexo = component.GetDetail(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // GET: Masters/TipoSexo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/TipoSexo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
                component.Create(tipoSexo);
                return RedirectToAction("Index");
            }

            return View(tipoSexo);
        }

        // GET: Masters/TipoSexo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoSexo = component.GetDetail(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // POST: Masters/TipoSexo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
                component.Update(tipoSexo);
                return RedirectToAction("Index");
            }
            return View(tipoSexo);
        }

        // GET: Masters/TipoSexo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoSexo = component.GetDetail(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // POST: Masters/TipoSexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tipoSexo = component.GetDetail(id);
            component.Delete(tipoSexo);
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
