using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Freed.Servicios.Utils;
using Freed.Servicios.Models.grupo;
using Freed.Servicios.DTO;
using Freed.Servicios.Models.configuracion;
using Freed.Servicios.Models.cliente;
using Freed.Servicios.Models.configuracionCliente;
using Freed.Servicios.Models.actividad;
using Freed.Servicios.Models.persona;
using Freed.Servicios.Models.rol;
using Freed.Servicios.Models.factura;
using Freed.Servicios.Models.paquete;
using Freed.Servicios.Models.costo;
using Freed.Servicios.Models.informacionAfiliado;
using System.Web.Script.Serialization;
using DevTrends.WCFDataAnnotations;

namespace Freed.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FreedServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FreedServices.svc o FreedServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    [ValidateDataAnnotationsBehavior]
    public class FreedServices : IFreedServices
    {
        private freedEntities db = new freedEntities();

        #region Grupo
        public response listarGrupo()
        {
            response gl;
            List<grupoDTO> group_list = new List<grupoDTO>();
            try {
                var grupos = db.grupo.ToList();
                foreach (var i in grupos)
                {
                    grupoDTO g = new grupoDTO(i);
                    group_list.Add(g);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(group_list);

                /*List<grupoDTO> listGroup = (List<grupoDTO>)js.Deserialize(json, typeof(List<grupoDTO>));*/
                gl = new response(200, json, "OK", null);
            }
            catch (Exception ex) {
                gl = new response(500, "", "Error listando los grupos", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return gl;

        }

        public response crearGrupo(grupoDTO group)
        {
            response response;
            try
            {
                grupo g = new grupo();
                g.nombre = group.nombre;
                g.fechaCreacion = DateTime.Now;
                db.grupo.Add(g);
                db.SaveChanges();

                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(g);
                response = new response(201, json, "Grupo creado exitosamente", null);
            }
            catch(Exception ex)
            {
                response = new response(500, "", "Error creando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarGrupo(grupoDTO group)
        {
            response response;
            try
            {
                var g = db.grupo.Find(group.id);
                if (g == null) 
                    response = new response(404, group.id.ToString(), "No se encontro el grupo", null);
                
                g.nombre = group.nombre;
                db.SaveChanges();
                grupoDTO gro = new grupoDTO(g);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(gro);
                response = new response(200, json, "Grupo actualizado exitosamente", null);
            }
            catch(Exception ex)
            {
                response = new response(500, "", "Error actualizando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerGrupo(int id)
        {
            response response;
            try
            {
                var g = db.grupo.Find(id);
                if (g==null)
                    response = new response(404, id.ToString(),"No se encontro el grupo", null);

                grupoDTO gDTO = new grupoDTO(g);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(gDTO);
                response = new response(200, json, "OK", null);
            }
            catch(Exception ex)
            {
                response = new response(500, "", "Error obteniendo el grupo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarGrupo(int id)
        {
            response response;
            try
            {
                var g = db.grupo.Find(id);
                if (g == null)
                    response = new response(404, id.ToString(), "No se encontro el grupo", null);
                db.grupo.Remove(g);
                //Aqui hay que realizar las operaciones correspondientes para las configuraciones asociadas (o no permitir si hay asociadas)
                db.SaveChanges();
                response = new response(200, id.ToString(), "Grupo eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Configuracion
        public response listarConfiguracion()
        {
            response response;
            List<configuracionDTO> configuration_list = new List<configuracionDTO>();
            try
            {
                var config = db.configuracion.ToList();
                foreach (var i in config)
                {
                    configuracionDTO c = new configuracionDTO(i);
                    configuration_list.Add(c);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(configuration_list);
                response = new response(200,json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error listando las configuraciones", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return response;
        }

        public response crearConfiguracion(configuracionDTO configuration)
        {
            response response;
            try
            {
                configuracion c = new configuracion();
                c.atributo = configuration.atributo;
                c.codigoSistema = Guid.NewGuid().ToString();
                c.descripcion = configuration.descripcion;
                c.fechaCreacion = DateTime.Now;
                c.idGrupo = configuration.idGrupo;
                c.requerido = configuration.requerido;
                c.tipoValor = configuration.tipoValor;
                db.configuracion.Add(c);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(c);
                response = new response(201, json, "Configuración creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarConfiguracion(configuracionDTO config)
        {
            response response;
            try
            {
                var c = db.configuracion.Find(config.id);
                if (c == null)
                    response = new response(404, config.id.ToString(), "No se encontro la configuracion", null);
                c.atributo = config.atributo;
                c.descripcion = config.descripcion;
                c.idGrupo = config.idGrupo;
                c.requerido = config.requerido;
                c.tipoValor = config.tipoValor;
                db.SaveChanges();
                configuracionDTO con = new configuracionDTO(c);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(con);
                response = new response(200, json, "Configuración actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerConfiguracion(int id)
        {
            response response;
            try
            {
                var c = db.configuracion.Find(id);
                if (c == null)
                    response = new response(404, id.ToString(), "No se encontro la configuracion", null);
                configuracionDTO cDTO = new configuracionDTO(c);

                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(cDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarConfiguracion(int id)
        {
            response response;
            try
            {
                var c = db.configuracion.Find(id);
                if (c == null)
                    response = new response(404,id.ToString(), "No se encontro la configuracion", null);
                db.configuracion.Remove(c);
                //Aqui hay que realizar las operaciones correspondientes para eliminar las configuracionCliente asociadas
                db.SaveChanges();
                response = new response(200, id.ToString(), "Configuración eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Cliente
        public response listarCliente()
        {
            response response;
            List<clienteDTO> client_list = new List<clienteDTO>();
            try
            {
                var client = db.cliente.ToList();
                foreach (var i in client)
                {
                    clienteDTO c = new clienteDTO(i);
                    client_list.Add(c);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(client_list);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error listando los clientes", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return response;
        }

        public response crearCliente(clienteDTO client)
        {
            response response;
            try
            {
                cliente c = new cliente();
                c.fechaCreacion = DateTime.Now;
                c.correo = client.correo;
                c.idEstado = client.idEstado;
                c.nombre = client.nombre;
                db.cliente.Add(c);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(c);
                response = new response(201, json, "Cliente creado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando al cliente", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarCliente(clienteDTO client)
        {
            response response;
            try
            {
                var c = db.cliente.Find(client.id);
                if (c == null)
                    response = new response(404, client.id.ToString(), "No se encontro al cliente", null);
                c.correo = client.correo;
                c.idEstado = client.idEstado;
                c.nombre = client.nombre;
                db.SaveChanges();
                clienteDTO cli = new clienteDTO(c);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(cli);
                response = new response(200, json, "Cliente actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando al cliente", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerCliente(int id)
        {
            response response;
            try
            {
                var c = db.cliente.Find(id);
                if (c == null)
                    response = new response(404, id.ToString(), "No se encontro al cliente", null);
                clienteDTO cDTO = new clienteDTO(c);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(cDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo al cliente", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarCliente(int id)
        {
            response response;
            try
            {
                var c = db.cliente.Find(id);
                if (c == null)
                    response = new response(404, id.ToString(), "No se encontro al cliente", null);
                c.idEstado = db.estado.SingleOrDefault(x => x.nombre == "Inactivo").id;
                //Aqui hay que realizar las operaciones correspondientes de cuando se inactiva un cliente
                db.SaveChanges();
                response = new response(200, id.ToString(), "Cliente inactivado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error inactivando al cliente", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region ConfiguracionCliente
        public response listarConfiguracionCliente()
        {
            response response;
            List<configuracionClienteDTO> configuration_list = new List<configuracionClienteDTO>();
            try
            {
                var config = db.configuracionCliente.ToList();
                foreach (var i in config)
                {
                    configuracionClienteDTO c = new configuracionClienteDTO(i);
                    configuration_list.Add(c);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(configuration_list);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error listando las configuraciones", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return response;
        }

        public response crearConfiguracionCliente(configuracionClienteDTO configuration)
        {
            response response;
            try
            {
                configuracionCliente c = new configuracionCliente();
                c.idCliente = configuration.idCliente;
                c.idConfiguracion = configuration.idConfiguracion;
                c.valor = configuration.valor;
                db.configuracionCliente.Add(c);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(c);
                response = new response(201, json, "Configuración creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarConfiguracionCliente(configuracionClienteDTO config)
        {
            response response;
            try
            {
                var c = db.configuracionCliente.Find(config.id);
                if (c == null)
                    response = new response(404, config.id.ToString(), "No se encontro la configuracion", null);
                c.valor = config.valor;
                db.SaveChanges();
                configuracionClienteDTO conf = new configuracionClienteDTO(c);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(conf);
                response = new response(200, json, "Configuración actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerConfiguracionCliente(int id)
        {
            response response;
            try
            {
                var c = db.configuracionCliente.Find(id);
                if (c == null)
                    response = new response(404, id.ToString(), "No se encontro la configuracion", null);
                configuracionClienteDTO cDTO = new configuracionClienteDTO(c);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(cDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarConfiguracionCliente(int id)
        {
            response response;
            try
            {
                var c = db.configuracionCliente.Find(id);
                db.configuracionCliente.Remove(c);
                db.SaveChanges();
                response = new response(200, id.ToString(), "Configuración eliminada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Actividad
        public response listarActividad()
        {
            response gl;
            List<actividadDTO> activity_list = new List<actividadDTO>();
            try
            {
                var actividades = db.actividad.ToList();
                foreach (var i in actividades)
                { 
                    actividadDTO g = new actividadDTO(i);
                    activity_list.Add(g);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(activity_list);
                gl = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                gl = new response(500, "", "Error listando las actividades", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return gl;

        }

        public response crearActividad(actividadDTO activity)
        {
            response response;
            try
            {
                actividad a = new actividad();
                a.nombre = activity.nombre;
                a.fechaCreacion = DateTime.Now;
                db.actividad.Add(a);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(a);
                response = new response(201, json, "Actividad creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando la actividad", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarActividad(actividadDTO activity)
        {
            response response;
            try
            {
                var a = db.actividad.Find(activity.id);
                if (a == null)
                    response = new response(404, activity.id.ToString(), "No se encontro la actividad", null);

                a.nombre = activity.nombre;
                db.SaveChanges();
                actividadDTO act = new actividadDTO(a);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(act);
                response = new response(200, json, "Actividad actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando la actividad", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerActividad(int id)
        {
            response response;
            try
            {
                var a = db.actividad.Find(id);
                if (a == null)
                    response = new response(404, id.ToString(), "No se encontro la actividad", null);

                actividadDTO aDTO = new actividadDTO(a);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(aDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo la actividad", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarActividad(int id)
        {
            response response;
            try
            {
                var a = db.actividad.Find(id);
                if (a == null)
                    response = new response(404, id.ToString(), "No se encontro la actividad", null);
                db.actividad.Remove(a);
                //Aqui hay que realizar las operaciones correspondientes para las configuraciones asociadas (o no permitir si hay asociadas)
                db.SaveChanges();
                response = new response(200, id.ToString(), "Actividad eliminada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando la actividad", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Persona Empleado
        public response listarPersona(int id)
        {
            response pe;
            List<personaDTO> person_list = new List<personaDTO>();
            try
            {
                var personas = db.persona.Where(x => x.idCliente == id).ToList();
                foreach (var i in personas)
                {
                    personaDTO p = new personaDTO(i);
                    person_list.Add(p);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(person_list);
                pe = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                pe = new response(500, "", "Error listando a las personas", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return pe;

        }

        //public responseClass crearPersona(personaDTO person)
        //{
        //    responseClass response;
        //    try
        //    {
        //        grupo g = new grupo();
        //        g.nombre = group.nombre;
        //        g.fechaCreacion = DateTime.Now;
        //        db.grupo.Add(g);
        //        db.SaveChanges();
        //        response = new responseClass(201, g.id, "Grupo creado exitosamente", null);
        //    }
        //    catch (Exception ex)
        //    {
        //        response = new responseClass(500, null, "Error creando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
        //    }
        //    return response;
        //}

        //public responseClass actualizarPersona(personaDTO person)
        //{
        //    responseClass response;
        //    try
        //    {
        //        var g = db.grupo.Find(group.id);
        //        if (g == null)
        //            response = new responseClass(404, group.id, "No se encontro el grupo", null);

        //        g.nombre = group.nombre;
        //        db.SaveChanges();
        //        response = new responseClass(200, g.id, "Grupo actualizado exitosamente", null);
        //    }
        //    catch (Exception ex)
        //    {
        //        response = new responseClass(500, null, "Error actualizando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
        //    }
        //    return response;
        //}

        //public personaReadResponse leerPersona(int id)
        //{
        //    grupoReadResponse response;
        //    try
        //    {
        //        var g = db.grupo.Find(id);
        //        if (g == null)
        //            response = new grupoReadResponse(404, "No se encontro el grupo", null, null);

        //        grupoDTO gDTO = new grupoDTO(g);
        //        response = new grupoReadResponse(200, "OK", null, gDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        response = new grupoReadResponse(500, "Error obteniendo el grupo", ex.InnerException.Message + " " + ex.StackTrace, null);
        //    }
        //    return response;
        //}

        //public responseClass eliminarPersona(int id)
        //{
        //    responseClass response;
        //    try
        //    {
        //        var g = db.grupo.Find(id);
        //        if (g == null)
        //            response = new responseClass(404, id, "No se encontro el grupo", null);
        //        db.grupo.Remove(g);
        //        //Aqui hay que realizar las operaciones correspondientes para las configuraciones asociadas (o no permitir si hay asociadas)
        //        db.SaveChanges();
        //        response = new responseClass(200, id, "Grupo eliminado exitosamente", null);
        //    }
        //    catch (Exception ex)
        //    {
        //        response = new responseClass(500, null, "Error eliminando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
        //    }
        //    return response;
        //}
        #endregion

        #region Rol
        public response listarRol()
        {
            response response;
            List<rolDTO> rol_list = new List<rolDTO>();
            try
            {
                var rol = db.rol.ToList();
                foreach (var i in rol)
                {
                    rolDTO r = new rolDTO(i);
                    rol_list.Add(r);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(rol_list);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error listando los roles", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return response;
        }

        public response crearRol(rolDTO rol)
        {
            response response;
            try
            {
                rol r = new rol();
                r.fechaCreacion = DateTime.Now;
                r.nombre = rol.nombre;
                db.rol.Add(r);
                db.SaveChanges();
                foreach (var i in rol.permisos)
                {
                    rolPermiso rp = new rolPermiso();
                    rp.idRol = r.id;
                    rp.idPermiso = i.id;
                    db.rolPermiso.Add(rp);
                }
                db.SaveChanges();

                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(r);
                response = new response(201, json, "Rol creado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando el rol", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarRol(rolDTO rol)
        {
            response response;
            try
            {
                var r = db.rol.Find(rol.id);
                if (r == null)
                    response = new response(404, rol.id.ToString(), "No se encontro el rol", null);
                r.nombre = rol.nombre;

                var selectedP = new HashSet<int>(rol.permisos.Select(x => x.id));
                var currentP = new HashSet<int>(r.rolPermiso.Select(c => c.idPermiso));
                foreach (var p in db.permiso.ToList())
                {
                    if (selectedP.Contains(p.id))
                    {
                        if (!currentP.Contains(p.id))
                        {
                            rolPermiso rp = new rolPermiso();
                            rp.idPermiso = p.id;
                            r.rolPermiso.Add(rp);
                        }
                    }
                    else
                    {
                        if (currentP.Contains(p.id))
                        {
                            r.rolPermiso.Remove(r.rolPermiso.SingleOrDefault(x => x.idPermiso == p.id));
                        }
                    }
                }
                db.SaveChanges();
                rolDTO ro = new rolDTO(r);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(ro);
                response = new response(200, json, "Rol actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando el rol", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerRol(int id)
        {
            response response;
            try
            {
                var r = db.rol.Find(id);
                if (r == null)
                    response = new response(404, id.ToString(), "No se encontro el rol", null);
                rolDTO rDTO = new rolDTO(r);
                List<permisoDTO> permisos = new List<permisoDTO>();
                foreach (var i in r.rolPermiso)
                {
                    permisoDTO p = new permisoDTO(i.permiso);
                    permisos.Add(p);
                }
                rDTO.permisos = new List<permisoDTO>(permisos);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(rDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo el rol", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarRol(int id)
        {
            response response;
            try
            {
                var r = db.rol.Find(id);
                if (r == null)
                    response = new response(404, id.ToString(), "No se encontro el rol", null);

                var query = db.rolPermiso.Where(x => x.idRol == r.id).ToList();
                foreach (var i in query) 
                    db.rolPermiso.Remove(i);

                db.rol.Remove(r);
                db.SaveChanges();
                response = new response(200, id.ToString(), "Rol eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando el rol", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Factura
        public response listarFactura()
        {
            response pack;
            List<facturaDTO> invoice_list = new List<facturaDTO>();
            try
            {
                var invoices = db.factura.ToList();
                foreach (var i in invoices)
                {
                    facturaDTO p = new facturaDTO(i);
                    invoice_list.Add(p);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(invoice_list);
                pack = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                pack = new response(500, "", "Error listando las facturas", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return pack;
        }

        public response crearFactura(facturaDTO invoice)
        {
            response response;
            try
            {
                factura f = new factura();
                f.desde = invoice.desde;
                f.hasta = invoice.hasta;
                f.fechaPago = invoice.fechaPago;
                f.numero = invoice.numero;
                f.idCliente = invoice.idCliente;
                f.fechaCreacion = DateTime.Now;
                db.factura.Add(f);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(f);
                response = new response(201, json, "Factura creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando la factura", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarFactura(facturaDTO invoice)
        {
            response response;
            try
            {
                var f = db.factura.Find(invoice.id);
                if (f == null)
                    response = new response(404, invoice.id.ToString(), "No se encontro la factura", null);

                f.desde = f.desde;
                f.hasta = f.hasta;
                f.idCliente = f.idCliente;
                f.numero = f.numero;
                f.fechaPago = f.fechaPago;
                db.SaveChanges();
                facturaDTO fact = new facturaDTO(f);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(fact);
                response = new response(200, json, "Factura actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando la factura", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerFactura(int id)
        {
            response response;
            try
            {
                var f = db.factura.Find(id);
                if (f == null)
                    response = new response(404, id.ToString(), "No se encontro la factura", null);

                facturaDTO fDTO = new facturaDTO(f);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(fDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo la factura", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarFactura(int id)
        {
            response response;
            try
            {
                var f = db.factura.Find(id);
                if (f == null)
                    response = new response(404, id.ToString(), "No se encontro la factura", null);
                db.factura.Remove(f);
                //Aqui hay que realizar las operaciones correspondientes para las relaciones (o no permitir si hay asociadas)
                db.SaveChanges();
                response = new response(200, id.ToString(), "Factura eliminada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando la factura", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        
        #endregion

        #region Paquete
        public response listarPaquete(int id)
        {
            response pack;
            List<paqueteDTO> package_list = new List<paqueteDTO>();
            try
            {
                var paquetes = db.paquete.Where(x => x.idCliente == id).ToList();
                DateTime now = DateTime.Now;
                foreach (var i in paquetes)
                {
                    paqueteDTO p = new paqueteDTO(i);
                    if (i.costo.Count() > 0)
                    {
                        p.costo = new costoDTO(i.costo.SingleOrDefault(x => x.inicio < now && x.fin > now));
                    }
                    package_list.Add(p);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(package_list);
                pack = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                pack = new response(500, "", "Error listando los paquetes", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return pack;

        }

        public response crearPaquete(paqueteDTO package)
        {
            response response;
            try
            {
                paquete p = new paquete();
                p.nombre = package.nombre;
                p.fechaCreacion = DateTime.Now;
                p.idCliente = package.idCliente;
                db.paquete.Add(p);
                db.SaveChanges();
                foreach (var i in package.actividades)
                {
                    paqueteActividad pa = new paqueteActividad();
                    pa.idPaquete = p.id;
                    pa.idActividad = i.id;
                    db.paqueteActividad.Add(pa);
                }
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(p);
                response = new response(201, json, "Paquete creado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando el paquete", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarPaquete(paqueteDTO package)
        {
            response response;
            try
            {
                var p = db.paquete.Find(package.id);
                if (p == null)
                    response = new response(404, package.id.ToString(), "No se encontro el paquete", null);

                p.nombre = package.nombre;
                var selectedP = new HashSet<int>(package.actividades.Select(x => x.id));
                var currentP = new HashSet<int>(p.paqueteActividad.Select(c => c.idActividad));
                foreach (var pa in db.actividad.ToList())
                {
                    if (selectedP.Contains(pa.id))
                    {
                        if (!currentP.Contains(pa.id))
                        {
                            paqueteActividad paac = new paqueteActividad();
                            paac.idActividad = pa.id;
                            p.paqueteActividad.Add(paac);
                        }
                    }
                    else
                    {
                        if (currentP.Contains(pa.id))
                        {
                            p.paqueteActividad.Remove(p.paqueteActividad.SingleOrDefault(x => x.idActividad == pa.id));
                        }
                    }
                }
                db.SaveChanges();
                paqueteDTO paq = new paqueteDTO(p);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(paq);
                response = new response(200, json, "Paquete actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando el paquete", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerPaquete(int id)
        {
            response response;
            try
            {
                var p = db.paquete.Find(id);
                if (p == null)
                    response = new response(404, id.ToString(), "No se encontro el paquete", null);

                paqueteDTO pDTO = new paqueteDTO(p);
                List<actividadDTO> activity_list = new List<actividadDTO>();
                foreach(var i in p.paqueteActividad)
                {
                    actividadDTO a = new actividadDTO(i.actividad);
                    activity_list.Add(a);
                }
                pDTO.actividades = new List<actividadDTO>(activity_list);
                DateTime now = DateTime.Now;
                if (p.costo.Count() > 0)
                {
                    pDTO.costo = new costoDTO(p.costo.SingleOrDefault(x => x.inicio < now && x.fin > now));
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(pDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo el paquete", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarPaquete(int id)
        {
            response response;
            try
            {
                var p = db.paquete.Find(id);
                if (p == null)
                    response = new response(404, id.ToString(), "No se encontro el paquete", null);
                db.paquete.Remove(p);
                //Aqui hay que realizar las operaciones correspondientes para las relaciones (o no permitir si hay asociadas)
                db.SaveChanges();
                response = new response(200, id.ToString(), "Paquete eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando el paquete", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Costo
        public response listarCosto(int id)
        {
            response c;
            List<costoDTO> cost_list = new List<costoDTO>();
            try
            {
                var costos = db.costo.Where(x => x.idPaquete == id).ToList();
                foreach (var i in costos)
                {
                    costoDTO co = new costoDTO(i);
                    cost_list.Add(co);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(cost_list);
                c = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                c = new response(500, "", "Error listando los costos", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return c;

        }

        public response crearCosto(costoDTO cost)
        {
            response response;
            try
            {
                if (cost.fin < cost.inicio)
                {
                    return response = new response(400, "", "La fecha de fin debe ser mayor a la fecha de inicio", null);
                }
                else if (cost.costo1 < 0)
                {
                    return response = new response(400, "", "El costo debe ser mayor a 0", null);
                }
                else if (db.costo.Any(x => (x.inicio < cost.inicio && x.fin > cost.inicio) || (x.inicio < cost.fin && x.fin > cost.fin)))
                {
                    return response = new response(400, "", "El rango de fecha del costo coincide con un costo ya creado", null);
                }
                costo c = new costo();
                c.idPaquete = cost.idPaquete;
                c.fechaCreacion = DateTime.Now;
                c.costo1 = cost.costo1;
                c.inicio = cost.inicio;
                c.fin = cost.fin;
                db.costo.Add(c);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(c);
                response = new response(201, json, "Costo creado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando el costo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarCosto(costoDTO cost)
        {
            response response;
            try
            {
                var c = db.costo.Find(cost.id);
                if (c == null)
                    response = new response(404, cost.id.ToString(), "No se encontro el costo", null);

                c.costo1 = cost.costo1;
                c.inicio = cost.inicio;
                c.fin = cost.fin;
                db.SaveChanges();
                costoDTO cos = new costoDTO(c);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(cos);
                response = new response(200, json, "Costo actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando el costo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerCosto(int id)
        {
            response response;
            try
            {
                var c = db.costo.Find(id);
                if (c == null)
                    response = new response(404, id.ToString(), "No se encontro el costo", null);

                costoDTO cDTO = new costoDTO(c);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(cDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo el costo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarCosto(int id)
        {
            response response;
            try
            {
                var c = db.costo.Find(id);
                if (c == null)
                    response = new response(404, id.ToString(), "No se encontro el costo", null);
                db.costo.Remove(c);
                db.SaveChanges();
                response = new response(200, id.ToString(), "Costo eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando el costo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region informacionAfiliado
        public response listarInfoAfiliado(int id)
        {
            response response;
            List<infoAfiDTO> info_list = new List<infoAfiDTO>();
            try
            {
                var afiliados = db.informacionAfiliado.Where(x => x.id == id).ToList();
                foreach (var i in afiliados)
                {
                    infoAfiDTO info = new infoAfiDTO(i);
                    info_list.Add(info);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(info_list);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error listando la información de los afiliados", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return response;
        }

        public response crearInfoAfiliado(infoAfiDTO info)
        {
            response response;
            try
            {
                informacionAfiliado ia = new informacionAfiliado();
                ia.atributo = info.atributo;
                ia.tipoValor = info.tipoValor;
                ia.requerido = info.requerido;
                ia.vigente = info.vigente;
                ia.idCliente = info.idCliente;
                db.informacionAfiliado.Add(ia);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(ia);
                response = new response(201, json, "Información de afiliado creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando la información de afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarInfoAfiliado(infoAfiDTO info)
        {
            response response;
            try
            {
                var ia = db.informacionAfiliado.Find(info.id);
                if (ia == null)
                    response = new response(404, info.id.ToString(), "No se encontro la información de afiliado", null);
                ia.atributo = info.atributo;
                ia.requerido = info.requerido;
                ia.vigente = info.vigente;
                db.SaveChanges();
                infoAfiDTO infAf = new infoAfiDTO(ia);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(infAf);
                response = new response(200, json, "Información de afiliado actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando la información de afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerInfoAfiliado(int id)
        {
            response response;
            try
            {
                var ia = db.informacionAfiliado.Find(id);
                if (ia == null)
                    response = new response(404, id.ToString(), "No se encontro la información del afiliado", null);
                infoAfiDTO iaDTO = new infoAfiDTO(ia);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(iaDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo la informacion de afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarInfoAfiliado(int id)
        {
            response response;
            try
            {
                var ia = db.informacionAfiliado.Find(id);
                if (ia == null)
                    response = new response(404, id.ToString(), "No se encontro la información de afiliado", null);
                db.informacionAfiliado.Remove(ia);
                //Aqui hay que realizar las operaciones correspondientes para eliminar las entidades asociadas
                db.SaveChanges();
                response = new response(200, id.ToString(), "Información de afiliado eliminada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando la información de afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        #endregion

        #region informacionEmpleado
        public response listarInfoEmpleado(int id)
        {
            response response;
            List<infoEmpleDTO> info_list = new List<infoEmpleDTO>();
            try
            {
                var empleados = db.informacionEmpleado.Where(x => x.id == id).ToList();
                foreach (var i in empleados)
                {
                    infoEmpleDTO info = new infoEmpleDTO(i);
                    info_list.Add(info);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(info_list);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error listando la información de los empleados", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return response;
        }

        public response crearInfoEmpleado(infoEmpleDTO info)
        {
            response response;
            try
            {
                informacionEmpleado ia = new informacionEmpleado();
                ia.atributo = info.atributo;
                ia.tipoValor = info.tipoValor;
                ia.requerido = info.requerido;
                ia.vigente = info.vigente;
                ia.idCliente = info.idCliente;
                db.informacionEmpleado.Add(ia);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(ia);
                response = new response(201, json, "información de empleado creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando la información del empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarInfoEmpleado(infoEmpleDTO info)
        {
            response response;
            try
            {
                var ia = db.informacionEmpleado.Find(info.id);
                if (ia == null)
                    response = new response(404, info.id.ToString(), "No se encontro la información de empleado", null);
                ia.atributo = info.atributo;
                ia.requerido = info.requerido;
                ia.vigente = info.vigente;
                db.SaveChanges();
                infoEmpleDTO infEm = new infoEmpleDTO(ia);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(infEm);
                response = new response(200, json, "Información de empleado actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando la información de empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerInfoEmpleado(int id)
        {
            response response;
            try
            {
                var ie = db.informacionEmpleado.Find(id);
                if (ie == null)
                    response = new response(404, id.ToString(), "No se encontro la información de empleado", null);
                infoEmpleDTO ieDTO = new infoEmpleDTO(ie);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(ieDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo la información de empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarInfoEmpleado(int id)
        {
            response response;
            try
            {
                var ie = db.informacionEmpleado.Find(id);
                if (ie == null)
                    response = new response(404, id.ToString(), "No se encontro la información de empleado", null);
                db.informacionEmpleado.Remove(ie);
                //Aqui hay que realizar las operaciones correspondientes para eliminar las entidades asociadas
                db.SaveChanges();
                response = new response(200, id.ToString(), "Información de empleado eliminada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando la información de empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }


        #endregion

        #region Empleado
        public response listarEmpleado(int id)
        {
            response pe;
            List<empleadoDTO> employee_list = new List<empleadoDTO>();
            try
            {
                var empleados = db.empleado.Where(x => x.persona.idCliente == id).ToList();
                foreach (var i in empleados)
                { 
                    empleadoDTO e = new empleadoDTO(i);
                    employee_list.Add(e);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(employee_list);
                pe = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                pe = new response(500, "", "Error listando a los empleados", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return pe;
        }

        public response crearEmpleado(empleadoDTO employee)
        {
            response response;
            try
            {
                persona p = new persona();
                p.apellido = employee.apellido;
                p.dni = employee.dni;
                p.fechaCreacion = DateTime.Now;
                p.fechaNacimiento = employee.fechaNacimiento;
                p.idCliente = employee.idCliente;
                p.idRol = employee.idRol;
                p.nombre = employee.nombre;
                p.sexo = employee.sexo;
                p.empleado = new empleado();
                p.empleado.sueldo = employee.sueldo;
                p.empleado.cargo = employee.cargo;
                db.persona.Add(p);                
                db.SaveChanges();
                empleadoDTO emple = new empleadoDTO(p.empleado);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(emple);
                response = new response(201, json, "Empleado creado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, null, "Error creando al empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarEmpleado(empleadoDTO employee)
        {
            response response;
            try
            {
                var e = db.empleado.Find(employee.id);
                if (e == null)
                    response = new response(404, employee.id.ToString(), "No se encontro al empleado", null);
                e.cargo = employee.cargo;
                e.sueldo = employee.sueldo;
                e.persona.apellido = employee.apellido;
                e.persona.dni = employee.dni;
                e.persona.fechaNacimiento = employee.fechaNacimiento;
                e.persona.idRol = employee.idRol;
                e.persona.nombre = employee.nombre;
                e.persona.sexo = employee.sexo;        
                db.SaveChanges();
                empleadoDTO emple = new empleadoDTO(e);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(emple);
                response = new response(200, json, "Empleado actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando al empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerEmpleado(int id)
        {
            response response;
            try
            {
                var e = db.empleado.Find(id);
                if (e == null)
                    response = new response(404, id.ToString(), "No se encontro al empleado", null);

                empleadoDTO eDTO = new empleadoDTO(e);
                List<infoPersonaDTO> info_list = new List<infoPersonaDTO>();
                foreach (var i in e.informacionEmpleadoEmpleado)
                {
                    infoPersonaDTO a = new infoPersonaDTO(i);
                    info_list.Add(a);
                }
                eDTO.info = new List<infoPersonaDTO>(info_list);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(eDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo el empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarEmpleado(int id)
        {
            response response;
            try
            {
                var e = db.persona.Find(id);
                if (e == null)
                    response = new response(404, id.ToString(), "No se encontro el empleado", null);
                db.empleado.Remove(e.empleado);
                db.persona.Remove(e);
                //Aqui hay que realizar las operaciones correspondientes para las relaciones (o no permitir si hay asociadas)
                db.SaveChanges();
                response = new response(200, id.ToString(), "Empleado eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando al empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Afiliado
        public response listarAfiliado(int id)
        {
            response pe;
            List<afiliadoDTO> affiliate_list = new List<afiliadoDTO>();
            try
            {
                var afiliados = db.afiliado.Where(x => x.persona.idCliente == id).ToList();
                foreach (var i in afiliados)
                {
                    afiliadoDTO e = new afiliadoDTO(i);
                    affiliate_list.Add(e);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(affiliate_list);
                pe = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                pe = new response(500, "", "Error listando a los afiliados", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return pe;
        }

        public response crearAfiliado(afiliadoDTO affiliate)
        {
            response response;
            try
            {
                persona p = new persona();
                p.apellido = affiliate.apellido;
                p.dni = affiliate.dni;
                p.fechaCreacion = DateTime.Now;
                p.fechaNacimiento = affiliate.fechaNacimiento;
                p.idCliente = affiliate.idCliente;
                p.idRol = affiliate.idRol;
                p.nombre = affiliate.nombre;
                p.sexo = affiliate.sexo;
                p.afiliado = new afiliado();
                db.persona.Add(p);
                db.SaveChanges();
                afiliadoDTO afi = new afiliadoDTO(p.afiliado);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(afi);
                response = new response(201, json, "Afiliado creado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, null, "Error creando al afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarAfiliado(afiliadoDTO affiliate)
        {
            response response;
            try
            {
                var a = db.afiliado.Find(affiliate.id);
                if (a == null)
                    response = new response(404, affiliate.id.ToString(), "No se encontro al afiliado", null);
                a.persona.apellido = affiliate.apellido;
                a.persona.dni = affiliate.dni;
                a.persona.fechaNacimiento = affiliate.fechaNacimiento;
                a.persona.idRol = affiliate.idRol;
                a.persona.nombre = affiliate.nombre;
                a.persona.sexo = affiliate.sexo;
                db.SaveChanges();
                afiliadoDTO emple = new afiliadoDTO(a);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(emple);
                response = new response(200, json, "Afiliado actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando al empleado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response leerAfiliado(int id)
        {
            response response;
            try
            {
                var a = db.afiliado.Find(id);
                if (a == null)
                    response = new response(404, id.ToString(), "No se encontro al afiliado", null);

                afiliadoDTO aDTO = new afiliadoDTO(a);
                List<infoPersonaDTO> info_list = new List<infoPersonaDTO>();
                foreach (var i in a.informacionAfiliadoAfiliado)
                {
                    infoPersonaDTO inf = new infoPersonaDTO(i);
                    info_list.Add(inf);
                }
                aDTO.info = new List<infoPersonaDTO>(info_list);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(aDTO);
                response = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error obteniendo el afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarAfiliado(int id)
        {
            response response;
            try
            {
                var a = db.persona.Find(id);
                if (a == null)
                    response = new response(404, id.ToString(), "No se encontro al afiliado", null);
                db.afiliado.Remove(a.afiliado);
                db.persona.Remove(a);
                //Aqui hay que realizar las operaciones correspondientes para las relaciones (o no permitir si hay asociadas)
                db.SaveChanges();
                response = new response(200, id.ToString(), "Afiliado eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando al afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region AfiliadoPaquete
        public response listarAfiliadoPaquete(int? idAfiliado, int? idPaquete)
        {
            response response;
            List<afiliadoPaqueteDTO> list = new List<afiliadoPaqueteDTO>();
            try
            {
                if (idAfiliado == null && idPaquete == null)
                {
                    response = new response(400, "", "Error listando los paquetes de los afiliados", null);
                }
                else if (idAfiliado != null && idPaquete == null)
                {
                    var afiPaque = db.afiliadoPaquete.Where(x => x.idAfiliado == idAfiliado).ToList();
                    foreach (var i in afiPaque)
                    {
                        afiliadoPaqueteDTO c = new afiliadoPaqueteDTO(i);
                        list.Add(c);
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string json = js.Serialize(list);
                    response = new response(200, json, "OK", null);
                }
                else if (idAfiliado == null && idPaquete != null)
                {
                    var afiPaque = db.afiliadoPaquete.Where(x => x.idPaquete == idPaquete).ToList();
                    foreach (var i in afiPaque)
                    {
                        afiliadoPaqueteDTO c = new afiliadoPaqueteDTO(i);
                        list.Add(c);
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string json = js.Serialize(list);
                    response = new response(200, json, "OK", null);
                }
                else
                {
                    var afiPaque = db.afiliadoPaquete.Where(x => x.idPaquete == idPaquete && x.idAfiliado == idAfiliado).ToList();
                    foreach (var i in afiPaque)
                    {
                        afiliadoPaqueteDTO c = new afiliadoPaqueteDTO(i);
                        list.Add(c);
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string json = js.Serialize(list);
                    response = new response(200, json, "OK", null);
                }
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error listando los paquetes de los afiliados", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return response;
        }

        public response crearAfiliadoPaquete(afiliadoPaqueteDTO afiPaque)
        {
            response response;
            try
            {
                afiliadoPaquete ap = new afiliadoPaquete();
                ap.idAfiliado = afiPaque.idAfiliado;
                ap.idPaquete = afiPaque.idPaquete;
                ap.desde = afiPaque.desde;
                ap.hasta = afiPaque.hasta;
                ap.cantidad = afiPaque.cantidad;
                db.afiliadoPaquete.Add(ap);
                db.SaveChanges();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(ap);
                response = new response(201, json, "Paquete asociado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error creando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response actualizarAfiliadoPaquete(afiliadoPaqueteDTO afiPaque)
        {
            response response;
            try
            {
                var ap = db.afiliadoPaquete.Find(afiPaque.id);
                if (ap == null)
                    response = new response(404, afiPaque.id.ToString(), "No se encontro el recurso indicado", null);
                ap.desde = afiPaque.desde;
                ap.hasta = afiPaque.hasta;
                ap.cantidad = afiPaque.cantidad;
                ap.idPaquete = afiPaque.idPaquete;
                db.SaveChanges();
                afiliadoPaqueteDTO afp = new afiliadoPaqueteDTO(ap);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(afp);
                response = new response(200, json, "Paquete de afiliado actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error actualizando el paquete del afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public response eliminarAfiliadoPaquete(int id)
        {
            response response;
            try
            {
                var ap = db.afiliadoPaquete.Find(id);
                db.afiliadoPaquete.Remove(ap);
                db.SaveChanges();
                response = new response(200, id.ToString(), "Paquete de afiliado eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new response(500, "", "Error eliminando el paquete del afiliado", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Estado
        public response listarEstado()
        {
            response es;
            List<estadoDTO> state_list = new List<estadoDTO>();
            try
            {
                var estados = db.estado.ToList();
                foreach (var i in estados)
                {
                    estadoDTO e = new estadoDTO(i);
                    state_list.Add(e);
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(state_list);

                es = new response(200, json, "OK", null);
            }
            catch (Exception ex)
            {
                es = new response(500, "", "Error listando los estados", ex.InnerException.Message + " " + ex.StackTrace);
            }

            return es;

        }

        #endregion

    }
}
