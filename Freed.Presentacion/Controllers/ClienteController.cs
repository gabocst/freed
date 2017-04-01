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
        // GET: Cliente
        public ActionResult Index()
        {
            var response = db.listarCliente();
            List<clienteDTO> cliente_list = new List<clienteDTO>();
            if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                cliente_list = (List<clienteDTO>)js.Deserialize(response.data, typeof(List<clienteDTO>));
            }
            else if (response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            return View(cliente_list);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerCliente(id.Value); 
            clienteDTO cliente = new clienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                cliente = (clienteDTO)js.Deserialize(response.data, typeof(clienteDTO));
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            var estados = db.listarEstado();
            List<estadoDTO> estado_list = new List<estadoDTO>();
            if (estados.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                estado_list = (List<estadoDTO>)js.Deserialize(estados.data, typeof(List<estadoDTO>));
            }

            ViewBag.idEstado = new SelectList(estado_list, "id", "nombre");
       
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre, correo, idEstado")] clienteDTO cliente)
        {
            try
            {
                var response = db.crearCliente(cliente);
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
            var estados = db.listarEstado();
            List<estadoDTO> estado_list = new List<estadoDTO>();
            if (estados.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                estado_list = (List<estadoDTO>)js.Deserialize(estados.data, typeof(List<estadoDTO>));
            }

            ViewBag.idEstado = new SelectList(estado_list, "id", "nombre", cliente.idEstado);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerCliente(id.Value);
            clienteDTO cliente = new clienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                cliente = (clienteDTO)js.Deserialize(response.data, typeof(clienteDTO));
            }
            var estados = db.listarEstado();
            List<estadoDTO> estado_list = new List<estadoDTO>();
            if (estados.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                estado_list = (List<estadoDTO>)js.Deserialize(estados.data, typeof(List<estadoDTO>));
            }
            ViewBag.idEstado = new SelectList(estado_list, "id", "nombre", cliente.idEstado);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = db.leerCliente(id.Value);
            clienteDTO cliente = new clienteDTO();
            if (response.code == 404 || response.code == 500)
            {
                ViewBag.error = response.messageDetail;
            }
            else if (response.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                cliente = (clienteDTO)js.Deserialize(response.data, typeof(clienteDTO));
            }
            try
            {
                if (TryUpdateModel(cliente, "",
                    new string[] { "nombre", "correo", "idEstado" }))
                {

                    var resp = db.actualizarCliente(cliente);
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
            var estados = db.listarEstado();
            List<estadoDTO> estado_list = new List<estadoDTO>();
            if (estados.code == 200)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                estado_list = (List<estadoDTO>)js.Deserialize(estados.data, typeof(List<estadoDTO>));
            }

            ViewBag.idEstado = new SelectList(estado_list, "id", "nombre", cliente.idEstado);

            return View(cliente);
        }

        // GET: Cliente/Delete/5
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

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
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
