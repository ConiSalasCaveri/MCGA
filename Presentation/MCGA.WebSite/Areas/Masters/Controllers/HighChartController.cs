using MCGA.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA.WebSite.Areas.Masters.Controllers
{
    public class HighChartController : Controller
    {
        public TurnoProcess process = new TurnoProcess();

        [HttpGet]
        public ActionResult Index()
        {
            var total = process.GetByMonth();
            ViewData["dataToShow"] = total;
            return View("Index");
        }
    }
}