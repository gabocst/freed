using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class afiliadoPaqueteDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public Nullable<System.DateTime> desde { get; set; }

        [DataMember]
        public Nullable<System.DateTime> hasta { get; set; }

        [DataMember]
        public Nullable<int> cantidad { get; set; }

        [DataMember]
        public int idAfiliado { get; set; }

        [DataMember]
        public int idPaquete { get; set; }

        [DataMember]
        public string afiliado { get; set; }

        [DataMember]
        public string paquete { get; set; }

        public afiliadoPaqueteDTO(afiliadoPaquete ap)
        {
            this.afiliado = ap.afiliado.persona.nombre + " " + ap.afiliado.persona.apellido;
            this.cantidad = ap.cantidad;
            this.desde = ap.desde;
            this.hasta = ap.hasta;
            this.id = ap.id;
            this.idAfiliado = ap.idAfiliado;
            this.idPaquete = ap.idPaquete;
            this.paquete = ap.paquete.nombre;
        }
    }
}