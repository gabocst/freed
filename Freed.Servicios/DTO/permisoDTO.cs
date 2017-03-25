using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class permisoDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        public permisoDTO(permiso p)
        {
            this.id = p.id;
            this.nombre = p.nombre;
            this.descripcion = p.descripcion;
        }
    }
}