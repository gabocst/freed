using Freed.Presentacion.FreedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Freed.Presentacion.Controllers
{
    public class ActividadController : Controller
    {
        FreedServicesClient db = new FreedServicesClient();
        // GET: Actividad
        public ActionResult Index()
        {
            var activities = db.listarActividad();
            List<actividadDTO> activity_list = new List<actividadDTO>();
            if (activities.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                activity_list = (List<actividadDTO>)js.Deserialize(activities.data, typeof(List<actividadDTO>));
            }
            else if (activities.code == 500)
            {
                ViewBag.error = activities.messageDetail;
            }
            return View(activity_list);
        }

        // GET: Actividad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerActividad(id.Value);
            actividadDTO activity = new actividadDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                activity = (actividadDTO)js.Deserialize(response.data, typeof(actividadDTO));
            }
            return View(activity);
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actividad/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre")] actividadDTO activity)
        {
            try
            {
                var response = db.crearActividad(activity);
                if (response.code == 201)
                {
                    return RedirectToAction("Index");
                }
                else if (response.code == 500)
                {
                    ModelState.AddModelError("", response.messageDetail);
                }
            }
            catch (FaultException ex)
            {
                int pos = ex.Message.IndexOf(":");
                ModelState.AddModelError("", ex.Message.Substring(pos + 2).ToString());
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No fue posible guardar los cambios. Intente nuevamente, y si el problema persiste comuniquese con su administrador de sistemas.");
            }
            return View(activity);
        }

        // GET: Actividad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerActividad(id.Value);
            actividadDTO activity = new actividadDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                activity = (actividadDTO)js.Deserialize(response.data, typeof(actividadDTO));
            }
            return View(activity);
        }

        // POST: Actividad/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerActividad(id.Value);
            actividadDTO activity = new actividadDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                activity = (actividadDTO)js.Deserialize(response.data, typeof(actividadDTO));
            }
            try
            {
                if (TryUpdateModel(activity, "",
                    new string[] { "nombre" }))
                {

                    var resp = db.actualizarActividad(activity);
                    if (response.code == 200)
                    {
                        return RedirectToAction("Index");
                    }
                    else if (response.code == 500)
                    {
                        ModelState.AddModelError("", response.messageDetail);
                    }
                }
            }
            catch (FaultException ex)
            {
                int pos = ex.Message.IndexOf(":");
                ModelState.AddModelError("", ex.Message.Substring(pos + 2).ToString());
            }
            catch (Exception /* dex */)
            {
                ModelState.AddModelError("", "No fue posible guardar los cambios. Intente nuevamente, y si el problema persiste comuniquese con su administrador de sistemas.");
            }
            return View(activity);
        }

        // GET: Actividad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerActividad(id.Value);
            actividadDTO activity = new actividadDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                activity = (actividadDTO)js.Deserialize(response.data, typeof(actividadDTO));
            }
            return View(activity);
        }

        // POST: Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var response = db.eliminarActividad(id.Value);
                if (response.code == 200)
                {
                    return RedirectToAction("Index");
                }
                else if (response.code == 500 || response.code == 400)
                {
                    ViewBag.error = response.messageDetail;
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No fue posible guardar los cambios. Intente nuevamente, y si el problema persiste comuniquese con su administrador de sistemas.");
            }
            return View();
        }
    }
}
