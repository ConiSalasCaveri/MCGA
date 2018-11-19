using System.Linq;
using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using WebApplication1.Services.Cache;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class TipoDiaController : Controller
    {
        private TipoDiaProcess component = new TipoDiaProcess();        

        // GET: Masters/TipoDia
        public ActionResult Index()
        {
            var list = DataCache.Instance.TipoDiaList();
            return View(list);
            //return RedirectToAction("List");
        }

        public ActionResult List()
        {
            //return View(component.Get());
            var list = DataCache.Instance.TipoDiaList();
            return View(list);
        }
        // GET: Masters/TipoDia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDia = component.GetDetail(id);
            if (tipoDia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDia);
        }

        // GET: Masters/TipoDia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/TipoDia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] TipoDia tipoDia)
        {
            if (ModelState.IsValid)
            {
                component.Create(tipoDia);
                DataCache.Instance.Clear();
                return RedirectToAction("Index");
            }

            return View(tipoDia);
        }

        // GET: Masters/TipoDia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDia = component.GetDetail(id);
            if (tipoDia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDia);
        }

        // POST: Masters/TipoDia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoDia tipoDia)
        {
            if (ModelState.IsValid)
            {
                component.Update(tipoDia);
                DataCache.Instance.Clear();
                return RedirectToAction("Index");
            }
            return View(tipoDia);
        }

        // GET: Masters/TipoDia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDia = component.GetDetail(id);
            if (tipoDia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDia);
        }

        // POST: Masters/TipoDia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tipoDia = component.GetDetail(id);
            component.Delete(tipoDia);
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
        public JsonResult GetDias(string Areas, string term)
        {
            var lista = component.GetAutocomplete(term);            

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

    }
}
