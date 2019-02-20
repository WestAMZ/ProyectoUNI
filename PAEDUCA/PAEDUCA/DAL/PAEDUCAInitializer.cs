using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAEDUCA.Models;
namespace PAEDUCA.DAL
{
    public class PAEDUCAInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
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

            var facultades = new List<SedeFacultad>
            {
                new SedeFacultad {Nombre = "Facultad de Ciencias y Sistemas" ,IdRecinto = 2 ,Tipo = ValorTipo.Facultad ,Web ="http://www.fcys.uni.edu.ni"},
                new SedeFacultad {Nombre = "Facultad de Tecnología de la Industria" ,IdRecinto = 2 ,Tipo = ValorTipo.Facultad ,Web ="http://www.fti.uni.edu.ni"}
            };
            facultades.ForEach(f => context.Sede_Facutad.Add(f));
            context.SaveChanges();
            var departamentos = new List<DepartamentoCoordinacion>
            {
                new DepartamentoCoordinacion {IdSedeFacultad = 1,Nombre = "Informática" ,Tipo = TipoDivision.Departamento},
                new DepartamentoCoordinacion {IdSedeFacultad = 1,Nombre = "Administración" ,Tipo = TipoDivision.Departamento},
                new DepartamentoCoordinacion {IdSedeFacultad = 1,Nombre = "Informática" ,Tipo = TipoDivision.Departamento},
                new DepartamentoCoordinacion {IdSedeFacultad = 1,Nombre = "Matemáticas" ,Tipo = TipoDivision.Departamento},
                new DepartamentoCoordinacion {IdSedeFacultad = 1,Nombre = "Idiomas" ,Tipo = TipoDivision.Departamento},
                new DepartamentoCoordinacion {IdSedeFacultad = 1,Nombre = "Ciencias Sociales" ,Tipo = TipoDivision.Departamento},
                new DepartamentoCoordinacion {IdSedeFacultad = 1,Nombre = "Física" ,Tipo = TipoDivision.Departamento},
            };
            departamentos.ForEach(d => context.DepartamentoCoordinacion.Add(d));
            context.SaveChanges();

            var docentes = new List<Docente>
            {
                new Docente {IdDepartamentoCoordinacion = 1,Nombres = "Patricia del Carmen",Apellidos = "Lacayo Cruz",Sexo=Sexo.Femenino},
                new Docente {IdDepartamentoCoordinacion = 1,Nombres = "Evelyn del Carmen",Apellidos = "Espinoza Aragón",Sexo=Sexo.Femenino}
            };
            docentes.ForEach(d => context.Docente.Add(d));
            context.SaveChanges();

        }
    }
}