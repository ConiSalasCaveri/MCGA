using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using PagedList;
using Microsoft.AspNet.Identity;
using MCGA.WebSite.Constants.ProfesionalController;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class PlanController : Controller
    {
        private PlanProcess process = new PlanProcess();

        // GET: Masters/Plan
        public ActionResult Index()
        {
            return View(process.Get());
        }

        public ActionResult ListBase()
        {
            return View(process
                .Get()
                .Where(x => x.isdeleted == false)
                .OrderBy(x => x.descripcion)
                .ToList());
        }

        public ActionResult List(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            IEnumerable<Plan> planes = process.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                planes = planes
                    .Where(s => s.descripcion.ToLower().Contains(searchString.ToLower()))                           
                    .Where(x => x.isdeleted == false);
            }
            planes = planes
                .Where(x => x.isdeleted == false)
                .OrderBy(o => o.descripcion);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(planes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Masters/Plan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plan = process.GetDetail(id); 
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Masters/Plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/Plan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion,precio_bono_consulta,precio_bono_farmacia,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                plan.createdby = User.Identity.GetUserId();
                process.Create(plan);
                return RedirectToAction("List");
            }

            return View(plan);
        }

        // GET: Masters/Plan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plan = process.GetDetail(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Masters/Plan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion,precio_bono_consulta,precio_bono_farmacia,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                plan.changedby = User.Identity.GetUserId();
                process.Update(plan);
                return RedirectToAction("List");
            }
            return View(plan);
        }

        // GET: Masters/Plan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plan = process.GetDetail(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Masters/Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var plan = process.GetDetail(id);
            plan.deletedby = User.Identity.GetUserId();
            process.Delete(plan);
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                process.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
