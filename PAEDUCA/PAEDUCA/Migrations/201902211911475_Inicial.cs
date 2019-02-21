namespace PAEDUCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AAC.AplicacionAAC",
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
                .ForeignKey("AAC.AplicacionAAC", t => t.AplicacionAAC_IdAplicacionaACC)
                .ForeignKey("AAC.CriterioAAC", t => t.CriterioAAC_IdCriterioACC)
                .Index(t => t.AplicacionAAC_IdAplicacionaACC)
                .Index(t => t.CriterioAAC_IdCriterioACC);
            
            CreateTable(
                "AAC.CriterioAAC",
                c => new
                    {
                        IdCriterioACC = c.Int(nullable: false, identity: true),
                        IdAspectoAAC = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 350),
                        TipoVisualizacion = c.Int(nullable: false),
                        TipoValor = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
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
                        Nombre = c.String(maxLength: 150),
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
                        Sexo = c.Int(nullable: false),
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
                        Semestre = c.Int(nullable: false),
                        Anio = c.Int(nullable: false),
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
                "AVD.AplicacionAVD",
                c => new
                    {
                        IdAplicacionVEDD = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        IdProgramacionAVD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAplicacionVEDD)
                .ForeignKey("AVD.ProgramacionAVD", t => t.IdProgramacionAVD, cascadeDelete: true)
                .Index(t => t.IdProgramacionAVD);
            
            CreateTable(
                "AVD.ProgramacionAVD",
                c => new
                    {
                        IdProgramacionAVD = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFin = c.Time(nullable: false, precision: 7),
                        IdPlanificacionGeneral = c.Int(nullable: false),
                        IdDocente = c.Int(nullable: false),
                        PlanificacionGeneral_IdPlanificacion = c.Int(),
                    })
                .PrimaryKey(t => t.IdProgramacionAVD)
                .ForeignKey("UNI.Docente", t => t.IdDocente, cascadeDelete: true)
                .ForeignKey("UNI.PlanificacionGeneral", t => t.PlanificacionGeneral_IdPlanificacion)
                .Index(t => t.IdDocente)
                .Index(t => t.PlanificacionGeneral_IdPlanificacion);
            
            CreateTable(
                "UNI.PlanificacionGeneral",
                c => new
                    {
                        IdPlanificacion = c.Int(nullable: false, identity: true),
                        Anio = c.Int(nullable: false),
                        Semestre = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        IdSedeFacultad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPlanificacion)
                .ForeignKey("UNI.SedeFacultad", t => t.IdSedeFacultad, cascadeDelete: true)
                .Index(t => t.IdSedeFacultad);
            
            CreateTable(
                "VEDD.AplicacionVED",
                c => new
                    {
                        IdAplicacionVEDD = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        IdProgramacionVEDD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAplicacionVEDD)
                .ForeignKey("VEDD.ProgramacionVEDD", t => t.IdProgramacionVEDD, cascadeDelete: true)
                .Index(t => t.IdProgramacionVEDD);
            
            CreateTable(
                "VEDD.ProgramacionVEDD",
                c => new
                    {
                        IdProgramacionVED = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFin = c.Time(nullable: false, precision: 7),
                        IdPlanificacionGeneral = c.Int(nullable: false),
                        IdCurso = c.Int(nullable: false),
                        PlanificacionGeneral_IdPlanificacion = c.Int(),
                    })
                .PrimaryKey(t => t.IdProgramacionVED)
                .ForeignKey("UNI.Curso", t => t.IdCurso, cascadeDelete: true)
                .ForeignKey("UNI.PlanificacionGeneral", t => t.PlanificacionGeneral_IdPlanificacion)
                .Index(t => t.IdCurso)
                .Index(t => t.PlanificacionGeneral_IdPlanificacion);
            
            CreateTable(
                "VEDD.AplicacionVEDDEstudiante",
                c => new
                    {
                        IdAplicacionVEDDEstudiante = c.Int(nullable: false, identity: true),
                        IdAplicacionVEDD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAplicacionVEDDEstudiante)
                .ForeignKey("VEDD.AplicacionVED", t => t.IdAplicacionVEDD, cascadeDelete: true)
                .Index(t => t.IdAplicacionVEDD);
            
            CreateTable(
                "VEDD.DetalleAplicacionVEDD",
                c => new
                    {
                        IdDetalleAplicacionVEDD = c.Int(nullable: false, identity: true),
                        IdCriterioVEDD = c.Int(nullable: false),
                        Valor = c.String(maxLength: 10),
                        AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante = c.Int(),
                    })
                .PrimaryKey(t => t.IdDetalleAplicacionVEDD)
                .ForeignKey("VEDD.AplicacionVEDDEstudiante", t => t.AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante)
                .ForeignKey("VEDD.CriterioVEDD", t => t.IdCriterioVEDD, cascadeDelete: true)
                .Index(t => t.IdCriterioVEDD)
                .Index(t => t.AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante);
            
            CreateTable(
                "VEDD.CriterioVEDD",
                c => new
                    {
                        IdCriterioVEDD = c.Int(nullable: false, identity: true),
                        IdAspectoVEDD = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 350),
                        TipoVisualizacion = c.Int(nullable: false),
                        TipoValor = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdCriterioVEDD)
                .ForeignKey("VEDD.AspectoVEDD", t => t.IdAspectoVEDD, cascadeDelete: true)
                .Index(t => t.IdAspectoVEDD);
            
            CreateTable(
                "VEDD.AspectoVEDD",
                c => new
                    {
                        IdAspecto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 150),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAspecto);
            
            CreateTable(
                "AVD.AspectoAVD",
                c => new
                    {
                        IdAspectoAVD = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 150),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAspectoAVD);
            
            CreateTable(
                "AVD.CriterioAVD",
                c => new
                    {
                        IdCriterioAVD = c.Int(nullable: false, identity: true),
                        IdAspectoAVD = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 350),
                        TipoVisualizacion = c.Int(nullable: false),
                        TipoValor = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdCriterioAVD)
                .ForeignKey("AVD.AspectoAVD", t => t.IdAspectoAVD, cascadeDelete: true)
                .Index(t => t.IdAspectoAVD);
            
            CreateTable(
                "AVD.DetalleAplicacionAVD",
                c => new
                    {
                        IdDetalleAplicacion = c.Int(nullable: false, identity: true),
                        IdAplicacionAVD = c.Int(nullable: false),
                        IdCriterioAVD = c.Int(nullable: false),
                        Valor = c.String(maxLength: 10),
                        AplicacionAVD_IdAplicacionVEDD = c.Int(),
                    })
                .PrimaryKey(t => t.IdDetalleAplicacion)
                .ForeignKey("AVD.AplicacionAVD", t => t.AplicacionAVD_IdAplicacionVEDD)
                .ForeignKey("AVD.CriterioAVD", t => t.IdCriterioAVD, cascadeDelete: true)
                .Index(t => t.IdCriterioAVD)
                .Index(t => t.AplicacionAVD_IdAplicacionVEDD);
            
            CreateTable(
                "AAC.ProgramacionAAC",
                c => new
                    {
                        IdProgramacionACC = c.Int(nullable: false, identity: true),
                        FechaAplicacion = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFin = c.Time(nullable: false, precision: 7),
                        IdPlanificacionGeneral = c.Int(nullable: false),
                        DocenteAcompanante_IdDocente = c.Int(),
                        DocenteEvaluado_IdDocente = c.Int(),
                        PlanificacionGeneral_IdPlanificacion = c.Int(),
                    })
                .PrimaryKey(t => t.IdProgramacionACC)
                .ForeignKey("UNI.Docente", t => t.DocenteAcompanante_IdDocente)
                .ForeignKey("UNI.Docente", t => t.DocenteEvaluado_IdDocente)
                .ForeignKey("UNI.PlanificacionGeneral", t => t.PlanificacionGeneral_IdPlanificacion)
                .Index(t => t.DocenteAcompanante_IdDocente)
                .Index(t => t.DocenteEvaluado_IdDocente)
                .Index(t => t.PlanificacionGeneral_IdPlanificacion);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("AAC.ProgramacionAAC", "PlanificacionGeneral_IdPlanificacion", "UNI.PlanificacionGeneral");
            DropForeignKey("AAC.ProgramacionAAC", "DocenteEvaluado_IdDocente", "UNI.Docente");
            DropForeignKey("AAC.ProgramacionAAC", "DocenteAcompanante_IdDocente", "UNI.Docente");
            DropForeignKey("AVD.DetalleAplicacionAVD", "IdCriterioAVD", "AVD.CriterioAVD");
            DropForeignKey("AVD.DetalleAplicacionAVD", "AplicacionAVD_IdAplicacionVEDD", "AVD.AplicacionAVD");
            DropForeignKey("AVD.CriterioAVD", "IdAspectoAVD", "AVD.AspectoAVD");
            DropForeignKey("VEDD.DetalleAplicacionVEDD", "IdCriterioVEDD", "VEDD.CriterioVEDD");
            DropForeignKey("VEDD.CriterioVEDD", "IdAspectoVEDD", "VEDD.AspectoVEDD");
            DropForeignKey("VEDD.DetalleAplicacionVEDD", "AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante", "VEDD.AplicacionVEDDEstudiante");
            DropForeignKey("VEDD.AplicacionVEDDEstudiante", "IdAplicacionVEDD", "VEDD.AplicacionVED");
            DropForeignKey("VEDD.AplicacionVED", "IdProgramacionVEDD", "VEDD.ProgramacionVEDD");
            DropForeignKey("VEDD.ProgramacionVEDD", "PlanificacionGeneral_IdPlanificacion", "UNI.PlanificacionGeneral");
            DropForeignKey("VEDD.ProgramacionVEDD", "IdCurso", "UNI.Curso");
            DropForeignKey("AVD.AplicacionAVD", "IdProgramacionAVD", "AVD.ProgramacionAVD");
            DropForeignKey("AVD.ProgramacionAVD", "PlanificacionGeneral_IdPlanificacion", "UNI.PlanificacionGeneral");
            DropForeignKey("UNI.PlanificacionGeneral", "IdSedeFacultad", "UNI.SedeFacultad");
            DropForeignKey("AVD.ProgramacionAVD", "IdDocente", "UNI.Docente");
            DropForeignKey("AAC.AplicacionAAC", "DocenteEvaluado_IdDocente", "UNI.Docente");
            DropForeignKey("AAC.AplicacionAAC", "DocenteAcompañante_IdDocente", "UNI.Docente");
            DropForeignKey("UNI.Docente", "IdDepartamentoCoordinacion", "UNI.DepartamentoCoordinacion");
            DropForeignKey("UNI.DepartamentoCoordinacion", "IdSedeFacultad", "UNI.SedeFacultad");
            DropForeignKey("UNI.SedeFacultad", "IdRecinto", "UNI.Recinto");
            DropForeignKey("UNI.Recinto", "IdUniversidad", "UNI.Universidad");
            DropForeignKey("UNI.CarreraSedeFacultad", "IdSedeFacultad", "UNI.SedeFacultad");
            DropForeignKey("UNI.Curso", "IdGrupo", "UNI.Grupo");
            DropForeignKey("UNI.DocenteCurso", "Docente_IdDocente", "UNI.Docente");
            DropForeignKey("UNI.DocenteCurso", "Curso_IdCurso", "UNI.Curso");
            DropForeignKey("UNI.Curso", "IdAsignatura", "UNI.Asignatura");
            DropForeignKey("UNI.CarreraAsignatura", "IdCarrera", "UNI.Carrera");
            DropForeignKey("UNI.CarreraAsignatura", "IdAsignatura", "UNI.Asignatura");
            DropForeignKey("UNI.Grupo", "IdCarreraSedeFacultad", "UNI.CarreraSedeFacultad");
            DropForeignKey("UNI.CarreraSedeFacultad", "IdCarrera", "UNI.Carrera");
            DropForeignKey("AAC.DetalleAplicacionAAC", "CriterioAAC_IdCriterioACC", "AAC.CriterioAAC");
            DropForeignKey("AAC.CriterioAAC", "AspectoAAC_IdAspectoACC", "AAC.AspectoAAC");
            DropForeignKey("AAC.DetalleAplicacionAAC", "AplicacionAAC_IdAplicacionaACC", "AAC.AplicacionAAC");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("AAC.ProgramacionAAC", new[] { "PlanificacionGeneral_IdPlanificacion" });
            DropIndex("AAC.ProgramacionAAC", new[] { "DocenteEvaluado_IdDocente" });
            DropIndex("AAC.ProgramacionAAC", new[] { "DocenteAcompanante_IdDocente" });
            DropIndex("AVD.DetalleAplicacionAVD", new[] { "AplicacionAVD_IdAplicacionVEDD" });
            DropIndex("AVD.DetalleAplicacionAVD", new[] { "IdCriterioAVD" });
            DropIndex("AVD.CriterioAVD", new[] { "IdAspectoAVD" });
            DropIndex("VEDD.CriterioVEDD", new[] { "IdAspectoVEDD" });
            DropIndex("VEDD.DetalleAplicacionVEDD", new[] { "AplicacionVEDDEstudiante_IdAplicacionVEDDEstudiante" });
            DropIndex("VEDD.DetalleAplicacionVEDD", new[] { "IdCriterioVEDD" });
            DropIndex("VEDD.AplicacionVEDDEstudiante", new[] { "IdAplicacionVEDD" });
            DropIndex("VEDD.ProgramacionVEDD", new[] { "PlanificacionGeneral_IdPlanificacion" });
            DropIndex("VEDD.ProgramacionVEDD", new[] { "IdCurso" });
            DropIndex("VEDD.AplicacionVED", new[] { "IdProgramacionVEDD" });
            DropIndex("UNI.PlanificacionGeneral", new[] { "IdSedeFacultad" });
            DropIndex("AVD.ProgramacionAVD", new[] { "PlanificacionGeneral_IdPlanificacion" });
            DropIndex("AVD.ProgramacionAVD", new[] { "IdDocente" });
            DropIndex("AVD.AplicacionAVD", new[] { "IdProgramacionAVD" });
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
            DropIndex("AAC.AplicacionAAC", new[] { "DocenteEvaluado_IdDocente" });
            DropIndex("AAC.AplicacionAAC", new[] { "DocenteAcompañante_IdDocente" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("AAC.ProgramacionAAC");
            DropTable("AVD.DetalleAplicacionAVD");
            DropTable("AVD.CriterioAVD");
            DropTable("AVD.AspectoAVD");
            DropTable("VEDD.AspectoVEDD");
            DropTable("VEDD.CriterioVEDD");
            DropTable("VEDD.DetalleAplicacionVEDD");
            DropTable("VEDD.AplicacionVEDDEstudiante");
            DropTable("VEDD.ProgramacionVEDD");
            DropTable("VEDD.AplicacionVED");
            DropTable("UNI.PlanificacionGeneral");
            DropTable("AVD.ProgramacionAVD");
            DropTable("AVD.AplicacionAVD");
            DropTable("UNI.Universidad");
            DropTable("UNI.Recinto");
            DropTable("UNI.DocenteCurso");
            DropTable("UNI.CarreraAsignatura");
            DropTable("UNI.Asignatura");
            DropTable("UNI.Curso");
            DropTable("UNI.Grupo");
            DropTable("UNI.Carrera");
            DropTable("UNI.CarreraSedeFacultad");
            DropTable("UNI.SedeFacultad");
            DropTable("UNI.DepartamentoCoordinacion");
            DropTable("UNI.Docente");
            DropTable("AAC.AspectoAAC");
            DropTable("AAC.CriterioAAC");
            DropTable("AAC.DetalleAplicacionAAC");
            DropTable("AAC.AplicacionAAC");
        }
    }
}
