using Freed.Servicios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.DTO
{
    [DataContract]
    public class empleadoDTO
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
        public string cargo { get; set; }

        [DataMember]
        public decimal sueldo { get; set; }

        [DataMember]
        public List<infoPersonaDTO> info { get; set; }

        public empleadoDTO(empleado e)
        {
            this.id = e.idPersonaEmpleado;
            this.fechaCreacion = e.persona.fechaCreacion;
            this.nombre = e.persona.nombre;
            this.apellido = e.persona.apellido;
            this.dni = e.persona.dni;
            this.fechaNacimiento = e.persona.fechaNacimiento;
            this.idCliente = e.persona.idCliente;
            this.idRol = e.persona.idRol;
            this.sexo = e.persona.sexo;
            this.cliente = e.persona.cliente.nombre;
            this.rol = e.persona.rol.nombre;
            this.cargo = e.cargo;
            this.sueldo = e.sueldo;
        }
    }
}