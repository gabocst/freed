using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class costoDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        public System.DateTime inicio { get; set; }

        [DataMember]
        public System.DateTime fin { get; set; }

        [DataMember]
        public int costo1 { get; set; }

        [DataMember]
        public int idPaquete { get; set; }

        [DataMember]
        public string paquete { get; set; }

        public costoDTO(costo c)
        {
            this.id = c.id;
            this.fechaCreacion = c.fechaCreacion;
            this.inicio = c.inicio;
            this.fin = c.fin;
            this.costo1 = c.costo1;
            this.idPaquete = c.idPaquete;
            this.paquete = c.paquete.nombre;
        }
    }
}