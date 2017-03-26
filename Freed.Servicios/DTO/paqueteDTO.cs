using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class paqueteDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public List<actividadDTO> actividades { get; set; }

        [DataMember]
        public costoDTO costo { get; set; }

        public paqueteDTO(paquete p)
        {
            this.id = p.id;
            this.fechaCreacion = p.fechaCreacion;
            this.nombre = p.nombre;
        }
    }
}