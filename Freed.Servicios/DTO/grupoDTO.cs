using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract(Namespace = "http://schemas.devtrends.co.uk/example/data")]
    public class grupoDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        [DisplayName("Fecha de Creación")]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        [DisplayName("Nombre")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string nombre { get; set; }

        public grupoDTO(grupo g)
        {
            this.id = g.id;
            this.fechaCreacion = g.fechaCreacion;
            this.nombre = g.nombre;
        }
    }
}