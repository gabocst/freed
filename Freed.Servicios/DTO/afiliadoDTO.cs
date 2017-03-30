using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class afiliadoDTO
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

        [DataMember]
        public string cliente { get; set; }

        [DataMember]
        public string rol { get; set; }

        [DataMember]
        public List<infoPersonaDTO> info { get; set; }

        public afiliadoDTO(afiliado a)
        {
            this.id = a.idPersonaAfiliado;
            this.fechaCreacion = a.persona.fechaCreacion;
            this.nombre = a.persona.nombre;
            this.apellido = a.persona.apellido;
            this.dni = a.persona.dni;
            this.fechaNacimiento = a.persona.fechaNacimiento;
            this.idCliente = a.persona.idCliente;
            this.idRol = a.persona.idRol;
            this.sexo = a.persona.sexo;
            this.cliente = a.persona.cliente.nombre;
            this.rol = a.persona.rol.nombre;
        }
    }
}