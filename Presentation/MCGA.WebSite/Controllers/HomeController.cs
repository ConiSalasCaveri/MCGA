using MCGA.WebSite.Constants.HomeController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA.WebSite.Controllers
{
    [Route("", Name = HomeControllerRoute.GetIndex)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(HomeControllerAction.Index);
        }

        [Route("Turnos", Name = HomeControllerRoute.GetTurns)]
        [Authorize]
        public ActionResult GoToTurns()
        {
            return View();
        }

        [Route("Nosotros", Name = HomeControllerRoute.GetAbout)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(HomeControllerAction.About);
        }

        [Route("Contacto", Name = HomeControllerRoute.GetContact)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(HomeControllerAction.Contact);
        }
    }
}