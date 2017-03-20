using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class grupoDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        public string nombre { get; set; }

        public grupoDTO(grupo g)
        {
            this.id = g.id;
            this.fechaCreacion = g.fechaCreacion;
            this.nombre = g.nombre;
        }
    }
}