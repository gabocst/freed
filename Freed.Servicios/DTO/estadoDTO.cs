using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class estadoDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        public estadoDTO(estado e)
        {
            this.id = e.id;
            this.descripcion = e.descripcion;
            this.nombre = e.nombre;
        }
    }
}