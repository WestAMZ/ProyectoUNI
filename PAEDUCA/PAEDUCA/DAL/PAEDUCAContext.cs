namespace PAEDUCA.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using PAEDUCA.Models;
    using System.Data.Entity.Migrations.History;

    public class PAEDUCAContext : DbContext
    {
   
        public PAEDUCAContext()
            : base(new Conexion().conexion)
        {

        }

        public virtual DbSet<Universidad> Universidades { get; set; }
        public virtual DbSet<Recinto> Recintos { set; get; }
        public virtual DbSet<SedeFacultad> Sede_Facutad { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().ToTable(tableName: "MigrationHistory", schemaName: "Admin");
            modelBuilder.Entity<HistoryRow>().Property(p => p.MigrationId).HasColumnName("Migration_ID");

            //Tablas UNI
            modelBuilder.HasDefaultSchema("UNI");
            modelBuilder.Entity<Universidad>().ToTable("Universidad");
            modelBuilder.Entity<Recinto>().ToTable("Recinto");
            modelBuilder.Entity<SedeFacultad>().ToTable("SedeFacultad");
            modelBuilder.Entity<DepartamentoCoordinacion>().ToTable("DepartamentoCoordinacion");
            modelBuilder.Entity<Carrera>().ToTable("Carrera");
            modelBuilder.Entity<Asignatura>().ToTable("Asignatura");
            modelBuilder.Entity<CarreraAsignatura>().ToTable("CarreraAsignatura");
            modelBuilder.Entity<Grupo>().ToTable("Grupo");

            //Tablas VEDD
            modelBuilder.HasDefaultSchema("VEDD");
            modelBuilder.Entity<AspectoVEDD>().ToTable("AspectoVEDD");
            modelBuilder.Entity<CriterioVEDD>().ToTable("CriterioVEDD");
            modelBuilder.Entity<ProgramacionVED>().ToTable("ProgramacionVEDD");
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