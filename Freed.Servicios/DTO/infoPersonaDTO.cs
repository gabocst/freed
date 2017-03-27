using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class infoPersonaDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string atributo { get; set; }

        [DataMember]
        public string valor { get; set; }

        [DataMember]
        public int idInformacionPersona { get; set; }

        [DataMember]
        public int idPersona { get; set; }

        public infoPersonaDTO(informacionEmpleadoEmpleado i)
        {
            this.id = i.id;
            this.atributo = i.informacionEmpleado.atributo;
            this.idInformacionPersona = i.idInformacionEmpleado;
            this.idPersona = i.idEmpleado;
            this.valor = i.valor;
        }
    }
}