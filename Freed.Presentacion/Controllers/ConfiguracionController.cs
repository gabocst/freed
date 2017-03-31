using Freed.Presentacion.FreedServices;
using Freed.Presentacion.Models;
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
    public class ConfiguracionController : Controller
    {
        FreedServicesClient db = new FreedServicesClient();
        // GET: Configuracion
        public ActionResult Index()
        {
            var response = db.listarConfiguracion();
            List<configuracionDTO> config_list = new List<configuracionDTO>();
            if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config_list = (List<configuracionDTO>)js.Deserialize(response.data, typeof(List<configuracionDTO>));
            }
            else if (response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            return View(config_list);
        }

        // GET: Configuracion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerConfiguracion(id.Value);
            configuracionDTO config = new configuracionDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config = (configuracionDTO)js.Deserialize(response.data, typeof(configuracionDTO));
            }
            return View(config);
        }

        // GET: Configuracion/Create
        public ActionResult Create()
        {
            var groups = db.listarGrupo();
            List<grupoDTO> group_list = new List<grupoDTO>();
            if (groups.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group_list = (List<grupoDTO>)js.Deserialize(groups.data, typeof(List<grupoDTO>));
            }
            ViewBag.idGrupo = new SelectList(group_list, "id", "nombre");
            tipoValor t = new tipoValor();
            List<tipoValor> types = new List<tipoValor>();
            types = t.get_types();
            ViewBag.tipoValor = new SelectList(types, "nombre", "nombre");
            return View();
        }

        // POST: Configuracion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "atributo, idGrupo, requerido, tipoValor, descripcion")] configuracionDTO config)
        {
            try
            {
                var response = db.crearConfiguracion(config);
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
            var groups = db.listarGrupo();
            List<grupoDTO> group_list = new List<grupoDTO>();
            if (groups.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group_list = (List<grupoDTO>)js.Deserialize(groups.data, typeof(List<grupoDTO>));
            }
            ViewBag.idGrupo = new SelectList(group_list, "id", "nombre", config.idGrupo);
            tipoValor t = new tipoValor();
            List<tipoValor> types = new List<tipoValor>();
            types = t.get_types();
            ViewBag.tipoValor = new SelectList(types, "nombre", "nombre", config.tipoValor);
            return View(config);
        }

        // GET: Configuracion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerConfiguracion(id.Value);
            configuracionDTO config = new configuracionDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config = (configuracionDTO)js.Deserialize(response.data, typeof(configuracionDTO));
            }
            var groups = db.listarGrupo();
            List<grupoDTO> group_list = new List<grupoDTO>();
            if (groups.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group_list = (List<grupoDTO>)js.Deserialize(groups.data, typeof(List<grupoDTO>));
            }
            ViewBag.idGrupo = new SelectList(group_list, "id", "nombre", config.idGrupo);
            tipoValor t = new tipoValor();
            List<tipoValor> types = new List<tipoValor>();
            types = t.get_types();
            ViewBag.tipoValor = new SelectList(types, "nombre", "nombre", config.tipoValor);
            return View(config);
        }

        // POST: Configuracion/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerConfiguracion(id.Value);
            configuracionDTO config = new configuracionDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config = (configuracionDTO)js.Deserialize(response.data, typeof(configuracionDTO));
            }
            try
            {
                if (TryUpdateModel(config, "",
                    new string[] { "atributo", "idGrupo", "requerido", "tipoValor", "descripcion" }))
                {

                    var resp = db.actualizarConfiguracion(config);
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
            var groups = db.listarGrupo();
            List<grupoDTO> group_list = new List<grupoDTO>();
            if (groups.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                group_list = (List<grupoDTO>)js.Deserialize(groups.data, typeof(List<grupoDTO>));
            }
            ViewBag.idGrupo = new SelectList(group_list, "id", "nombre", config.idGrupo);
            tipoValor t = new tipoValor();
            List<tipoValor> types = new List<tipoValor>();
            types = t.get_types();
            ViewBag.tipoValor = new SelectList(types, "nombre", "nombre", config.tipoValor);
            return View(config);
        }

        // GET: Configuracion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerConfiguracion(id.Value);
            configuracionDTO config = new configuracionDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config = (configuracionDTO)js.Deserialize(response.data, typeof(configuracionDTO));
            }
            return View(config);
        }

        // POST: Configuracion/Delete/5
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
                var response = db.eliminarConfiguracion(id.Value);
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
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }
    }
}
