using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class TipoDocumentoController : Controller
    {        
        private TipoDocumentoProcess component = new TipoDocumentoProcess();

        // GET: Masters/TipoDocumento
        public ActionResult Index()
        {
            return View(component.Get());
        }

        // GET: Masters/TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDocumento = component.GetDetail(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // GET: Masters/TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/TipoDocumento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                component.Create(tipoDocumento);
                return RedirectToAction("Index");
            }

            return View(tipoDocumento);
        }

        // GET: Masters/TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDocumento = component.GetDetail(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // POST: Masters/TipoDocumento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                component.Update(tipoDocumento);
                return RedirectToAction("Index");
            }
            return View(tipoDocumento);
        }

        // GET: Masters/TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDocumento = component.GetDetail(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // POST: Masters/TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tipoDocumento = component.GetDetail(id);
            component.Delete(tipoDocumento);
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
