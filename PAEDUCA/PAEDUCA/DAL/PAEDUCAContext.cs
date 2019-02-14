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
            : base("Name=MS")
        //: base(new Conexion().conexion)
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
            modelBuilder.Entity<HistoryRow>().HasKey(p => p.MigrationId);

            //Tablas UNI
            modelBuilder.Entity<Universidad>().ToTable(tableName:"Universidad",schemaName:"UNI");
            modelBuilder.Entity<Recinto>().ToTable(tableName: "Recinto", schemaName: "UNI");
            modelBuilder.Entity<SedeFacultad>().ToTable(tableName: "SedeFacultad", schemaName: "UNI");
            modelBuilder.Entity<DepartamentoCoordinacion>().ToTable(tableName: "DepartamentoCoordinacion", schemaName: "UNI");
            modelBuilder.Entity<Carrera>().ToTable(tableName: "Carrera", schemaName: "UNI");
            modelBuilder.Entity<CarreraSedeFacultad>().ToTable(tableName: "CarreraSedeFacultad", schemaName: "UNI");
            modelBuilder.Entity<Asignatura>().ToTable(tableName: "Asignatura", schemaName: "UNI");
            modelBuilder.Entity<CarreraAsignatura>().ToTable(tableName: "CarreraAsignatura", schemaName: "UNI");
            modelBuilder.Entity<Grupo>().ToTable(tableName: "Grupo", schemaName: "UNI");
            modelBuilder.Entity<Curso>().ToTable(tableName: "Curso", schemaName: "UNI");
            modelBuilder.Entity<PlanificacionGeneral>().ToTable(tableName: "PlanificacionGeneral", schemaName: "UNI");

            //Tablas VEDD
            modelBuilder.Entity<AspectoVEDD>().ToTable(tableName: "AspectoVEDD", schemaName: "VEDD");
            modelBuilder.Entity<CriterioVEDD>().ToTable(tableName: "CriterioVEDD", schemaName: "VEDD");
            modelBuilder.Entity<ProgramacionVEDD>().ToTable(tableName: "ProgramacionVEDD", schemaName: "VEDD");
            modelBuilder.Entity<AplicacionVEDD>().ToTable(tableName: "AplicacionVED", schemaName: "VEDD");

            //Tablas AVD

            modelBuilder.Entity<AspectoAVD>().ToTable(tableName: "AspectoAVD", schemaName: "AVD");
            modelBuilder.Entity<CriterioAVD>().ToTable(tableName: "CriterioAVD", schemaName: "AVD");
            modelBuilder.Entity<ProgramacionAVD>().ToTable(tableName: "ProgramacionAVD", schemaName: "AVD");

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