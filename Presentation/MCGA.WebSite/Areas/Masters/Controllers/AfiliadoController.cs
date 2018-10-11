using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;
using MCGA.WebSite.Constants.AfiliadoController;
using PagedList;
using Microsoft.AspNet.Identity;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class AfiliadoController : Controller
    {        
        private AfiliadoProcess component = new AfiliadoProcess();
        private TipoDocumentoProcess tipoDocumentoComponent = new TipoDocumentoProcess();
        private TipoSexoProcess tipoSexoComponent = new TipoSexoProcess();
        private EstadoCivilProcess estadoCivilProcess = new EstadoCivilProcess();
        private PlanProcess planProcess = new PlanProcess();
        // GET: Masters/Afiliado

        //[Route("vertodos", Name = AfiliadoControllerRoute.GetEntities)]
        public ActionResult Index()
        {            
            return View(component.Get());
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
            IEnumerable<Afiliado> afiliados = component.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                afiliados = afiliados
                    .Where(s => s.Nombre.ToLower().Contains(searchString.ToLower()) ||
                           s.Apellido.ToLower().Contains(searchString.ToLower()));
            }
            afiliados = afiliados.OrderBy(o => o.Nombre);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(afiliados.ToPagedList(pageNumber, pageSize));
        }

        // GET: Masters/Afiliado/Details/5
       // [Route("verdetalle", Name = AfiliadoControllerRoute.GetEntity)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var afiliado = component.GetDetail(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // GET: Masters/Afiliado/Create        
        //[Route("Nuevo", Name = AfiliadoControllerRoute.GetCreate)]
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion");
            ViewBag.TipoSexoId = new SelectList(tipoSexoComponent.SelectList(), "Id", "descripcion");
            ViewBag.EstadoCivilId = new SelectList(estadoCivilProcess.SelectList(), "Id", "descripcion");
            ViewBag.PlanId = new SelectList(planProcess.SelectList(), "Id", "descripcion");
            return View();
        }

        // POST: Masters/Afiliado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,TipoSexoId,FechaNacimiento,EstadoCivilId,NumeroAfiliado,PlanId,Foto,Habilitado,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                afiliado.createdby = User.Identity.GetUserId();
                component.Create(afiliado);
                return RedirectToAction("List");
            }
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(tipoSexoComponent.SelectList(), "Id", "descripcion", afiliado.TipoSexoId);
            ViewBag.EstadoCivilId = new SelectList(estadoCivilProcess.SelectList(), "Id", "descripcion");
            ViewBag.PlanId = new SelectList(planProcess.SelectList(), "Id", "descripcion");
            return View(afiliado);
        }

        // GET: Masters/Afiliado/Edit/5
       // [Route("actualizar", Name = AfiliadoControllerRoute.GetUpdate)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var afiliado = component.GetDetail(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }            
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(tipoSexoComponent.SelectList(), "Id", "descripcion", afiliado.TipoSexoId);
            ViewBag.EstadoCivilId = new SelectList(estadoCivilProcess.SelectList(), "Id", "descripcion");
            ViewBag.PlanId = new SelectList(planProcess.SelectList(), "Id", "descripcion");
            return View(afiliado);
        }

        // POST: Masters/Afiliado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,TipoSexoId,FechaNacimiento,EstadoCivilId,NumeroAfiliado,PlanId,Foto,Habilitado,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                afiliado.changedby = User.Identity.GetUserId();
                component.Update(afiliado);
                return RedirectToAction("List");
            }            
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(tipoSexoComponent.SelectList(), "Id", "descripcion", afiliado.TipoSexoId);
            ViewBag.EstadoCivilId = new SelectList(estadoCivilProcess.SelectList(), "Id", "descripcion");
            ViewBag.PlanId = new SelectList(planProcess.SelectList(), "Id", "descripcion");
            return View(afiliado);
        }

        // GET: Masters/Afiliado/Delete/5
        //[Route("eliminar", Name = AfiliadoControllerRoute.GetDelete)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var afiliado = component.GetDetail(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // POST: Masters/Afiliado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var afiliado = component.GetDetail(id);
            afiliado.deletedby = User.Identity.GetUserId();
            component.Delete(afiliado);
            return RedirectToAction("List");
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
