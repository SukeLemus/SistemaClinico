using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaClinico.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {      
            return View();
        }

        public ActionResult SoliRegistro()
        {
            return View();
        }
        public ActionResult Datanetsv()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Print()
        {
            return new ActionAsPdf("Inde", new { nombre = "Pedrito" })
            {
                FileName = "test.pdf"
            };
        }
    }
}