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
    public class ConfiguracionClienteController : Controller
    {
        FreedServicesClient db = new FreedServicesClient();
        // GET: ConfiguracionCliente
        public ActionResult Index()
        {
            var response = db.listarConfiguracionCliente();
            List<configuracionClienteDTO> configClient_list = new List<configuracionClienteDTO>();
            if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                configClient_list = (List<configuracionClienteDTO>)js.Deserialize(response.data, typeof(List<configuracionClienteDTO>));
            }
            else if (response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            return View(configClient_list);
        }

        // GET: ConfiguracionCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerConfiguracionCliente(id.Value);
            configuracionClienteDTO configClient = new configuracionClienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                configClient = (configuracionClienteDTO)js.Deserialize(response.data, typeof(configuracionClienteDTO));
            }
            return View(configClient);
        }

        // GET: ConfiguracionCliente/Create
        public ActionResult Create()
        {
            /*lista de configuraciones*/
            var config = db.listarConfiguracion();
            List<configuracionDTO> config_list = new List<configuracionDTO>();
            if (config.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config_list = (List<configuracionDTO>)js.Deserialize(config.data, typeof(List<configuracionDTO>));
            }
            ViewBag.idConfiguracion = new SelectList(config_list, "id", "atributo");

            /*lista de clientes*/
            var client = db.listarCliente();
            List<clienteDTO> client_list = new List<clienteDTO>();
            if (client.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client_list = (List<clienteDTO>)js.Deserialize(client.data, typeof(List<clienteDTO>));
            }
            ViewBag.idCliente = new SelectList(client_list, "id", "nombre");

            return View();
        }

        // POST: ConfiguracionCliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken] //HAY QUE CREAR EXPRESIONES REGULARES PARA VALIDAR EL TIPO DE DATO
        public ActionResult Create([Bind(Include = "valor, idConfiguracion, idCliente")] configuracionClienteDTO configClient)
        {
            try
            {
                var response = db.crearConfiguracionCliente(configClient);
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
                ModelState.AddModelError("", ex.Message /*ex.Message.Substring(pos + 2).ToString()*/);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No fue posible guardar los cambios. Intente nuevamente, y si el problema persiste comuniquese con su administrador de sistemas.");
            }
            var config = db.listarConfiguracion();
            List<configuracionDTO> config_list = new List<configuracionDTO>();
            if (config.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config_list = (List<configuracionDTO>)js.Deserialize(config.data, typeof(List<configuracionDTO>));
            }
            ViewBag.idConfiguracion = new SelectList(config_list, "id", "atributo", configClient.idConfiguracion);
            /*lista de clientes*/
            var client = db.listarCliente();
            List<clienteDTO> client_list = new List<clienteDTO>();
            if (client.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client_list = (List<clienteDTO>)js.Deserialize(client.data, typeof(List<clienteDTO>));
            }
            ViewBag.idCliente = new SelectList(client_list, "id", "nombre", configClient.idCliente);
            return View(configClient);
        }

        // GET: ConfiguracionCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerConfiguracionCliente(id.Value);
            configuracionClienteDTO configClient = new configuracionClienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                configClient = (configuracionClienteDTO)js.Deserialize(response.data, typeof(configuracionClienteDTO));
            }
            /*lista de configuraciones*/
            var config = db.listarConfiguracion();
            List<configuracionDTO> config_list = new List<configuracionDTO>();
            if (config.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config_list = (List<configuracionDTO>)js.Deserialize(config.data, typeof(List<configuracionDTO>));
            }
            ViewBag.idConfiguracion = new SelectList(config_list, "id", "atributo", configClient.idConfiguracion);

            /*lista de clientes*/
            var client = db.listarCliente();
            List<clienteDTO> client_list = new List<clienteDTO>();
            if (client.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client_list = (List<clienteDTO>)js.Deserialize(client.data, typeof(List<clienteDTO>));
            }
            ViewBag.idCliente = new SelectList(client_list, "id", "nombre", configClient.idCliente);
            return View(configClient);
        }

        // POST: ConfiguracionCliente/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerConfiguracionCliente(id.Value);
            configuracionClienteDTO configClient = new configuracionClienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                configClient = (configuracionClienteDTO)js.Deserialize(response.data, typeof(configuracionClienteDTO));
            }
            try
            {
                if (TryUpdateModel(configClient, "",
                    new string[] { "valor" }))
                {

                    var resp = db.actualizarConfiguracionCliente(configClient);
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
                ModelState.AddModelError("", ex.Message /*ex.Message.Substring(pos + 2).ToString()*/);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No fue posible guardar los cambios. Intente nuevamente, y si el problema persiste comuniquese con su administrador de sistemas.");
            }
            /*lista de configuraciones*/
            var config = db.listarConfiguracion();
            List<configuracionDTO> config_list = new List<configuracionDTO>();
            if (config.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                config_list = (List<configuracionDTO>)js.Deserialize(config.data, typeof(List<configuracionDTO>));
            }
            ViewBag.idConfiguracion = new SelectList(config_list, "id", "atributo", configClient.idConfiguracion);

            /*lista de clientes*/
            var client = db.listarCliente();
            List<clienteDTO> client_list = new List<clienteDTO>();
            if (client.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client_list = (List<clienteDTO>)js.Deserialize(client.data, typeof(List<clienteDTO>));
            }
            ViewBag.idCliente = new SelectList(client_list, "id", "nombre", configClient.idCliente);
            return View(configClient);
        }

        // GET: ConfiguracionCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerConfiguracionCliente(id.Value);
            configuracionClienteDTO configClient = new configuracionClienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                configClient = (configuracionClienteDTO)js.Deserialize(response.data, typeof(configuracionClienteDTO));
            }
            return View(configClient);
        }

        // POST: ConfiguracionCliente/Delete/5
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
                var response = db.eliminarConfiguracionCliente(id.Value);
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
