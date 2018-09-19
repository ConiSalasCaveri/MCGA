using System.Net;
using System.Web.Mvc;
using MCGA.Entities;
using MCGA.UI.Process;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class AfiliadoController : Controller
    {        
        private AfiliadoProcess component = new AfiliadoProcess();
        private TipoDocumentoProcess tipoDocumentoComponent = new TipoDocumentoProcess();
        private TipoSexoProcess tipoSexoComponent = new TipoSexoProcess();
        // GET: Masters/Afiliado
        public ActionResult Index()
        {            
            return View(component.Get());
        }

        // GET: Masters/Afiliado/Details/5
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
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion");
            ViewBag.TipoSexoId = new SelectList(tipoSexoComponent.SelectList(), "Id", "descripcion");
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
                component.Create(afiliado);
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(tipoSexoComponent.SelectList(), "Id", "descripcion", afiliado.TipoSexoId);
            return View(afiliado);
        }

        // GET: Masters/Afiliado/Edit/5
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
                component.Update(afiliado);
                return RedirectToAction("Index");
            }            
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoComponent.SelectList(), "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(tipoSexoComponent.SelectList(), "Id", "descripcion", afiliado.TipoSexoId);
            return View(afiliado);
        }

        // GET: Masters/Afiliado/Delete/5
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
            component.Delete(afiliado);
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
