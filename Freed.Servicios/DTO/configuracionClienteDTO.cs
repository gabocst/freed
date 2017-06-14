using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class configuracionClienteDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string valor { get; set; }

        [DataMember]
        public int idConfiguracion { get; set; }

        [DataMember]
        public int idCliente { get; set; }

        [DataMember]
        public string configuracion { get; set; }

        [DataMember]
        public string cliente { get; set; }

        public configuracionClienteDTO(configuracionCliente c)
        {
            this.id = c.id;
            this.valor = c.valor;
            this.idConfiguracion = c.idConfiguracion;
            this.idCliente = c.idCliente;
            this.cliente = c.cliente.nombre;
            this.configuracion = c.configuracion.atributo;
        }
    }
}