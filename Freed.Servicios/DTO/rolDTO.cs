using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class rolDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public List<permisoDTO> permisos { get; set; }

        public rolDTO(rol r)
        {
            this.id = r.id;
            this.fechaCreacion = r.fechaCreacion;
            this.nombre = r.nombre;
        }
    }
}