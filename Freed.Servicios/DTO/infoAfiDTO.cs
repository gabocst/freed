using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class infoAfiDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string atributo { get; set; }

        [DataMember]
        public string tipoValor { get; set; }

        [DataMember]
        public bool requerido { get; set; }

        [DataMember]
        public bool vigente { get; set; }

        [DataMember]
        public int idCliente { get; set; }

        public infoAfiDTO(informacionAfiliado i)
        {
            this.id = i.id;
            this.atributo = i.atributo;
            this.tipoValor = i.tipoValor;
            this.requerido = i.requerido;
            this.vigente = i.vigente;
            this.idCliente = i.idCliente;
        }
    }
}