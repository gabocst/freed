using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class personaDTO
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public System.DateTime fechaCreacion { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string apellido { get; set; }

        [DataMember]
        public string dni { get; set; }

        [DataMember]
        public System.DateTime fechaNacimiento { get; set; }

        [DataMember]
        public string sexo { get; set; }

        [DataMember]
        public int idCliente { get; set; }

        [DataMember]
        public int idRol { get; set; }

        public personaDTO(persona p)
        {
            this.id = p.id;
            this.fechaCreacion = p.fechaCreacion;
            this.nombre = p.nombre;
            this.apellido = p.apellido;
            this.dni = p.dni;
            this.fechaNacimiento = p.fechaNacimiento;
            this.idCliente = p.idCliente;
            this.idRol = p.idRol;
            this.sexo = p.sexo;
        }
    }
}