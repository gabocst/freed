using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class actividadDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        public string nombre { get; set; }

        public actividadDTO(actividad a)
        {
            this.id = a.id;
            this.fechaCreacion = a.fechaCreacion;
            this.nombre = a.nombre;
        }
    }
}