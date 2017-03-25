using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class paqueteActividadDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int idPaquete { get; set; }

        [DataMember]
        public int idActividad { get; set; }

        public paqueteActividadDTO(paqueteActividad pa)
        {
            this.id = pa.id;
            this.idActividad = pa.idActividad;
            this.idPaquete = pa.idPaquete;
        }
    }
}