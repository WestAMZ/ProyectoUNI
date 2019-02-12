namespace PAEDUCA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PAEDUCA.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<PAEDUCA.DAL.PAEDUCAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PAEDUCA.DAL.PAEDUCAContext context)
        {
            var universidades = new List<Universidad>
            {
                new Universidad {Nombre ="Universidad Nacional de Ingeniería",Siglas="UNI",Logo = null, Eslogan = "Liden en Ciencia y Tecnología"},
                new Universidad {Nombre ="Universidad Nacional Autónoma de Nicaragua",Siglas="UNAN",Logo = null, Eslogan = "¡A la Libertad por La Universidad!"},
            };
            //Llenado de UNI
            universidades[1].Recintos = new List<Recinto>
            {
                new Recinto {NombreRecinto="Recinto Universitario Simón Bolivar",Siglas="RUSB"},
                new Recinto {NombreRecinto="Recinto Universitario Pedro Arauz Palacios",Siglas="RUPAP" },
                new Recinto {NombreRecinto="Recinto Universitario Augusto C. Sandino",Siglas="RUACS" }

            };
            universidades.ForEach(u => context.Universidades.Add(u));
            context.SaveChanges();
        }
    }
}
