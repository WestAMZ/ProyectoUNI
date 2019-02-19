using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PAEDUCA.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Westly", throwIfV1Schema: false)
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
        public virtual DbSet<DocenteCurso> DocenteCurso { set; get; }
        public virtual DbSet<PlanificacionGeneral> PlanificacionGeneral { set; get; }

        //VEDD
        public virtual DbSet<AspectoVEDD> AspectoVEDD { set; get; }
        public virtual DbSet<CriterioVEDD> CriterioVEDD { set; get; }
        public virtual DbSet<ProgramacionVEDD> ProgramacionVEDD { set; get; }
        public virtual DbSet<AplicacionVEDD> AplicacionVEDD { set; get; }
        public virtual DbSet<AplicacionVEDDEstudiante> AplicacionVEDDEstudiante { set; get; }
        public virtual DbSet<DetalleAplicacionVEDD> DetalleAplicacionVEDD { set; get; }
        //AVD
        public virtual DbSet<AspectoAVD> AspectoAVD { set; get; }
        public virtual DbSet<CriterioAVD> CriterioAVD { set; get; }
        public virtual DbSet<ProgramacionAVD> ProgramacionAVD { set; get; }
        public virtual DbSet<AplicacionAVD> AplicacionAVD { set; get; }
        public virtual DbSet<DetalleAplicacionAVD> DetalleAplicacionAVD { set; get; }
        //AAC
        public virtual DbSet<AspectoAAC> AspectoAAC { set; get; }
        public virtual DbSet<CriterioAAC> CriterioAAC { set; get; }
        public virtual DbSet<ProgramacionAAC> ProgramacionAAC { set; get; }
        public virtual DbSet<AplicacionAAC> AplicacionAAC { set; get; }
        public virtual DbSet<DetalleAplicacionAAC> DetalleAplicacionAAC { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            //modelBuilder.Entity<HistoryRow>().ToTable(tableName: "MigrationHistory", schemaName: "Admin");
            //modelBuilder.Entity<HistoryRow>().Property(p => p.MigrationId).HasColumnName("Migration_ID");
            //modelBuilder.Entity<HistoryRow>().HasKey(p => p.MigrationId);

            //Tablas UNI
            modelBuilder.Entity<Universidad>().ToTable(tableName: "Universidad", schemaName: "UNI");
            modelBuilder.Entity<Recinto>().ToTable(tableName: "Recinto", schemaName: "UNI");
            modelBuilder.Entity<SedeFacultad>().ToTable(tableName: "SedeFacultad", schemaName: "UNI");
            modelBuilder.Entity<Carrera>().ToTable(tableName: "Carrera", schemaName: "UNI");
            modelBuilder.Entity<Docente>().ToTable(tableName: "Docente", schemaName: "UNI");
            modelBuilder.Entity<DepartamentoCoordinacion>().ToTable(tableName: "DepartamentoCoordinacion", schemaName: "UNI");
            modelBuilder.Entity<CarreraSedeFacultad>().ToTable(tableName: "CarreraSedeFacultad", schemaName: "UNI");
            modelBuilder.Entity<Asignatura>().ToTable(tableName: "Asignatura", schemaName: "UNI");
            modelBuilder.Entity<CarreraAsignatura>().ToTable(tableName: "CarreraAsignatura", schemaName: "UNI");
            modelBuilder.Entity<Grupo>().ToTable(tableName: "Grupo", schemaName: "UNI");
            modelBuilder.Entity<Curso>().ToTable(tableName: "Curso", schemaName: "UNI");
            modelBuilder.Entity<DocenteCurso>().ToTable(tableName: "DocenteCurso", schemaName: "UNI");
            modelBuilder.Entity<PlanificacionGeneral>().ToTable(tableName: "PlanificacionGeneral", schemaName: "UNI");

            //Tablas VEDD
            modelBuilder.Entity<AspectoVEDD>().ToTable(tableName: "AspectoVEDD", schemaName: "VEDD");
            modelBuilder.Entity<CriterioVEDD>().ToTable(tableName: "CriterioVEDD", schemaName: "VEDD");
            modelBuilder.Entity<ProgramacionVEDD>().ToTable(tableName: "ProgramacionVEDD", schemaName: "VEDD");
            modelBuilder.Entity<AplicacionVEDD>().ToTable(tableName: "AplicacionVED", schemaName: "VEDD");
            modelBuilder.Entity<AplicacionVEDDEstudiante>().ToTable(tableName: "AplicacionVEDDEstudiante", schemaName: "VEDD");
            modelBuilder.Entity<DetalleAplicacionVEDD>().ToTable(tableName: "DetalleAplicacionVEDD", schemaName: "VEDD");
            //Tablas AVD
            modelBuilder.Entity<AspectoAVD>().ToTable(tableName: "AspectoAVD", schemaName: "AVD");
            modelBuilder.Entity<CriterioAVD>().ToTable(tableName: "CriterioAVD", schemaName: "AVD");
            modelBuilder.Entity<ProgramacionAVD>().ToTable(tableName: "ProgramacionAVD", schemaName: "AVD");
            modelBuilder.Entity<AplicacionAVD>().ToTable(tableName: "AplicacionAVD", schemaName: "AVD");
            modelBuilder.Entity<DetalleAplicacionAVD>().ToTable(tableName: "DetalleAplicacionAVD", schemaName: "AVD");
            //Tablas AAC
            modelBuilder.Entity<AspectoAAC>().ToTable(tableName: "AspectoAAC", schemaName: "AAC");
            modelBuilder.Entity<CriterioAAC>().ToTable(tableName: "CriterioAAC", schemaName: "AAC");
            modelBuilder.Entity<ProgramacionAAC>().ToTable(tableName: "ProgramacionAAC", schemaName: "AAC");
            modelBuilder.Entity<AplicacionAAC>().ToTable(tableName: "AplicacionAAC", schemaName: "AAC");
            modelBuilder.Entity<DetalleAplicacionAAC>().ToTable(tableName: "DetalleAplicacionAAC", schemaName: "AAC");
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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}