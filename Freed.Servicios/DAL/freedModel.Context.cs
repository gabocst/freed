﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class freedEntities : DbContext
    {
        public freedEntities()
            : base("name=freedEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<configuracion> configuracion { get; set; }
        public virtual DbSet<configuracionCliente> configuracionCliente { get; set; }
        public virtual DbSet<estado> estado { get; set; }
        public virtual DbSet<grupo> grupo { get; set; }
        public virtual DbSet<actividad> actividad { get; set; }
        public virtual DbSet<costo> costo { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<factura> factura { get; set; }
        public virtual DbSet<infoAdicional> infoAdicional { get; set; }
        public virtual DbSet<paquete> paquete { get; set; }
        public virtual DbSet<paqueteActividad> paqueteActividad { get; set; }
        public virtual DbSet<paqueteRegla> paqueteRegla { get; set; }
        public virtual DbSet<permiso> permiso { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<personaPaquete> personaPaquete { get; set; }
        public virtual DbSet<regla> regla { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<rolPermiso> rolPermiso { get; set; }
        public virtual DbSet<tipoNomina> tipoNomina { get; set; }
    }
}
