namespace PAEDUCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionconobjetosdeMartin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UNI.Recinto",
                c => new
                    {
                        IdRecinto = c.Int(nullable: false, identity: true),
                        IdUniversidad = c.Int(nullable: false),
                        NombreRecinto = c.String(nullable: false, maxLength: 200),
                        Siglas = c.String(),
                    })
                .PrimaryKey(t => t.IdRecinto)
                .ForeignKey("UNI.Universidad", t => t.IdUniversidad, cascadeDelete: true)
                .Index(t => t.IdUniversidad);
            
            CreateTable(
                "UNI.Universidad",
                c => new
                    {
                        IdUniversidad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200, unicode: false),
                        Siglas = c.String(),
                        Eslogan = c.String(),
                        Logo = c.Binary(),
                    })
                .PrimaryKey(t => t.IdUniversidad);
            
            CreateTable(
                "UNI.SedeFacultad",
                c => new
                    {
                        IdSedeFacultad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Tipo = c.Int(nullable: false),
                        Web = c.String(maxLength: 200),
                        IdRecinto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSedeFacultad)
                .ForeignKey("UNI.Recinto", t => t.IdRecinto, cascadeDelete: true)
                .Index(t => t.IdRecinto);
            
            CreateTable(
                "dbo.CarreraSedeFacultads",
                c => new
                    {
                        IdCarreraSedeFacultad = c.Int(nullable: false, identity: true),
                        IdCarrera = c.Int(nullable: false),
                        IdSedeFacultad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCarreraSedeFacultad)
                .ForeignKey("UNI.Carrera", t => t.IdCarrera, cascadeDelete: true)
                .ForeignKey("UNI.SedeFacultad", t => t.IdSedeFacultad, cascadeDelete: true)
                .Index(t => t.IdCarrera)
                .Index(t => t.IdSedeFacultad);
            
            CreateTable(
                "UNI.Carrera",
                c => new
                    {
                        IdCarrera = c.Int(nullable: false, identity: true),
                        NombreCarrera = c.String(),
                        CantidadSemestres = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCarrera);
            
            CreateTable(
                "UNI.DepartamentoCoordinacion",
                c => new
                    {
                        IdDepartamentoCoordinacion = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200),
                        Tipo = c.Int(nullable: false),
                        IdSedeFacultad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDepartamentoCoordinacion)
                .ForeignKey("UNI.SedeFacultad", t => t.IdSedeFacultad, cascadeDelete: true)
                .Index(t => t.IdSedeFacultad);
            
            CreateTable(
                "Admin.MigrationHistory",
                c => new
                    {
                        Migration_ID = c.String(nullable: false, maxLength: 128),
                        ContextKey = c.String(),
                        Model = c.Binary(),
                        ProductVersion = c.String(),
                    })
                .PrimaryKey(t => t.Migration_ID);
            
            CreateTable(
                "UNI.Asignatura",
                c => new
                    {
                        IdAsignatura = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(maxLength: 30),
                        Creditos = c.Int(nullable: false),
                        Oportunidades = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAsignatura);
            
            CreateTable(
                "UNI.CarreraAsignatura",
                c => new
                    {
                        IdCarreraAsignatura = c.Int(nullable: false, identity: true),
                        Semestre = c.Int(nullable: false),
                        IdCarrera = c.Int(nullable: false),
                        IdAsignatura = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCarreraAsignatura)
                .ForeignKey("UNI.Asignatura", t => t.IdAsignatura, cascadeDelete: true)
                .ForeignKey("UNI.Carrera", t => t.IdCarrera, cascadeDelete: true)
                .Index(t => t.IdCarrera)
                .Index(t => t.IdAsignatura);
            
            CreateTable(
                "UNI.Grupo",
                c => new
                    {
                        IdGrupo = c.Int(nullable: false, identity: true),
                        Anio = c.Int(nullable: false),
                        Turno = c.String(maxLength: 20),
                        IdCarrera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdGrupo)
                .ForeignKey("UNI.Carrera", t => t.IdCarrera, cascadeDelete: true)
                .Index(t => t.IdCarrera);
            
            CreateTable(
                "UNI.Curso",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        IdGrupo = c.Int(nullable: false),
                        IdAsignatura = c.Int(nullable: false),
                        IdRecinto = c.Int(nullable: false),
                        Semestre = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdCurso)
                .ForeignKey("UNI.Asignatura", t => t.IdAsignatura, cascadeDelete: true)
                .ForeignKey("UNI.Grupo", t => t.IdGrupo, cascadeDelete: true)
                .ForeignKey("UNI.Recinto", t => t.IdRecinto, cascadeDelete: true)
                .Index(t => t.IdGrupo)
                .Index(t => t.IdAsignatura)
                .Index(t => t.IdRecinto);
            
            CreateTable(
                "UNI.PlanificacionGeneral",
                c => new
                    {
                        IdPlanificacion = c.Int(nullable: false, identity: true),
                        Semestre = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        IdCarrera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPlanificacion)
                .ForeignKey("UNI.Carrera", t => t.IdCarrera, cascadeDelete: true)
                .Index(t => t.IdCarrera);
            
            CreateTable(
                "VEDD.AspectoVEDD",
                c => new
                    {
                        IdAspecto = c.Int(nullable: false, identity: true),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAspecto);
            
            CreateTable(
                "VEDD.CriterioVEDD",
                c => new
                    {
                        IdCriterioVEDD = c.Int(nullable: false, identity: true),
                        Criterio = c.String(nullable: false, maxLength: 350),
                        TipoVisualizacion = c.Int(nullable: false),
                        TipoValor = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        IdAspectoVEDD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCriterioVEDD)
                .ForeignKey("VEDD.AspectoVEDD", t => t.IdAspectoVEDD, cascadeDelete: true)
                .Index(t => t.IdAspectoVEDD);
            
            CreateTable(
                "VEDD.ProgramacionVEDD",
                c => new
                    {
                        IdProgramacionVED = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFin = c.Time(nullable: false, precision: 7),
                        IdCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProgramacionVED)
                .ForeignKey("UNI.Curso", t => t.IdCurso, cascadeDelete: true)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "VEDD.AplicacionVED",
                c => new
                    {
                        IdAplicacionVEDD = c.Int(nullable: false, identity: true),
                        FechaApliacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdAplicacionVEDD);
            
            CreateTable(
                "AVD.AspectoAVD",
                c => new
                    {
                        IdAspectoAVD = c.Int(nullable: false, identity: true),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAspectoAVD);
            
            CreateTable(
                "AVD.CriterioAVD",
                c => new
                    {
                        IdCriterioAvd = c.Int(nullable: false, identity: true),
                        Criterio = c.String(nullable: false, maxLength: 350),
                        TipoVisauilzacion = c.Int(nullable: false),
                        TipoValor = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        IdAspectoAVD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCriterioAvd)
                .ForeignKey("AVD.AspectoAVD", t => t.IdAspectoAVD, cascadeDelete: true)
                .Index(t => t.IdAspectoAVD);
            
            CreateTable(
                "AVD.ProgramacionAVD",
                c => new
                    {
                        IdProgramacionAVD = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFin = c.Time(nullable: false, precision: 7),
                        IdDocente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProgramacionAVD)
                .ForeignKey("dbo.Docentes", t => t.IdDocente, cascadeDelete: true)
                .Index(t => t.IdDocente);
            
            CreateTable(
                "dbo.Docentes",
                c => new
                    {
                        IdDocente = c.Int(nullable: false, identity: true),
                        Nombres = c.String(maxLength: 40),
                        Apellidos = c.String(maxLength: 40),
                        Sexo = c.String(maxLength: 10),
                        TipoContratacion = c.String(maxLength: 30),
                        Categoria = c.String(maxLength: 30),
                        IdDepartamentoCoordinacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDocente)
                .ForeignKey("UNI.DepartamentoCoordinacion", t => t.IdDepartamentoCoordinacion, cascadeDelete: true)
                .Index(t => t.IdDepartamentoCoordinacion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("AVD.ProgramacionAVD", "IdDocente", "dbo.Docentes");
            DropForeignKey("dbo.Docentes", "IdDepartamentoCoordinacion", "UNI.DepartamentoCoordinacion");
            DropForeignKey("AVD.CriterioAVD", "IdAspectoAVD", "AVD.AspectoAVD");
            DropForeignKey("VEDD.ProgramacionVEDD", "IdCurso", "UNI.Curso");
            DropForeignKey("VEDD.CriterioVEDD", "IdAspectoVEDD", "VEDD.AspectoVEDD");
            DropForeignKey("UNI.PlanificacionGeneral", "IdCarrera", "UNI.Carrera");
            DropForeignKey("UNI.Curso", "IdRecinto", "UNI.Recinto");
            DropForeignKey("UNI.Curso", "IdGrupo", "UNI.Grupo");
            DropForeignKey("UNI.Curso", "IdAsignatura", "UNI.Asignatura");
            DropForeignKey("UNI.Grupo", "IdCarrera", "UNI.Carrera");
            DropForeignKey("UNI.CarreraAsignatura", "IdCarrera", "UNI.Carrera");
            DropForeignKey("UNI.CarreraAsignatura", "IdAsignatura", "UNI.Asignatura");
            DropForeignKey("UNI.SedeFacultad", "IdRecinto", "UNI.Recinto");
            DropForeignKey("UNI.DepartamentoCoordinacion", "IdSedeFacultad", "UNI.SedeFacultad");
            DropForeignKey("dbo.CarreraSedeFacultads", "IdSedeFacultad", "UNI.SedeFacultad");
            DropForeignKey("dbo.CarreraSedeFacultads", "IdCarrera", "UNI.Carrera");
            DropForeignKey("UNI.Recinto", "IdUniversidad", "UNI.Universidad");
            DropIndex("dbo.Docentes", new[] { "IdDepartamentoCoordinacion" });
            DropIndex("AVD.ProgramacionAVD", new[] { "IdDocente" });
            DropIndex("AVD.CriterioAVD", new[] { "IdAspectoAVD" });
            DropIndex("VEDD.ProgramacionVEDD", new[] { "IdCurso" });
            DropIndex("VEDD.CriterioVEDD", new[] { "IdAspectoVEDD" });
            DropIndex("UNI.PlanificacionGeneral", new[] { "IdCarrera" });
            DropIndex("UNI.Curso", new[] { "IdRecinto" });
            DropIndex("UNI.Curso", new[] { "IdAsignatura" });
            DropIndex("UNI.Curso", new[] { "IdGrupo" });
            DropIndex("UNI.Grupo", new[] { "IdCarrera" });
            DropIndex("UNI.CarreraAsignatura", new[] { "IdAsignatura" });
            DropIndex("UNI.CarreraAsignatura", new[] { "IdCarrera" });
            DropIndex("UNI.DepartamentoCoordinacion", new[] { "IdSedeFacultad" });
            DropIndex("dbo.CarreraSedeFacultads", new[] { "IdSedeFacultad" });
            DropIndex("dbo.CarreraSedeFacultads", new[] { "IdCarrera" });
            DropIndex("UNI.SedeFacultad", new[] { "IdRecinto" });
            DropIndex("UNI.Recinto", new[] { "IdUniversidad" });
            DropTable("dbo.Docentes");
            DropTable("AVD.ProgramacionAVD");
            DropTable("AVD.CriterioAVD");
            DropTable("AVD.AspectoAVD");
            DropTable("VEDD.AplicacionVED");
            DropTable("VEDD.ProgramacionVEDD");
            DropTable("VEDD.CriterioVEDD");
            DropTable("VEDD.AspectoVEDD");
            DropTable("UNI.PlanificacionGeneral");
            DropTable("UNI.Curso");
            DropTable("UNI.Grupo");
            DropTable("UNI.CarreraAsignatura");
            DropTable("UNI.Asignatura");
            DropTable("Admin.MigrationHistory");
            DropTable("UNI.DepartamentoCoordinacion");
            DropTable("UNI.Carrera");
            DropTable("dbo.CarreraSedeFacultads");
            DropTable("UNI.SedeFacultad");
            DropTable("UNI.Universidad");
            DropTable("UNI.Recinto");
        }
    }
}
