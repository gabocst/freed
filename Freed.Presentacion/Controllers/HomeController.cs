using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freed.Presentacion.FreedServices;
using System.Web.Script.Serialization;

namespace Freed.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        FreedServicesClient db = new FreedServicesClient();
        public ActionResult Index()
        {
            var hola = db.leerGrupo(1);
            if (hola.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                grupoDTO gruop_list = (grupoDTO)js.Deserialize(hola.data, typeof(grupoDTO));
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}