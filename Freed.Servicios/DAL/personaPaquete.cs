//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Freed.Servicios.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class personaPaquete
    {
        public int id { get; set; }
        public Nullable<System.DateTime> desde { get; set; }
        public Nullable<System.DateTime> hasta { get; set; }
        public Nullable<int> cantidad { get; set; }
        public int idPersona { get; set; }
        public int idPaquete { get; set; }
    
        public virtual paquete paquete { get; set; }
        public virtual persona persona { get; set; }
    }
}
