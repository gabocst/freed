using Freed.Servicios.DAL;
using Freed.Servicios.DTO;
using Freed.Servicios.Models.actividad;
using Freed.Servicios.Models.cliente;
using Freed.Servicios.Models.configuracion;
using Freed.Servicios.Models.configuracionCliente;
using Freed.Servicios.Models.costo;
using Freed.Servicios.Models.factura;
using Freed.Servicios.Models.grupo;
using Freed.Servicios.Models.informacionAfiliado;
using Freed.Servicios.Models.paquete;
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
        response listarGrupo();

        [OperationContract]
        response crearGrupo(grupoDTO group);

        [OperationContract]
        response actualizarGrupo(grupoDTO group);

        [OperationContract]
        response leerGrupo(int id);

        [OperationContract]
        response eliminarGrupo(int id);

        #endregion

        #region Configuracion
        [OperationContract]
        response listarConfiguracion();

        [OperationContract]
        response crearConfiguracion(configuracionDTO config);

        [OperationContract]
        response actualizarConfiguracion(configuracionDTO config);

        [OperationContract]
        response leerConfiguracion(int id);

        [OperationContract]
        response eliminarConfiguracion(int id);

        #endregion

        #region Cliente
        [OperationContract]
        response listarCliente();

        [OperationContract]
        response crearCliente(clienteDTO config);

        [OperationContract]
        response actualizarCliente(clienteDTO config);

        [OperationContract]
        response leerCliente(int id);

        [OperationContract]
        response eliminarCliente(int id);

        #endregion

        #region ConfiguracionCliente
        [OperationContract]
        response listarConfiguracionCliente();

        [OperationContract]
        response crearConfiguracionCliente(configuracionClienteDTO config);

        [OperationContract]
        response actualizarConfiguracionCliente(configuracionClienteDTO config);

        [OperationContract]
        response leerConfiguracionCliente(int id);

        [OperationContract]
        response eliminarConfiguracionCliente(int id);

        #endregion

        #region Actividad
        [OperationContract]
        response listarActividad();

        [OperationContract]
        response crearActividad(actividadDTO activity);

        [OperationContract]
        response actualizarActividad(actividadDTO activity);

        [OperationContract]
        response leerActividad(int id);

        [OperationContract]
        response eliminarActividad(int id);

        #endregion

        #region Persona
        [OperationContract]
        response listarPersona();

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
        response listarRol();

        [OperationContract]
        response crearRol(rolDTO rol);

        [OperationContract]
        response actualizarRol(rolDTO rol);

        [OperationContract]
        response leerRol(int id);

        [OperationContract]
        response eliminarRol(int id);

        #endregion

        #region factura
        [OperationContract]
        response listarFactura();

        [OperationContract]
        response crearFactura(facturaDTO invoice);

        [OperationContract]
        response actualizarFactura(facturaDTO invoice);

        [OperationContract]
        response leerFactura(int id);

        [OperationContract]
        response eliminarFactura(int id);

        #endregion

        #region Paquete
        [OperationContract]
        response listarPaquete(int id);

        [OperationContract]
        response crearPaquete(paqueteDTO package);

        [OperationContract]
        response actualizarPaquete(paqueteDTO package);

        [OperationContract]
        response leerPaquete(int id);

        [OperationContract]
        response eliminarPaquete(int id);

        #endregion

        #region Costo
        [OperationContract]
        response listarCosto(int id);

        [OperationContract]
        response crearCosto(costoDTO cost);

        [OperationContract]
        response actualizarCosto(costoDTO cost);

        [OperationContract]
        response leerCosto(int id);

        [OperationContract]
        response eliminarCosto(int id);

        #endregion

        #region informacionAfiliado
        [OperationContract]
        response listarInfoAfiliado(int id);

        [OperationContract]
        response crearInfoAfiliado(infoAfiDTO info);

        [OperationContract]
        response actualizarInfoAfiliado(infoAfiDTO info);

        [OperationContract]
        response leerInfoAfiliado(int id);

        [OperationContract]
        response eliminarInfoAfiliado(int id);

        #endregion

    }
}
