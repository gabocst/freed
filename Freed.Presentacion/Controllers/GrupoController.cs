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
    public class GrupoController : Controller
    {
        FreedServicesClient db = new FreedServicesClient();
        // GET: Grupo
        public ActionResult Index()
        {
            var groups = db.listarGrupo();
            List<grupoDTO> group_list = new List<grupoDTO>();
            if (groups.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group_list = (List<grupoDTO>)js.Deserialize(groups.data, typeof(List<grupoDTO>));
            }
            else if (groups.code == 500)
            {
                ViewBag.error = groups.messageDetail;
            }
            return View(group_list);
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerGrupo(id.Value);
            grupoDTO group = new grupoDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group = (grupoDTO)js.Deserialize(response.data, typeof(grupoDTO));
            }
            return View(group);
        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre")] grupoDTO group)
        {
            try
            {
                var response = db.crearGrupo(group);
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
                ModelState.AddModelError("", ex.Message.Substring(pos+2).ToString());
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "No fue posible guardar los cambios. Intente nuevamente, y si el problema persiste comuniquese con su administrador de sistemas.");
            }
            return View(group);
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerGrupo(id.Value);
            grupoDTO group = new grupoDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group = (grupoDTO)js.Deserialize(response.data, typeof(grupoDTO));
            }
            return View(group);
        }

        // POST: Grupo/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerGrupo(id.Value);
            grupoDTO group = new grupoDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group = (grupoDTO)js.Deserialize(response.data, typeof(grupoDTO));
            }
            try
            {
                if (TryUpdateModel(group, "",
                    new string[] { "nombre"}))
                {

                    var resp = db.actualizarGrupo(group);
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
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(group);
        }

        // GET: Grupo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerGrupo(id.Value);
            grupoDTO group = new grupoDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group = (grupoDTO)js.Deserialize(response.data, typeof(grupoDTO));
            }
            return View(group);
        }

        // POST: Grupo/Delete/5
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
                var response = db.eliminarGrupo(id.Value);
                if (response.code == 200)
                {
                    return RedirectToAction("Index");
                }
                else if (response.code == 500 || response.code == 400)
                {
                    ViewBag.error = response.messageDetail;
                }
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }
    }
}
