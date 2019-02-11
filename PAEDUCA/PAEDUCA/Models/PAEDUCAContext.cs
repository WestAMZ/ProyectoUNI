namespace PAEDUCA.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PAEDUCAContext : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'DBContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'PAEDUCA' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'DBContext'  en el archivo de configuración de la aplicación.
        public PAEDUCAContext()
            : base("name=Westly")
        {

        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Universidad> Universidad { get; set; }
        public virtual DbSet<Recinto> Recinto { set; get; }
        public virtual DbSet<Sede_Facultad> Sede_Facutad { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            modelBuilder.HasDefaultSchema("UNI");
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