namespace PAEDUCA.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using PAEDUCA.Models;
    public class PAEDUCAContext : DbContext
    {
   
        public PAEDUCAContext()
            : base(new Conexion().conexion)
        {

        }

        public virtual DbSet<Universidad> Universidades { get; set; }
        public virtual DbSet<Recinto> Recintos { set; get; }
        public virtual DbSet<Sede_Facultad> Sede_Facutad { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //modelBuilder.HasDefaultSchema("UNI");
            modelBuilder.Entity<Universidad>().ToTable("Universidad");
            modelBuilder.Entity<Recinto>().ToTable("Recinto");
            modelBuilder.Entity<Sede_Facultad>().ToTable("Sede_Facultad");
            //Map entity to table
            //modelBuilder.Entity<Universidad>().Map(m =>
            //{
            //    m.Properties(p => new { p.IdUniversidad, p.Nombre, p.Logo });
            //    m.ToTable("Universidad");
            //})
            //.Map(m =>
            //{
            //    m.Properties(p =>)
            //});

        }
    }

}