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
            : base("Name=Westly")
        //: base(new Conexion().conexion)
        {

        }

        //UNI
        public virtual DbSet<Universidad> Universidades { get; set; }
        public virtual DbSet<Recinto> Recintos { set; get; }
        public virtual DbSet<SedeFacultad> Sede_Facutad { set; get; }
        public virtual DbSet<DepartamentoCoordinacion> DepartamentoCoordinacion { set; get; }
        public virtual DbSet<Docente> Docente { set; get; }
        public virtual DbSet<Carrera> Carrera { set; get; }
        public virtual DbSet<CarreraSedeFacultad> CarreraSedeFacultad { set; get; }
        public virtual DbSet<Asignatura> Asignatura { set; get; }
        public virtual DbSet<CarreraAsignatura> CarreraAsignatura { set; get; }
        public virtual DbSet<Grupo> Grupo { set; get; }
        public virtual DbSet<Curso> Curso { set; get; }
        public virtual DbSet<PlanificacionGeneral> PlanificacionGeneral { set; get; }

        //VEDD
        public virtual DbSet<AspectoVEDD> AspectoVEDD { set; get; }
        public virtual DbSet<CriterioVEDD> CriterioVEDD { set; get; }
        public virtual DbSet<ProgramacionVEDD> ProgramacionVEDD { set; get; }
        public virtual DbSet<AplicacionVEDD> AplicacionVEDD { set; get; }

        //AVD
        public virtual DbSet<AspectoAVD> AspectoAVD { set; get; }
        public virtual DbSet<CriterioAVD> CriterioAVD { set; get; }
        public virtual DbSet<ProgramacionAVD> ProgramacionAVD { set; get; }
        //FALTA
        //public virtual DbSet<AplicacionAVD> AplicacionAVD { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            //modelBuilder.Entity<HistoryRow>().ToTable(tableName: "MigrationHistory", schemaName: "Admin");
            //modelBuilder.Entity<HistoryRow>().Property(p => p.MigrationId).HasColumnName("Migration_ID");
            //modelBuilder.Entity<HistoryRow>().HasKey(p => p.MigrationId);

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