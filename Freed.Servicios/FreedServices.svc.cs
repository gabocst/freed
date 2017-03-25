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

namespace Freed.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FreedServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FreedServices.svc o FreedServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FreedServices : IFreedServices
    {
        private freedEntities db = new freedEntities();

        #region Grupo
        public grupoListResponse listarGrupo()
        {  
            grupoListResponse gl;
            List<grupoDTO> group_list = new List<grupoDTO>();
            try {
                var grupos = db.grupo.ToList();
                foreach (var i in grupos)
                {
                    grupoDTO g = new grupoDTO(i);
                    group_list.Add(g);
                }
                gl = new grupoListResponse(200, "OK", null, group_list);
            }
            catch (Exception ex) {
                gl = new grupoListResponse(500, "Error listando los grupos", ex.InnerException.Message + " " + ex.StackTrace, null);
            }

            return gl;

        }

        public responseClass crearGrupo(grupoDTO group)
        {
            responseClass response;
            try
            {
                grupo g = new grupo();
                g.nombre = group.nombre;
                g.fechaCreacion = DateTime.Now;
                db.grupo.Add(g);
                db.SaveChanges();
                response = new responseClass(201, g.id, "Grupo creado exitosamente", null);
            }
            catch(Exception ex)
            {
                response = new responseClass(500, null, "Error creando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public responseClass actualizarGrupo(grupoDTO group)
        {
            responseClass response;
            try
            {
                var g = db.grupo.Find(group.id);
                if (g == null) 
                    response = new responseClass(404, group.id, "No se encontro el grupo", null);
                
                g.nombre = group.nombre;
                db.SaveChanges();
                response = new responseClass(200, g.id, "Grupo actualizado exitosamente", null);
            }
            catch(Exception ex)
            {
                response = new responseClass(500, null, "Error actualizando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public grupoReadResponse leerGrupo(int id)
        {
            grupoReadResponse response;
            try
            {
                var g = db.grupo.Find(id);
                if (g==null)
                    response = new grupoReadResponse(404,"No se encontro el grupo", null, null);

                grupoDTO gDTO = new grupoDTO(g);
                response = new grupoReadResponse(200, "OK", null, gDTO);
            }
            catch(Exception ex)
            {
                response = new grupoReadResponse(500, "Error obteniendo el grupo", ex.InnerException.Message + " " + ex.StackTrace, null);
            }
            return response;
        }

        public responseClass eliminarGrupo(int id)
        {
            responseClass response;
            try
            {
                var g = db.grupo.Find(id);
                if (g == null)
                    response = new responseClass(404, id, "No se encontro el grupo", null);
                db.grupo.Remove(g);
                //Aqui hay que realizar las operaciones correspondientes para las configuraciones asociadas (o no permitir si hay asociadas)
                db.SaveChanges();
                response = new responseClass(200, id, "Grupo eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error eliminando el grupo", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Configuracion
        public configuracionListResponse listarConfiguracion()
        {
            configuracionListResponse response;
            List<configuracionDTO> configuration_list = new List<configuracionDTO>();
            try
            {
                var config = db.configuracion.ToList();
                foreach (var i in config)
                {
                    configuracionDTO c = new configuracionDTO(i);
                    configuration_list.Add(c);
                }
                response = new configuracionListResponse(200, "OK", null, configuration_list);
            }
            catch (Exception ex)
            {
                response = new configuracionListResponse(500, "Error listando las configuraciones", ex.InnerException.Message + " " + ex.StackTrace, null);
            }

            return response;
        }

        public responseClass crearConfiguracion(configuracionDTO configuration)
        {
            responseClass response;
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
                response = new responseClass(201, c.id, "Configuración creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error creando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public responseClass actualizarConfiguracion(configuracionDTO config)
        {
            responseClass response;
            try
            {
                var c = db.configuracion.Find(config.id);
                if (c == null)
                    response = new responseClass(404, config.id, "No se encontro la configuracion", null);
                c.atributo = config.atributo;
                c.descripcion = config.descripcion;
                c.idGrupo = config.idGrupo;
                c.requerido = config.requerido;
                c.tipoValor = config.tipoValor;
                db.SaveChanges();
                response = new responseClass(200, c.id, "Configuración actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error actualizando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public configuracionReadResponse leerConfiguracion(int id)
        {
            configuracionReadResponse response;
            try
            {
                var c = db.configuracion.Find(id);
                if (c == null)
                    response = new configuracionReadResponse(404, "No se encontro la configuracion", null, null);
                configuracionDTO cDTO = new configuracionDTO(c);
                response = new configuracionReadResponse(200, "OK", null, cDTO);
            }
            catch (Exception ex)
            {
                response = new configuracionReadResponse(500, "Error obteniendo la configuración", ex.InnerException.Message + " " + ex.StackTrace, null);
            }
            return response;
        }

        public responseClass eliminarConfiguracion(int id)
        {
            responseClass response;
            try
            {
                var c = db.configuracion.Find(id);
                if (c == null)
                    response = new responseClass(404,id, "No se encontro la configuracion", null);
                db.configuracion.Remove(c);
                //Aqui hay que realizar las operaciones correspondientes para eliminar las configuracionCliente asociadas
                db.SaveChanges();
                response = new responseClass(200, id, "Configuración eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error eliminando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Cliente
        public clienteListResponse listarCliente()
        {
            clienteListResponse response;
            List<clienteDTO> client_list = new List<clienteDTO>();
            try
            {
                var client = db.cliente.ToList();
                foreach (var i in client)
                {
                    clienteDTO c = new clienteDTO(i);
                    client_list.Add(c);
                }
                response = new clienteListResponse(200, "OK", null, client_list);
            }
            catch (Exception ex)
            {
                response = new clienteListResponse(500, "Error listando los clientes", ex.InnerException.Message + " " + ex.StackTrace, null);
            }

            return response;
        }

        public responseClass crearCliente(clienteDTO client)
        {
            responseClass response;
            try
            {
                cliente c = new cliente();
                c.fechaCreacion = DateTime.Now;
                c.correo = client.correo;
                c.idEstado = client.idEstado;
                c.nombre = client.nombre;
                db.cliente.Add(c);
                db.SaveChanges();
                response = new responseClass(201, c.id, "Cliente creado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error creando al cliente", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public responseClass actualizarCliente(clienteDTO client)
        {
            responseClass response;
            try
            {
                var c = db.cliente.Find(client.id);
                if (c == null)
                    response = new responseClass(404, client.id, "No se encontro al cliente", null);
                c.correo = client.correo;
                c.idEstado = client.idEstado;
                c.nombre = client.nombre;
                db.SaveChanges();
                response = new responseClass(200, c.id, "Cliente actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error actualizando al cliente", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public clienteReadResponse leerCliente(int id)
        {
            clienteReadResponse response;
            try
            {
                var c = db.cliente.Find(id);
                if (c == null)
                    response = new clienteReadResponse(404, "No se encontro al cliente", null, null);
                clienteDTO cDTO = new clienteDTO(c);
                response = new clienteReadResponse(200, "OK", null, cDTO);
            }
            catch (Exception ex)
            {
                response = new clienteReadResponse(500, "Error obteniendo al cliente", ex.InnerException.Message + " " + ex.StackTrace, null);
            }
            return response;
        }

        public responseClass eliminarCliente(int id)
        {
            responseClass response;
            try
            {
                var c = db.cliente.Find(id);
                if (c == null)
                    response = new responseClass(404, id, "No se encontro al cliente", null);
                c.idEstado = db.estado.SingleOrDefault(x => x.nombre == "Inactivo").id;
                //Aqui hay que realizar las operaciones correspondientes de cuando se inactiva un cliente
                db.SaveChanges();
                response = new responseClass(200, id, "Cliente inactivado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error inactivando al cliente", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region ConfiguracionCliente
        public configuracionClienteListResponse listarConfiguracionCliente()
        {
            configuracionClienteListResponse response;
            List<configuracionClienteDTO> configuration_list = new List<configuracionClienteDTO>();
            try
            {
                var config = db.configuracionCliente.ToList();
                foreach (var i in config)
                {
                    configuracionClienteDTO c = new configuracionClienteDTO(i);
                    configuration_list.Add(c);
                }
                response = new configuracionClienteListResponse(200, "OK", null, configuration_list);
            }
            catch (Exception ex)
            {
                response = new configuracionClienteListResponse(500, "Error listando las configuraciones", ex.InnerException.Message + " " + ex.StackTrace, null);
            }

            return response;
        }

        public responseClass crearConfiguracionCliente(configuracionClienteDTO configuration)
        {
            responseClass response;
            try
            {
                configuracionCliente c = new configuracionCliente();
                c.idCliente = configuration.idCliente;
                c.idConfiguracion = configuration.idConfiguracion;
                c.valor = configuration.valor;
                db.configuracionCliente.Add(c);
                db.SaveChanges();
                response = new responseClass(201, c.id, "Configuración creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error creando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public responseClass actualizarConfiguracionCliente(configuracionClienteDTO config)
        {
            responseClass response;
            try
            {
                var c = db.configuracionCliente.Find(config.id);
                if (c == null)
                    response = new responseClass(404, config.id, "No se encontro la configuracion", null);
                c.valor = config.valor;
                db.SaveChanges();
                response = new responseClass(200, c.id, "Configuración actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error actualizando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public configuracionClienteReadResponse leerConfiguracionCliente(int id)
        {
            configuracionClienteReadResponse response;
            try
            {
                var c = db.configuracionCliente.Find(id);
                if (c == null)
                    response = new configuracionClienteReadResponse(404, "No se encontro la configuracion", null, null);
                configuracionClienteDTO cDTO = new configuracionClienteDTO(c);
                response = new configuracionClienteReadResponse(200, "OK", null, cDTO);
            }
            catch (Exception ex)
            {
                response = new configuracionClienteReadResponse(500, "Error obteniendo la configuración", ex.InnerException.Message + " " + ex.StackTrace, null);
            }
            return response;
        }

        public responseClass eliminarConfiguracionCliente(int id)
        {
            responseClass response;
            try
            {
                var c = db.configuracionCliente.Find(id);
                db.configuracionCliente.Remove(c);
                db.SaveChanges();
                response = new responseClass(200, id, "Configuración eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error eliminando la configuración", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Actividad
        public actividadListResponse listarActividad()
        {
            actividadListResponse gl;
            List<actividadDTO> activity_list = new List<actividadDTO>();
            try
            {
                var actividades = db.actividad.ToList();
                foreach (var i in actividades)
                { 
                    actividadDTO g = new actividadDTO(i);
                    activity_list.Add(g);
                }
                gl = new actividadListResponse(200, "OK", null, activity_list);
            }
            catch (Exception ex)
            {
                gl = new actividadListResponse(500, "Error listando las actividades", ex.InnerException.Message + " " + ex.StackTrace, null);
            }

            return gl;

        }

        public responseClass crearActividad(actividadDTO activity)
        {
            responseClass response;
            try
            {
                actividad a = new actividad();
                a.nombre = activity.nombre;
                a.fechaCreacion = DateTime.Now;
                db.actividad.Add(a);
                db.SaveChanges();
                response = new responseClass(201, a.id, "Actividad creada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error creando la actividad", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public responseClass actualizarActividad(actividadDTO activity)
        {
            responseClass response;
            try
            {
                var a = db.grupo.Find(activity.id);
                if (a == null)
                    response = new responseClass(404, activity.id, "No se encontro la actividad", null);

                a.nombre = activity.nombre;
                db.SaveChanges();
                response = new responseClass(200, a.id, "Actividad actualizada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error actualizando la actividad", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public actividadReadResponse leerActividad(int id)
        {
            actividadReadResponse response;
            try
            {
                var a = db.actividad.Find(id);
                if (a == null)
                    response = new actividadReadResponse(404, "No se encontro la actividad", null, null);

                actividadDTO aDTO = new actividadDTO(a);
                response = new actividadReadResponse(200, "OK", null, aDTO);
            }
            catch (Exception ex)
            {
                response = new actividadReadResponse(500, "Error obteniendo la actividad", ex.InnerException.Message + " " + ex.StackTrace, null);
            }
            return response;
        }

        public responseClass eliminarActividad(int id)
        {
            responseClass response;
            try
            {
                var a = db.actividad.Find(id);
                if (a == null)
                    response = new responseClass(404, id, "No se encontro la actividad", null);
                db.actividad.Remove(a);
                //Aqui hay que realizar las operaciones correspondientes para las configuraciones asociadas (o no permitir si hay asociadas)
                db.SaveChanges();
                response = new responseClass(200, id, "Actividad eliminada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error eliminando la actividad", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region PaqueteActividad
        public responseClass crearPaqueteActividad(paqueteActividadDTO packageActiviy)
        {
            responseClass response;
            try
            {
                paqueteActividad pa = new paqueteActividad();
                pa.idActividad = packageActiviy.idActividad;
                pa.idPaquete = packageActiviy.idPaquete;
                db.paqueteActividad.Add(pa);
                db.SaveChanges();
                response = new responseClass(201, pa.id, "Actividad asociada exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error asociado la actividad", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion

        #region Persona
        public personaListResponse listarPersona()
        {
            personaListResponse gl;
            List<personaDTO> person_list = new List<personaDTO>();
            try
            {
                var personas = db.persona.ToList();
                foreach (var i in personas)
                {
                    personaDTO p = new personaDTO(i);
                    person_list.Add(p);
                }
                gl = new personaListResponse(200, "OK", null, person_list);
            }
            catch (Exception ex)
            {
                gl = new personaListResponse(500, "Error listando a las personas", ex.InnerException.Message + " " + ex.StackTrace, null);
            }

            return gl;

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
        public rolListResponse listarRol()
        {
            rolListResponse response;
            List<rolDTO> rol_list = new List<rolDTO>();
            try
            {
                var rol = db.rol.ToList();
                foreach (var i in rol)
                {
                    rolDTO r = new rolDTO(i);
                    rol_list.Add(r);
                }
                response = new rolListResponse(200, "OK", null, rol_list);
            }
            catch (Exception ex)
            {
                response = new rolListResponse(500, "Error listando los roles", ex.InnerException.Message + " " + ex.StackTrace, null);
            }

            return response;
        }

        public responseClass crearRol(rolDTO rol)
        {
            responseClass response;
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

                
                response = new responseClass(201, r.id, "Rol creado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error creando el rol", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public responseClass actualizarRol(rolDTO rol)
        {
            responseClass response;
            try
            {
                var r = db.rol.Find(rol.id);
                if (r == null)
                    response = new responseClass(404, rol.id, "No se encontro el rol", null);
                r.nombre = rol.nombre;

                //foreach (var i in r.rolPermiso)
                //{
                //    if (!rol.permisos.Any(x => x.id == i.idPermiso))
                //    {
                //        var rolp = db.rolPermiso.SingleOrDefault(x => x.id == )
                //    }
                //}

                db.SaveChanges();
                response = new responseClass(200, r.id, "Rol actualizado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error actualizando el rol", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }

        public rolReadResponse leerRol(int id)
        {
            rolReadResponse response;
            try
            {
                var r = db.rol.Find(id);
                if (r == null)
                    response = new rolReadResponse(404, "No se encontro el rol", null, null, null);
                rolDTO rDTO = new rolDTO(r);
                List<permisoDTO> permisos = new List<permisoDTO>();
                foreach (var i in r.rolPermiso)
                {
                    permisoDTO p = new permisoDTO(i.permiso);
                    permisos.Add(p);
                }
                response = new rolReadResponse(200, "OK", null, rDTO, permisos);
            }
            catch (Exception ex)
            {
                response = new rolReadResponse(500, "Error obteniendo el rol", ex.InnerException.Message + " " + ex.StackTrace, null, null);
            }
            return response;
        }

        public responseClass eliminarRol(int id)
        {
            responseClass response;
            try
            {
                var r = db.rol.Find(id);
                if (r == null)
                    response = new responseClass(404, id, "No se encontro el rol", null);

                var query = db.rolPermiso.Where(x => x.idRol == r.id).ToList();
                foreach (var i in query) 
                    db.rolPermiso.Remove(i);

                db.rol.Remove(r);
                db.SaveChanges();
                response = new responseClass(200, id, "Rol eliminado exitosamente", null);
            }
            catch (Exception ex)
            {
                response = new responseClass(500, null, "Error eliminando el rol", ex.InnerException.Message + " " + ex.StackTrace);
            }
            return response;
        }
        #endregion




    }
}
