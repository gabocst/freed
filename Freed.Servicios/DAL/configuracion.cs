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
    
    public partial class configuracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public configuracion()
        {
            this.configuracionCliente = new HashSet<configuracionCliente>();
        }
    
        public int id { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public string atributo { get; set; }
        public string descripcion { get; set; }
        public string codigoSistema { get; set; }
        public string tipoValor { get; set; }
        public bool requerido { get; set; }
        public int idGrupo { get; set; }
    
        public virtual grupo grupo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<configuracionCliente> configuracionCliente { get; set; }
    }
}
