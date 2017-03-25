using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class facturaDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public DateTime fechaCreacion { get; set; }

        [DataMember]
        public string numero { get; set; }

        [DataMember]
        public DateTime fechaPago { get; set; }

        [DataMember]
        public DateTime desde { get; set; }

        [DataMember]
        public DateTime hasta { get; set; }

        [DataMember]
        public int idCliente { get; set; }



        public facturaDTO(factura f)
        {
            this.id = f.id;
            this.fechaCreacion = f.fechaCreacion;
            this.numero = f.numero;
            this.fechaPago = f.fechaPago;
            this.desde = f.desde;
            this.hasta = f.hasta;
            this.idCliente = this.idCliente;
        }
    }
}