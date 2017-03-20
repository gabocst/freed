using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
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
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        public string atributo { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        [DataMember]
        public string codigoSistema { get; set; }

        [DataMember]
        public string tipoValor { get; set; }

        [DataMember]
        public bool requerido { get; set; }

        [DataMember]
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