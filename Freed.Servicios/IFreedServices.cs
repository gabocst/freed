using Freed.Servicios.DAL;
using Freed.Servicios.DTO;
using Freed.Servicios.Models.actividad;
using Freed.Servicios.Models.cliente;
using Freed.Servicios.Models.configuracion;
using Freed.Servicios.Models.configuracionCliente;
using Freed.Servicios.Models.grupo;
using Freed.Servicios.Models.persona;
using Freed.Servicios.Models.rol;
using Freed.Servicios.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Freed.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFreedServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFreedServices
    {

        #region Grupo
        [OperationContract]
        grupoListResponse listarGrupo();

        [OperationContract]
        responseClass crearGrupo(grupoDTO group);

        [OperationContract]
        responseClass actualizarGrupo(grupoDTO group);

        [OperationContract]
        grupoReadResponse leerGrupo(int id);

        [OperationContract]
        responseClass eliminarGrupo(int id);

        #endregion

        #region Configuracion
        [OperationContract]
        configuracionListResponse listarConfiguracion();

        [OperationContract]
        responseClass crearConfiguracion(configuracionDTO config);

        [OperationContract]
        responseClass actualizarConfiguracion(configuracionDTO config);

        [OperationContract]
        configuracionReadResponse leerConfiguracion(int id);

        [OperationContract]
        responseClass eliminarConfiguracion(int id);

        #endregion

        #region Cliente
        [OperationContract]
        clienteListResponse listarCliente();

        [OperationContract]
        responseClass crearCliente(clienteDTO config);

        [OperationContract]
        responseClass actualizarCliente(clienteDTO config);

        [OperationContract]
        clienteReadResponse leerCliente(int id);

        [OperationContract]
        responseClass eliminarCliente(int id);

        #endregion

        #region ConfiguracionCliente
        [OperationContract]
        configuracionClienteListResponse listarConfiguracionCliente();

        [OperationContract]
        responseClass crearConfiguracionCliente(configuracionClienteDTO config);

        [OperationContract]
        responseClass actualizarConfiguracionCliente(configuracionClienteDTO config);

        [OperationContract]
        configuracionClienteReadResponse leerConfiguracionCliente(int id);

        [OperationContract]
        responseClass eliminarConfiguracionCliente(int id);

        #endregion

        #region Actividad
        [OperationContract]
        actividadListResponse listarActividad();

        [OperationContract]
        responseClass crearActividad(actividadDTO activity);

        [OperationContract]
        responseClass actualizarActividad(actividadDTO activity);

        [OperationContract]
        actividadReadResponse leerActividad(int id);

        [OperationContract]
        responseClass eliminarActividad(int id);

        #endregion

        #region Persona
        [OperationContract]
        personaListResponse listarPersona();

        //[OperationContract]
        //responseClass crearPersona(personaDTO person);

        //[OperationContract]
        //responseClass actualizarPersona(personaDTO person);

        //[OperationContract]
        //personaReadResponse leerPersona(int id);

        //[OperationContract]
        //responseClass eliminarPersona(int id);

        #endregion

        #region rol
        [OperationContract]
        rolListResponse listarRol();

        [OperationContract]
        responseClass crearRol(rolDTO rol);

        [OperationContract]
        responseClass actualizarRol(rolDTO rol);

        [OperationContract]
        rolReadResponse leerRol(int id);

        [OperationContract]
        responseClass eliminarRol(int id);

        #endregion

        #region factura
        [OperationContract]
        rolListResponse listarFactura();

        [OperationContract]
        responseClass crearFactura(facturaDTO factura);

        [OperationContract]
        responseClass actualizarFactura(facturaDTO factura);

        [OperationContract]
        rolReadResponse leerFactura(int id);

        [OperationContract]
        responseClass eliminarFactura(int id);

        #endregion

    }
}
