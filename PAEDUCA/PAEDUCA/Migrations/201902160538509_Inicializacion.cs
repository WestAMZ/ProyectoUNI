namespace PAEDUCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicializacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AplicacionAACs",
                c => new
                    {
                        IdAplicacionaACC = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        DocenteAcompañante_IdDocente = c.Int(),
                        DocenteEvaluado_IdDocente = c.Int(),
                    })
                .PrimaryKey(t => t.IdAplicacionaACC)
                .ForeignKey("UNI.Docente", t => t.DocenteAcompañante_IdDocente)
                .ForeignKey("UNI.Docente", t => t.DocenteEvaluado_IdDocente)
                .Index(t => t.DocenteAcompañante_IdDocente)
                .Index(t => t.DocenteEvaluado_IdDocente);
            
            CreateTable(
                "AAC.DetalleAplicacionAAC",
                c => new
                    {
                        IdDetalleAplicacion = c.Int(nullable: false, identity: true),
                        IdAplicacionAAC = c.Int(nullable: false),
                        IdCriterioAAC = c.Int(nullable: false),
                        Valor = c.String(maxLength: 10),
                        AplicacionAAC_IdAplicacionaACC = c.Int(),
                        CriterioAAC_IdCriterioACC = c.Int(),
                    })
                .PrimaryKey(t => t.IdDetalleAplicacion)
                .ForeignKey("dbo.AplicacionAACs", t => t.AplicacionAAC_IdAplicacionaACC)
                .ForeignKey("AAC.CriterioAAC", t => t.CriterioAAC_IdCriterioACC)
                .Index(t => t.AplicacionAAC_IdAplicacionaACC)
                .Index(t => t.CriterioAAC_IdCriterioACC);
            
            CreateTable(
                "AAC.CriterioAAC",
                c => new
                    {
                        IdCriterioACC = c.Int(nullable: false, identity: true),
                        Criterio = c.String(nullable: false, maxLength: 350),
                        TipoVisauilzacion = c.Int(nullable: false),
                        TipoValor = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        IdAspectoAAC = c.Int(nullable: false),
                        AspectoAAC_IdAspectoACC = c.Int(),
                    })
                .PrimaryKey(t => t.IdCriterioACC)
                .ForeignKey("AAC.AspectoAAC", t => t.AspectoAAC_IdAspectoACC)
                .Index(t => t.AspectoAAC_IdAspectoACC);
            
            CreateTable(
                "AAC.AspectoAAC",
                c => new
                    {
                        IdAspectoACC = c.Int(nullable: false, identity: true),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAspectoACC);
            
            CreateTable(
                "UNI.Docente",
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
                "UNI.CarreraSedeFacultad",
                c => new
                    {
                        IdCarreraSedeFacultad = c.Int(nullable: false, identity: true),
                        IdCarrera = c.Int(nullable: false),
                        IdSedeFacultad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCarreraSedeFacultad)
                .ForeignKey("dbo.Carreras", t => t.IdCarrera, cascadeDelete: true)
                .ForeignKey("UNI.SedeFacultad", t => t.IdSedeFacultad, cascadeDelete: true)
                .Index(t => t.IdCarrera)
                .Index(t => t.IdSedeFacultad);
            
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        IdCarrera = c.Int(nullable: false, identity: true),
                        NombreCarrera = c.String(),
                        CantidadSemestres = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCarrera);
            
            CreateTable(
                "UNI.Grupo",
                c => new
                    {
                        IdGrupo = c.Int(nullable: false, identity: true),
                        Anio = c.Int(nullable: false),
                        Turno = c.String(maxLength: 20),
                        IdCarreraSedeFacultad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdGrupo)
                .ForeignKey("UNI.CarreraSedeFacultad", t => t.IdCarreraSedeFacultad, cascadeDelete: true)
                .Index(t => t.IdCarreraSedeFacultad);
            
            CreateTable(
                "UNI.Curso",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        IdGrupo = c.Int(nullable: false),
                        IdAsignatura = c.Int(nullable: false),
                        Semestre = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdCurso)
                .ForeignKey("UNI.Asignatura", t => t.IdAsignatura, cascadeDelete: true)
                .ForeignKey("UNI.Grupo", t => t.IdGrupo, cascadeDelete: true)
                .Index(t => t.IdGrupo)
                .Index(t => t.IdAsignatura);
            
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
                .ForeignKey("dbo.Carreras", t => t.IdCarrera, cascadeDelete: true)
                .Index(t => t.IdCarrera)
                .Index(t => t.IdAsignatura);
            
            CreateTable(
                "UNI.DocenteCurso",
                c => new
                    {
                        IdDocenteCurso = c.Int(nullable: false, identity: true),
                        Estado = c.Boolean(nullable: false),
                        Curso_IdCurso = c.Int(),
                        Docente_IdDocente = c.Int(),
                    })
                .PrimaryKey(t => t.IdDocenteCurso)
                .ForeignKey("UNI.Curso", t => t.Curso_IdCurso)
                .ForeignKey("UNI.Docente", t => t.Docente_IdDocente)
                .Index(t => t.Curso_IdCurso)
                .Index(t => t.Docente_IdDocente);
            
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
                "dbo.AplicacionAVDs",
                c => new
                    {
                        IdAplicacionVEDD = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        IdDocenteEvaluado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAplicacionVEDD)
                .ForeignKey("UNI.Docente", t => t.IdDocenteEvaluado, cascadeDelete: true)
                .Index(t => t.IdDocenteEvaluado);
            
            CreateTable(
                "VEDD.AplicacionVED",
                c => new
                    {
                        IdAplicacionVEDD = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        IdDocenteEvaluado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAplicacionVEDD)
                .ForeignKey("UNI.Docente", t => t.IdDocenteEvaluado, cascadeDelete: true)
                .Index(t => t.IdDocenteEvaluado);
            
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
                "dbo.DetalleAplicacionAVDs",
                c => new
                    {
                        IdDetalleAplicacion = c.Int(nullable: false, identity: true),
                        IdAplicacionAVD = c.Int(nullable: false),
                        IdCriterioAVD = c.Int(nullable: false),
                        Valor = c.String(maxLength: 10),
                        AplicacionAVD_IdAplicacionVEDD = c.Int(),
                    })
                .PrimaryKey(t => t.IdDetalleAplicacion)
                .ForeignKey("dbo.AplicacionAVDs", t => t.AplicacionAVD_IdAplicacionVEDD)
                .ForeignKey("AVD.CriterioAVD", t => t.IdCriterioAVD, cascadeDelete: true)
                .Index(t => t.IdCriterioAVD)
                .Index(t => t.AplicacionAVD_IdAplicacionVEDD);
            
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
                "dbo.AplicacionVEDDEstudiantes",
                c => new
                    {
                        IdAplicacionVEDDEstudiante = c.Int(nullable: false, identity: true),
                        IdAplicacionVEDD = c.Int(nullable: false),
                        CriterioVEDD_IdCriterioVEDD = c.Int(),
                    })
                .PrimaryKey(t => t.IdAplicacionVEDDEstudiante)
                .ForeignKey("VEDD.AplicacionVED", t => t.IdAplicacionVEDD, cascadeDelete: true)
                .ForeignKey("VEDD.CriterioVEDD", t => t.CriterioVEDD_IdCriterioVEDD)
                .Index(t => t.IdAplicacionVEDD)
                .Index(t => t.CriterioVEDD_IdCriterioVEDD);
            
            CreateTable(
                "dbo.DetalleAplicacionVEDDs",
                c => new
                    {
                        IdDetalleAplicacionVEDD = c.Int(nullable: false, identity: true),
                        IdCriterioVEDD = c.Int(nullable: false),
                        Valor = c.String(maxLength: 10),
                        AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante = c.Int(),
                    })
                .PrimaryKey(t => t.IdDetalleAplicacionVEDD)
                .ForeignKey("dbo.AplicacionVEDDEstudiantes", t => t.AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante)
                .ForeignKey("VEDD.CriterioVEDD", t => t.IdCriterioVEDD, cascadeDelete: true)
                .Index(t => t.IdCriterioVEDD)
                .Index(t => t.AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante);
            
            CreateTable(
                "UNI.PlanificacionGeneral",
                c => new
                    {
                        IdPlanificacion = c.Int(nullable: false, identity: true),
                        Semestre = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        IdSedeFacultad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPlanificacion)
                .ForeignKey("UNI.SedeFacultad", t => t.IdSedeFacultad, cascadeDelete: true)
                .Index(t => t.IdSedeFacultad);
            
            CreateTable(
                "AAC.AplicacionAAC",
                c => new
                    {
                        IdProgramacionACC = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFin = c.Time(nullable: false, precision: 7),
                        DocenteAcompañante_IdDocente = c.Int(),
                        DocenteEvalua_IdDocente = c.Int(),
                    })
                .PrimaryKey(t => t.IdProgramacionACC)
                .ForeignKey("UNI.Docente", t => t.DocenteAcompañante_IdDocente)
                .ForeignKey("UNI.Docente", t => t.DocenteEvalua_IdDocente)
                .Index(t => t.DocenteAcompañante_IdDocente)
                .Index(t => t.DocenteEvalua_IdDocente);
            
            CreateTable(
                "AVD.AplicacionAVD",
                c => new
                    {
                        IdProgramacionAVD = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFin = c.Time(nullable: false, precision: 7),
                        IdDocente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProgramacionAVD)
                .ForeignKey("UNI.Docente", t => t.IdDocente, cascadeDelete: true)
                .Index(t => t.IdDocente);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("VEDD.ProgramacionVEDD", "IdCurso", "UNI.Curso");
            DropForeignKey("AVD.AplicacionAVD", "IdDocente", "UNI.Docente");
            DropForeignKey("AAC.AplicacionAAC", "DocenteEvalua_IdDocente", "UNI.Docente");
            DropForeignKey("AAC.AplicacionAAC", "DocenteAcompañante_IdDocente", "UNI.Docente");
            DropForeignKey("UNI.PlanificacionGeneral", "IdSedeFacultad", "UNI.SedeFacultad");
            DropForeignKey("VEDD.CriterioVEDD", "IdAspectoVEDD", "VEDD.AspectoVEDD");
            DropForeignKey("dbo.AplicacionVEDDEstudiantes", "CriterioVEDD_IdCriterioVEDD", "VEDD.CriterioVEDD");
            DropForeignKey("dbo.DetalleAplicacionVEDDs", "IdCriterioVEDD", "VEDD.CriterioVEDD");
            DropForeignKey("dbo.DetalleAplicacionVEDDs", "AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante", "dbo.AplicacionVEDDEstudiantes");
            DropForeignKey("dbo.AplicacionVEDDEstudiantes", "IdAplicacionVEDD", "VEDD.AplicacionVED");
            DropForeignKey("dbo.DetalleAplicacionAVDs", "IdCriterioAVD", "AVD.CriterioAVD");
            DropForeignKey("dbo.DetalleAplicacionAVDs", "AplicacionAVD_IdAplicacionVEDD", "dbo.AplicacionAVDs");
            DropForeignKey("AVD.CriterioAVD", "IdAspectoAVD", "AVD.AspectoAVD");
            DropForeignKey("VEDD.AplicacionVED", "IdDocenteEvaluado", "UNI.Docente");
            DropForeignKey("dbo.AplicacionAVDs", "IdDocenteEvaluado", "UNI.Docente");
            DropForeignKey("dbo.AplicacionAACs", "DocenteEvaluado_IdDocente", "UNI.Docente");
            DropForeignKey("dbo.AplicacionAACs", "DocenteAcompañante_IdDocente", "UNI.Docente");
            DropForeignKey("UNI.Docente", "IdDepartamentoCoordinacion", "UNI.DepartamentoCoordinacion");
            DropForeignKey("UNI.DepartamentoCoordinacion", "IdSedeFacultad", "UNI.SedeFacultad");
            DropForeignKey("UNI.SedeFacultad", "IdRecinto", "UNI.Recinto");
            DropForeignKey("UNI.Recinto", "IdUniversidad", "UNI.Universidad");
            DropForeignKey("UNI.CarreraSedeFacultad", "IdSedeFacultad", "UNI.SedeFacultad");
            DropForeignKey("UNI.Curso", "IdGrupo", "UNI.Grupo");
            DropForeignKey("UNI.DocenteCurso", "Docente_IdDocente", "UNI.Docente");
            DropForeignKey("UNI.DocenteCurso", "Curso_IdCurso", "UNI.Curso");
            DropForeignKey("UNI.Curso", "IdAsignatura", "UNI.Asignatura");
            DropForeignKey("UNI.CarreraAsignatura", "IdCarrera", "dbo.Carreras");
            DropForeignKey("UNI.CarreraAsignatura", "IdAsignatura", "UNI.Asignatura");
            DropForeignKey("UNI.Grupo", "IdCarreraSedeFacultad", "UNI.CarreraSedeFacultad");
            DropForeignKey("UNI.CarreraSedeFacultad", "IdCarrera", "dbo.Carreras");
            DropForeignKey("AAC.DetalleAplicacionAAC", "CriterioAAC_IdCriterioACC", "AAC.CriterioAAC");
            DropForeignKey("AAC.CriterioAAC", "AspectoAAC_IdAspectoACC", "AAC.AspectoAAC");
            DropForeignKey("AAC.DetalleAplicacionAAC", "AplicacionAAC_IdAplicacionaACC", "dbo.AplicacionAACs");
            DropIndex("VEDD.ProgramacionVEDD", new[] { "IdCurso" });
            DropIndex("AVD.AplicacionAVD", new[] { "IdDocente" });
            DropIndex("AAC.AplicacionAAC", new[] { "DocenteEvalua_IdDocente" });
            DropIndex("AAC.AplicacionAAC", new[] { "DocenteAcompañante_IdDocente" });
            DropIndex("UNI.PlanificacionGeneral", new[] { "IdSedeFacultad" });
            DropIndex("dbo.DetalleAplicacionVEDDs", new[] { "AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante" });
            DropIndex("dbo.DetalleAplicacionVEDDs", new[] { "IdCriterioVEDD" });
            DropIndex("dbo.AplicacionVEDDEstudiantes", new[] { "CriterioVEDD_IdCriterioVEDD" });
            DropIndex("dbo.AplicacionVEDDEstudiantes", new[] { "IdAplicacionVEDD" });
            DropIndex("VEDD.CriterioVEDD", new[] { "IdAspectoVEDD" });
            DropIndex("dbo.DetalleAplicacionAVDs", new[] { "AplicacionAVD_IdAplicacionVEDD" });
            DropIndex("dbo.DetalleAplicacionAVDs", new[] { "IdCriterioAVD" });
            DropIndex("AVD.CriterioAVD", new[] { "IdAspectoAVD" });
            DropIndex("VEDD.AplicacionVED", new[] { "IdDocenteEvaluado" });
            DropIndex("dbo.AplicacionAVDs", new[] { "IdDocenteEvaluado" });
            DropIndex("UNI.Recinto", new[] { "IdUniversidad" });
            DropIndex("UNI.DocenteCurso", new[] { "Docente_IdDocente" });
            DropIndex("UNI.DocenteCurso", new[] { "Curso_IdCurso" });
            DropIndex("UNI.CarreraAsignatura", new[] { "IdAsignatura" });
            DropIndex("UNI.CarreraAsignatura", new[] { "IdCarrera" });
            DropIndex("UNI.Curso", new[] { "IdAsignatura" });
            DropIndex("UNI.Curso", new[] { "IdGrupo" });
            DropIndex("UNI.Grupo", new[] { "IdCarreraSedeFacultad" });
            DropIndex("UNI.CarreraSedeFacultad", new[] { "IdSedeFacultad" });
            DropIndex("UNI.CarreraSedeFacultad", new[] { "IdCarrera" });
            DropIndex("UNI.SedeFacultad", new[] { "IdRecinto" });
            DropIndex("UNI.DepartamentoCoordinacion", new[] { "IdSedeFacultad" });
            DropIndex("UNI.Docente", new[] { "IdDepartamentoCoordinacion" });
            DropIndex("AAC.CriterioAAC", new[] { "AspectoAAC_IdAspectoACC" });
            DropIndex("AAC.DetalleAplicacionAAC", new[] { "CriterioAAC_IdCriterioACC" });
            DropIndex("AAC.DetalleAplicacionAAC", new[] { "AplicacionAAC_IdAplicacionaACC" });
            DropIndex("dbo.AplicacionAACs", new[] { "DocenteEvaluado_IdDocente" });
            DropIndex("dbo.AplicacionAACs", new[] { "DocenteAcompañante_IdDocente" });
            DropTable("VEDD.ProgramacionVEDD");
            DropTable("AVD.AplicacionAVD");
            DropTable("AAC.AplicacionAAC");
            DropTable("UNI.PlanificacionGeneral");
            DropTable("dbo.DetalleAplicacionVEDDs");
            DropTable("dbo.AplicacionVEDDEstudiantes");
            DropTable("VEDD.CriterioVEDD");
            DropTable("VEDD.AspectoVEDD");
            DropTable("dbo.DetalleAplicacionAVDs");
            DropTable("AVD.CriterioAVD");
            DropTable("AVD.AspectoAVD");
            DropTable("VEDD.AplicacionVED");
            DropTable("dbo.AplicacionAVDs");
            DropTable("UNI.Universidad");
            DropTable("UNI.Recinto");
            DropTable("UNI.DocenteCurso");
            DropTable("UNI.CarreraAsignatura");
            DropTable("UNI.Asignatura");
            DropTable("UNI.Curso");
            DropTable("UNI.Grupo");
            DropTable("dbo.Carreras");
            DropTable("UNI.CarreraSedeFacultad");
            DropTable("UNI.SedeFacultad");
            DropTable("UNI.DepartamentoCoordinacion");
            DropTable("UNI.Docente");
            DropTable("AAC.AspectoAAC");
            DropTable("AAC.CriterioAAC");
            DropTable("AAC.DetalleAplicacionAAC");
            DropTable("dbo.AplicacionAACs");
        }
    }
}