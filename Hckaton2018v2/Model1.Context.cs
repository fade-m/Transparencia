﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hckaton2018v2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_transparenciaEntities : DbContext
    {
        public db_transparenciaEntities()
            : base("name=db_transparenciaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<archivo> archivo { get; set; }
        public virtual DbSet<candidato> candidato { get; set; }
        public virtual DbSet<egreso> egreso { get; set; }
        public virtual DbSet<estado> estado { get; set; }
        public virtual DbSet<partidoPolitico> partidoPolitico { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<pregunta> pregunta { get; set; }
        public virtual DbSet<presupuesto> presupuesto { get; set; }
        public virtual DbSet<programasIngreso> programasIngreso { get; set; }
        public virtual DbSet<propuestas> propuestas { get; set; }
        public virtual DbSet<tipoCandidato> tipoCandidato { get; set; }
        public virtual DbSet<tipoPropuesta> tipoPropuesta { get; set; }
        public virtual DbSet<tipoUsuario> tipoUsuario { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
