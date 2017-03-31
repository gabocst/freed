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
    [DataContract]
    public class configuracionDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        [DisplayName("Fecha de Creación")]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        [DisplayName("Atributo")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string atributo { get; set; }

        [DataMember]
        [DisplayName("Descripción")]
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string descripcion { get; set; }

        [DataMember]
        public string codigoSistema { get; set; }

        [DataMember]
        [DisplayName("Tipo Valor")]
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string tipoValor { get; set; }

        [DataMember]
        [DisplayName("Requerido")]
        [Required]
        public bool requerido { get; set; }

        [DataMember]
        [DisplayName("Grupo")]
        [Required]
        public int idGrupo { get; set; }

        [DataMember]
        public string grupo { get; set; }

        public configuracionDTO(configuracion c)
        {
            this.id = c.id;
            this.fechaCreacion = c.fechaCreacion;
            this.atributo = c.atributo;
            this.descripcion = c.descripcion;
            this.codigoSistema = c.codigoSistema;
            this.tipoValor = c.tipoValor;
            this.requerido = c.requerido;
            this.idGrupo = c.idGrupo;
            this.grupo = c.grupo.nombre;
        }
    }
}