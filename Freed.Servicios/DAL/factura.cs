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
    
    public partial class factura
    {
        public int id { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public string numero { get; set; }
        public System.DateTime fechaPago { get; set; }
        public System.DateTime desde { get; set; }
        public System.DateTime hasta { get; set; }
        public int idCliente { get; set; }
    
        public virtual cliente cliente { get; set; }
    }
}