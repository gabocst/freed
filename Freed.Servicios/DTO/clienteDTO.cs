using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class clienteDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string correo { get; set; }

        [DataMember]
        public int idEstado { get; set; }

        [DataMember]
        public string estado { get; set; }

        public clienteDTO(cliente c)
        {
            this.id = c.id;
            this.fechaCreacion = c.fechaCreacion;
            this.nombre = c.nombre;
            this.correo = c.correo;
            this.idEstado = c.idEstado;
            this.estado = c.estado.nombre;
        }
    }
}