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
    public class ClienteController : Controller
    {
        FreedServicesClient db = new FreedServicesClient();
        // GET: Configuracion
        public ActionResult Index()
        {
            var response = db.listarCliente();
            List<clienteDTO> client_list = new List<clienteDTO>();
            if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client_list = (List<clienteDTO>)js.Deserialize(response.data, typeof(List<clienteDTO>));
            }
            else if (response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            return View(client_list);
        }

        // GET: Configuracion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerCliente(id.Value);
            clienteDTO client = new clienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client = (clienteDTO)js.Deserialize(response.data, typeof(clienteDTO));
            }
            return View(client);
        }

        
        // GET: Configuracion/Create
        public ActionResult Create()
        {
            var states = db.listarEstado();
            List<estadoDTO> state_list = new List<estadoDTO>();
            if (states.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                state_list = (List<estadoDTO>)js.Deserialize(states.data, typeof(List<estadoDTO>));
            }
            ViewBag.idEstado = new SelectList(state_list, "id", "nombre");
            return View();
        }

        
        // POST: Configuracion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre, correo, idEstado")] clienteDTO client)
        {
            try
            {
                var response = db.crearCliente(client);
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
            var states = db.listarEstado();
            List<estadoDTO> state_list = new List<estadoDTO>();
            if (states.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                state_list = (List<estadoDTO>)js.Deserialize(states.data, typeof(List<estadoDTO>));
            }
            ViewBag.idEstado = new SelectList(state_list, "id", "nombre", client.idEstado);
            return View(client);
        }
        
        // GET: Configuracion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerCliente(id.Value);
            clienteDTO client = new clienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client = (clienteDTO)js.Deserialize(response.data, typeof(clienteDTO));
            }
            var states = db.listarEstado();
            List<estadoDTO> state_list = new List<estadoDTO>();
            if (states.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                state_list = (List<estadoDTO>)js.Deserialize(states.data, typeof(List<estadoDTO>));
            }
            ViewBag.idEstado = new SelectList(state_list, "id", "nombre", client.idEstado);
            return View(client);
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
            var response = db.leerCliente(id.Value);
            clienteDTO client = new clienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client = (clienteDTO)js.Deserialize(response.data, typeof(clienteDTO));
            }
            try
            {
                if (TryUpdateModel(client, "",
                    new string[] { "nombre", "correo", "idEstado" }))
                {

                    var resp = db.actualizarCliente(client);
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
            var states = db.listarEstado();
            List<estadoDTO> state_list = new List<estadoDTO>();
            if (states.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                state_list = (List<estadoDTO>)js.Deserialize(states.data, typeof(List<estadoDTO>));
            }
            ViewBag.idEstado = new SelectList(state_list, "id", "nombre", client.idEstado);
            return View(client);
        }
        
        // GET: Configuracion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerCliente(id.Value);
            clienteDTO client = new clienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                client = (clienteDTO)js.Deserialize(response.data, typeof(clienteDTO));
            }
            return View(client);
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
                var response = db.eliminarCliente(id.Value);
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
