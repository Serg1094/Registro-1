/* ============================================================
   BASE DE DATOS: SISTEMA DE ATENCION CLINICA
   MOTOR: Microsoft SQL Server
   ============================================================ */

IF DB_ID('ClinicaDB') IS NULL
BEGIN
    CREATE DATABASE ClinicaDB;
END
GO

USE ClinicaDB;
GO

/* ============================================================
   1. CONFIGURACION GENERAL
   ============================================================ */

CREATE TABLE dbo.Sucursales
(
    SucursalID          INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(20) NOT NULL,
    Nombre              NVARCHAR(150) NOT NULL,
    Direccion           NVARCHAR(300) NULL,
    Telefono            VARCHAR(30) NULL,
    Email               VARCHAR(150) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Sucursales_Activo DEFAULT 1,
    FechaCreacion       DATETIME2 NOT NULL CONSTRAINT DF_Sucursales_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Sucursales PRIMARY KEY (SucursalID),
    CONSTRAINT UQ_Sucursales_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Areas
(
    AreaID              INT IDENTITY(1,1) NOT NULL,
    SucursalID          INT NOT NULL,
    Codigo              VARCHAR(30) NOT NULL,
    Nombre              NVARCHAR(100) NOT NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Areas_Activo DEFAULT 1,

    CONSTRAINT PK_Areas PRIMARY KEY (AreaID),
    CONSTRAINT UQ_Areas_Codigo UNIQUE (SucursalID, Codigo),
    CONSTRAINT FK_Areas_Sucursales
        FOREIGN KEY (SucursalID) REFERENCES dbo.Sucursales(SucursalID)
);
GO

CREATE TABLE dbo.Consultorios
(
    ConsultorioID       INT IDENTITY(1,1) NOT NULL,
    SucursalID          INT NOT NULL,
    AreaID              INT NULL,
    Codigo              VARCHAR(30) NOT NULL,
    Nombre              NVARCHAR(100) NOT NULL,
    Piso                VARCHAR(20) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Consultorios_Activo DEFAULT 1,

    CONSTRAINT PK_Consultorios PRIMARY KEY (ConsultorioID),
    CONSTRAINT UQ_Consultorios_Codigo UNIQUE (SucursalID, Codigo),

    CONSTRAINT FK_Consultorios_Sucursales
        FOREIGN KEY (SucursalID) REFERENCES dbo.Sucursales(SucursalID),

    CONSTRAINT FK_Consultorios_Areas
        FOREIGN KEY (AreaID) REFERENCES dbo.Areas(AreaID)
);
GO


/* ============================================================
   2. USUARIOS Y SEGURIDAD
   ============================================================ */

CREATE TABLE dbo.Roles
(
    RolID               INT IDENTITY(1,1) NOT NULL,
    Nombre              NVARCHAR(100) NOT NULL,
    Descripcion         NVARCHAR(300) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Roles_Activo DEFAULT 1,

    CONSTRAINT PK_Roles PRIMARY KEY (RolID),
    CONSTRAINT UQ_Roles_Nombre UNIQUE (Nombre)
);
GO

CREATE TABLE dbo.Permisos
(
    PermisoID           INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(100) NOT NULL,
    Nombre              NVARCHAR(150) NOT NULL,
    Descripcion         NVARCHAR(300) NULL,

    CONSTRAINT PK_Permisos PRIMARY KEY (PermisoID),
    CONSTRAINT UQ_Permisos_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Rol_Permiso
(
    RolID               INT NOT NULL,
    PermisoID           INT NOT NULL,

    CONSTRAINT PK_Rol_Permiso PRIMARY KEY (RolID, PermisoID),

    CONSTRAINT FK_Rol_Permiso_Rol
        FOREIGN KEY (RolID) REFERENCES dbo.Roles(RolID),

    CONSTRAINT FK_Rol_Permiso_Permiso
        FOREIGN KEY (PermisoID) REFERENCES dbo.Permisos(PermisoID)
);
GO

CREATE TABLE dbo.Usuarios
(
    UsuarioID           INT IDENTITY(1,1) NOT NULL,
    RolID               INT NOT NULL,
    SucursalID          INT NULL,
    NombreUsuario       VARCHAR(100) NOT NULL,
    NombreCompleto      NVARCHAR(200) NOT NULL,
    Email               VARCHAR(150) NULL,
    PasswordHash        VARCHAR(500) NOT NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Usuarios_Activo DEFAULT 1,
    UltimoAcceso        DATETIME2 NULL,
    FechaCreacion       DATETIME2 NOT NULL CONSTRAINT DF_Usuarios_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Usuarios PRIMARY KEY (UsuarioID),
    CONSTRAINT UQ_Usuarios_Nombre UNIQUE (NombreUsuario),

    CONSTRAINT FK_Usuarios_Roles
        FOREIGN KEY (RolID) REFERENCES dbo.Roles(RolID),

    CONSTRAINT FK_Usuarios_Sucursales
        FOREIGN KEY (SucursalID) REFERENCES dbo.Sucursales(SucursalID)
);
GO

CREATE TABLE dbo.Sesiones_Usuario
(
    SesionID            BIGINT IDENTITY(1,1) NOT NULL,
    UsuarioID           INT NOT NULL,
    TokenSesion         VARCHAR(500) NULL,
    FechaInicio         DATETIME2 NOT NULL CONSTRAINT DF_Sesiones_FechaInicio DEFAULT SYSDATETIME(),
    FechaFin            DATETIME2 NULL,
    DireccionIP         VARCHAR(50) NULL,
    Dispositivo         NVARCHAR(300) NULL,
    Activa              BIT NOT NULL CONSTRAINT DF_Sesiones_Activa DEFAULT 1,

    CONSTRAINT PK_Sesiones_Usuario PRIMARY KEY (SesionID),

    CONSTRAINT FK_Sesiones_Usuarios
        FOREIGN KEY (UsuarioID) REFERENCES dbo.Usuarios(UsuarioID)
);
GO


/* ============================================================
   3. ESPECIALIDADES Y MEDICOS
   ============================================================ */

CREATE TABLE dbo.Especialidades
(
    EspecialidadID      INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(30) NOT NULL,
    Nombre              NVARCHAR(150) NOT NULL,
    Descripcion         NVARCHAR(300) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Especialidades_Activo DEFAULT 1,

    CONSTRAINT PK_Especialidades PRIMARY KEY (EspecialidadID),
    CONSTRAINT UQ_Especialidades_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Medicos
(
    MedicoID            INT IDENTITY(1,1) NOT NULL,
    UsuarioID           INT NULL,
    CodigoMedico        VARCHAR(50) NOT NULL,
    Nombres             NVARCHAR(100) NOT NULL,
    Apellidos           NVARCHAR(100) NOT NULL,
    NumeroLicencia      VARCHAR(100) NULL,
    Telefono            VARCHAR(30) NULL,
    Email               VARCHAR(150) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Medicos_Activo DEFAULT 1,

    CONSTRAINT PK_Medicos PRIMARY KEY (MedicoID),
    CONSTRAINT UQ_Medicos_Codigo UNIQUE (CodigoMedico),
    CONSTRAINT UQ_Medicos_Usuario UNIQUE (UsuarioID),

    CONSTRAINT FK_Medicos_Usuarios
        FOREIGN KEY (UsuarioID) REFERENCES dbo.Usuarios(UsuarioID)
);
GO

CREATE TABLE dbo.Medico_Especialidad
(
    MedicoID            INT NOT NULL,
    EspecialidadID      INT NOT NULL,
    Principal            BIT NOT NULL CONSTRAINT DF_MedicoEsp_Principal DEFAULT 0,

    CONSTRAINT PK_Medico_Especialidad
        PRIMARY KEY (MedicoID, EspecialidadID),

    CONSTRAINT FK_MedicoEsp_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID),

    CONSTRAINT FK_MedicoEsp_Especialidad
        FOREIGN KEY (EspecialidadID) REFERENCES dbo.Especialidades(EspecialidadID)
);
GO


/* ============================================================
   4. PACIENTES
   ============================================================ */

CREATE TABLE dbo.Pacientes
(
    PacienteID          BIGINT IDENTITY(1,1) NOT NULL,
    CodigoPaciente      VARCHAR(50) NOT NULL,
    TipoDocumento       VARCHAR(30) NOT NULL,
    NumeroDocumento     VARCHAR(50) NOT NULL,
    Nombres             NVARCHAR(100) NOT NULL,
    Apellidos           NVARCHAR(100) NOT NULL,
    FechaNacimiento     DATE NOT NULL,
    Sexo                CHAR(1) NOT NULL,
    EstadoCivil         VARCHAR(30) NULL,
    Telefono            VARCHAR(30) NULL,
    TelefonoSecundario  VARCHAR(30) NULL,
    Email               VARCHAR(150) NULL,
    Direccion           NVARCHAR(300) NULL,
    Ciudad              NVARCHAR(100) NULL,
    Pais                NVARCHAR(100) NULL,
    Ocupacion           NVARCHAR(150) NULL,
    TipoSangre          VARCHAR(10) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Pacientes_Activo DEFAULT 1,
    FechaRegistro       DATETIME2 NOT NULL CONSTRAINT DF_Pacientes_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Pacientes PRIMARY KEY (PacienteID),
    CONSTRAINT UQ_Pacientes_Codigo UNIQUE (CodigoPaciente),
    CONSTRAINT UQ_Pacientes_Documento UNIQUE (TipoDocumento, NumeroDocumento),

    CONSTRAINT CK_Pacientes_Sexo
        CHECK (Sexo IN ('M','F','O'))
);
GO

CREATE TABLE dbo.Contactos_Emergencia
(
    ContactoEmergenciaID BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID            BIGINT NOT NULL,
    NombreCompleto        NVARCHAR(200) NOT NULL,
    Parentesco            NVARCHAR(100) NULL,
    Telefono              VARCHAR(30) NOT NULL,
    TelefonoSecundario    VARCHAR(30) NULL,
    Email                 VARCHAR(150) NULL,
    Prioridad             INT NOT NULL CONSTRAINT DF_Contacto_Prioridad DEFAULT 1,
    Activo                BIT NOT NULL CONSTRAINT DF_Contacto_Activo DEFAULT 1,

    CONSTRAINT PK_Contactos_Emergencia PRIMARY KEY (ContactoEmergenciaID),

    CONSTRAINT FK_Contactos_Pacientes
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT CK_Contacto_Prioridad
        CHECK (Prioridad > 0)
);
GO


/* ============================================================
   5. ASEGURADORAS
   ============================================================ */

CREATE TABLE dbo.Aseguradoras
(
    AseguradoraID       INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(30) NOT NULL,
    Nombre              NVARCHAR(200) NOT NULL,
    NumeroFiscal        VARCHAR(100) NULL,
    Telefono            VARCHAR(30) NULL,
    Email               VARCHAR(150) NULL,
    Direccion           NVARCHAR(300) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Aseguradoras_Activo DEFAULT 1,

    CONSTRAINT PK_Aseguradoras PRIMARY KEY (AseguradoraID),
    CONSTRAINT UQ_Aseguradoras_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Paciente_Aseguradora
(
    PacienteAseguradoraID BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID            BIGINT NOT NULL,
    AseguradoraID         INT NOT NULL,
    NumeroPoliza          VARCHAR(100) NOT NULL,
    NumeroAfiliacion      VARCHAR(100) NULL,
    TitularNombre         NVARCHAR(200) NULL,
    ParentescoTitular     NVARCHAR(100) NULL,
    FechaInicio           DATE NULL,
    FechaFin              DATE NULL,
    CoberturaPorcentaje   DECIMAL(5,2) NULL,
    Activo                BIT NOT NULL CONSTRAINT DF_PacienteAseg_Activo DEFAULT 1,

    CONSTRAINT PK_Paciente_Aseguradora
        PRIMARY KEY (PacienteAseguradoraID),

    CONSTRAINT FK_PacienteAseg_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_PacienteAseg_Aseguradora
        FOREIGN KEY (AseguradoraID) REFERENCES dbo.Aseguradoras(AseguradoraID),

    CONSTRAINT CK_PacienteAseg_Cobertura
        CHECK (CoberturaPorcentaje IS NULL OR
               CoberturaPorcentaje BETWEEN 0 AND 100)
);
GO


/* ============================================================
   6. EXPEDIENTE CLINICO
   ============================================================ */

CREATE TABLE dbo.Expedientes_Clinicos
(
    ExpedienteID        BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    NumeroExpediente    VARCHAR(50) NOT NULL,
    FechaApertura       DATE NOT NULL CONSTRAINT DF_Expediente_Fecha DEFAULT CAST(GETDATE() AS DATE),
    Observaciones       NVARCHAR(MAX) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Expediente_Activo DEFAULT 1,

    CONSTRAINT PK_Expedientes_Clinicos PRIMARY KEY (ExpedienteID),
    CONSTRAINT UQ_Expedientes_Numero UNIQUE (NumeroExpediente),
    CONSTRAINT UQ_Expedientes_Paciente UNIQUE (PacienteID),

    CONSTRAINT FK_Expedientes_Pacientes
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID)
);
GO

CREATE TABLE dbo.Antecedentes_Medicos
(
    AntecedenteMedicoID BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    TipoAntecedente     NVARCHAR(100) NOT NULL,
    Descripcion         NVARCHAR(1000) NOT NULL,
    FechaReferencia     DATE NULL,
    Observaciones       NVARCHAR(MAX) NULL,
    FechaRegistro       DATETIME2 NOT NULL CONSTRAINT DF_AntMed_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Antecedentes_Medicos PRIMARY KEY (AntecedenteMedicoID),

    CONSTRAINT FK_AntMed_Pacientes
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID)
);
GO

CREATE TABLE dbo.Antecedentes_Familiares
(
    AntecedenteFamiliarID BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID            BIGINT NOT NULL,
    Parentesco            NVARCHAR(100) NOT NULL,
    Enfermedad            NVARCHAR(200) NOT NULL,
    Observaciones         NVARCHAR(MAX) NULL,
    FechaRegistro         DATETIME2 NOT NULL CONSTRAINT DF_AntFam_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Antecedentes_Familiares
        PRIMARY KEY (AntecedenteFamiliarID),

    CONSTRAINT FK_AntFam_Pacientes
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID)
);
GO

CREATE TABLE dbo.Alergias
(
    AlergiaID            BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID           BIGINT NOT NULL,
    TipoAlergia          NVARCHAR(100) NULL,
    Alergeno             NVARCHAR(200) NOT NULL,
    Reaccion             NVARCHAR(500) NULL,
    Severidad            VARCHAR(30) NULL,
    Activa               BIT NOT NULL CONSTRAINT DF_Alergias_Activa DEFAULT 1,
    FechaRegistro        DATETIME2 NOT NULL CONSTRAINT DF_Alergias_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Alergias PRIMARY KEY (AlergiaID),

    CONSTRAINT FK_Alergias_Pacientes
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID)
);
GO

CREATE TABLE dbo.Habitos
(
    HabitoID            BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    TipoHabito          NVARCHAR(100) NOT NULL,
    Descripcion         NVARCHAR(1000) NULL,
    Frecuencia          NVARCHAR(100) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Habitos_Activo DEFAULT 1,

    CONSTRAINT PK_Habitos PRIMARY KEY (HabitoID),

    CONSTRAINT FK_Habitos_Pacientes
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID)
);
GO


/* ============================================================
   7. CATALOGOS CLINICOS
   ============================================================ */

CREATE TABLE dbo.Diagnosticos
(
    DiagnosticoID       INT IDENTITY(1,1) NOT NULL,
    CodigoCIE10         VARCHAR(20) NULL,
    Nombre              NVARCHAR(300) NOT NULL,
    Descripcion         NVARCHAR(1000) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Diagnosticos_Activo DEFAULT 1,

    CONSTRAINT PK_Diagnosticos PRIMARY KEY (DiagnosticoID)
);
GO

CREATE UNIQUE INDEX UX_Diagnosticos_CIE10
ON dbo.Diagnosticos(CodigoCIE10)
WHERE CodigoCIE10 IS NOT NULL;
GO

CREATE TABLE dbo.Sintomas
(
    SintomaID           INT IDENTITY(1,1) NOT NULL,
    Nombre              NVARCHAR(200) NOT NULL,
    Descripcion         NVARCHAR(500) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Sintomas_Activo DEFAULT 1,

    CONSTRAINT PK_Sintomas PRIMARY KEY (SintomaID),
    CONSTRAINT UQ_Sintomas_Nombre UNIQUE (Nombre)
);
GO


/* ============================================================
   8. CITAS
   ============================================================ */

CREATE TABLE dbo.Estados_Cita
(
    EstadoCitaID        INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(30) NOT NULL,
    Nombre              NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_Estados_Cita PRIMARY KEY (EstadoCitaID),
    CONSTRAINT UQ_Estados_Cita_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Citas
(
    CitaID              BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    MedicoID            INT NOT NULL,
    EspecialidadID      INT NULL,
    ConsultorioID       INT NULL,
    EstadoCitaID        INT NOT NULL,
    FechaHoraInicio     DATETIME2 NOT NULL,
    FechaHoraFin        DATETIME2 NULL,
    Motivo              NVARCHAR(1000) NULL,
    Observaciones       NVARCHAR(1000) NULL,
    UsuarioCreacionID   INT NULL,
    FechaCreacion       DATETIME2 NOT NULL CONSTRAINT DF_Citas_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Citas PRIMARY KEY (CitaID),

    CONSTRAINT FK_Citas_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Citas_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID),

    CONSTRAINT FK_Citas_Especialidad
        FOREIGN KEY (EspecialidadID) REFERENCES dbo.Especialidades(EspecialidadID),

    CONSTRAINT FK_Citas_Consultorio
        FOREIGN KEY (ConsultorioID) REFERENCES dbo.Consultorios(ConsultorioID),

    CONSTRAINT FK_Citas_Estado
        FOREIGN KEY (EstadoCitaID) REFERENCES dbo.Estados_Cita(EstadoCitaID),

    CONSTRAINT FK_Citas_Usuario
        FOREIGN KEY (UsuarioCreacionID) REFERENCES dbo.Usuarios(UsuarioID),

    CONSTRAINT CK_Citas_Fechas
        CHECK (FechaHoraFin IS NULL OR FechaHoraFin > FechaHoraInicio)
);
GO


/* ============================================================
   9. TURNOS
   ============================================================ */

CREATE TABLE dbo.Turnos
(
    TurnoID             BIGINT IDENTITY(1,1) NOT NULL,
    CitaID              BIGINT NULL,
    PacienteID          BIGINT NOT NULL,
    SucursalID          INT NOT NULL,
    NumeroTurno         VARCHAR(30) NOT NULL,
    FechaTurno          DATE NOT NULL,
    Prioridad            INT NOT NULL CONSTRAINT DF_Turnos_Prioridad DEFAULT 0,
    Estado               VARCHAR(30) NOT NULL,
    FechaIngreso        DATETIME2 NOT NULL CONSTRAINT DF_Turnos_Ingreso DEFAULT SYSDATETIME(),
    FechaLlamado        DATETIME2 NULL,
    FechaAtencion       DATETIME2 NULL,
    FechaFinalizacion   DATETIME2 NULL,

    CONSTRAINT PK_Turnos PRIMARY KEY (TurnoID),

    CONSTRAINT FK_Turnos_Cita
        FOREIGN KEY (CitaID) REFERENCES dbo.Citas(CitaID),

    CONSTRAINT FK_Turnos_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Turnos_Sucursal
        FOREIGN KEY (SucursalID) REFERENCES dbo.Sucursales(SucursalID)
);
GO


/* ============================================================
   10. ATENCIONES
   ============================================================ */

CREATE TABLE dbo.Atenciones
(
    AtencionID          BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    MedicoID            INT NOT NULL,
    CitaID              BIGINT NULL,
    ExpedienteID        BIGINT NOT NULL,
    FechaInicio         DATETIME2 NOT NULL CONSTRAINT DF_Atenciones_Inicio DEFAULT SYSDATETIME(),
    FechaFin            DATETIME2 NULL,
    MotivoConsulta      NVARCHAR(2000) NULL,
    EnfermedadActual    NVARCHAR(MAX) NULL,
    ExploracionFisica   NVARCHAR(MAX) NULL,
    Observaciones       NVARCHAR(MAX) NULL,
    Estado              VARCHAR(30) NOT NULL CONSTRAINT DF_Atenciones_Estado DEFAULT 'ABIERTA',
    UsuarioCreacionID   INT NULL,

    CONSTRAINT PK_Atenciones PRIMARY KEY (AtencionID),

    CONSTRAINT FK_Atenciones_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Atenciones_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID),

    CONSTRAINT FK_Atenciones_Cita
        FOREIGN KEY (CitaID) REFERENCES dbo.Citas(CitaID),

    CONSTRAINT FK_Atenciones_Expediente
        FOREIGN KEY (ExpedienteID) REFERENCES dbo.Expedientes_Clinicos(ExpedienteID),

    CONSTRAINT FK_Atenciones_Usuario
        FOREIGN KEY (UsuarioCreacionID) REFERENCES dbo.Usuarios(UsuarioID),

    CONSTRAINT CK_Atenciones_Fechas
        CHECK (FechaFin IS NULL OR FechaFin >= FechaInicio)
);
GO


/* ============================================================
   11. SIGNOS VITALES
   ============================================================ */

CREATE TABLE dbo.Signos_Vitales
(
    SignosVitalesID     BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID          BIGINT NOT NULL,
    FechaRegistro       DATETIME2 NOT NULL CONSTRAINT DF_Signos_Fecha DEFAULT SYSDATETIME(),
    PresionSistolica    DECIMAL(5,2) NULL,
    PresionDiastolica   DECIMAL(5,2) NULL,
    FrecuenciaCardiaca  DECIMAL(5,2) NULL,
    FrecuenciaRespiratoria DECIMAL(5,2) NULL,
    Temperatura         DECIMAL(5,2) NULL,
    SaturacionOxigeno   DECIMAL(5,2) NULL,
    PesoKg              DECIMAL(7,2) NULL,
    TallaCm             DECIMAL(6,2) NULL,
    IMC                 DECIMAL(6,2) NULL,
    Observaciones       NVARCHAR(1000) NULL,

    CONSTRAINT PK_Signos_Vitales PRIMARY KEY (SignosVitalesID),

    CONSTRAINT FK_Signos_Atenciones
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT CK_Signos_Saturacion
        CHECK (SaturacionOxigeno IS NULL OR SaturacionOxigeno BETWEEN 0 AND 100),

    CONSTRAINT CK_Signos_Peso
        CHECK (PesoKg IS NULL OR PesoKg > 0),

    CONSTRAINT CK_Signos_Talla
        CHECK (TallaCm IS NULL OR TallaCm > 0)
);
GO


/* ============================================================
   12. SINTOMAS Y DIAGNOSTICOS
   ============================================================ */

CREATE TABLE dbo.Atencion_Sintoma
(
    AtencionSintomaID  BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID         BIGINT NOT NULL,
    SintomaID          INT NOT NULL,
    Intensidad         VARCHAR(30) NULL,
    Duracion           NVARCHAR(100) NULL,
    Observaciones      NVARCHAR(1000) NULL,

    CONSTRAINT PK_Atencion_Sintoma PRIMARY KEY (AtencionSintomaID),

    CONSTRAINT FK_AtencionSintoma_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_AtencionSintoma_Sintoma
        FOREIGN KEY (SintomaID) REFERENCES dbo.Sintomas(SintomaID)
);
GO

CREATE TABLE dbo.Atencion_Diagnostico
(
    AtencionDiagnosticoID BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID            BIGINT NOT NULL,
    DiagnosticoID         INT NOT NULL,
    TipoDiagnostico       VARCHAR(30) NOT NULL,
    Observaciones         NVARCHAR(1000) NULL,

    CONSTRAINT PK_Atencion_Diagnostico
        PRIMARY KEY (AtencionDiagnosticoID),

    CONSTRAINT FK_AtencionDiagnostico_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_AtencionDiagnostico_Diagnostico
        FOREIGN KEY (DiagnosticoID) REFERENCES dbo.Diagnosticos(DiagnosticoID),

    CONSTRAINT CK_AtencionDiagnostico_Tipo
        CHECK (TipoDiagnostico IN ('PRINCIPAL','SECUNDARIO','PRESUNTIVO','CONFIRMADO'))
);
GO

CREATE TABLE dbo.Notas_Medicas
(
    NotaMedicaID       BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID         BIGINT NOT NULL,
    MedicoID           INT NOT NULL,
    TipoNota            VARCHAR(30) NOT NULL,
    Contenido           NVARCHAR(MAX) NOT NULL,
    FechaRegistro       DATETIME2 NOT NULL CONSTRAINT DF_Notas_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Notas_Medicas PRIMARY KEY (NotaMedicaID),

    CONSTRAINT FK_Notas_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_Notas_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID)
);
GO


/* ============================================================
   13. MEDICAMENTOS Y PRESCRIPCIONES
   ============================================================ */

CREATE TABLE dbo.Medicamentos
(
    MedicamentoID       INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(50) NOT NULL,
    Nombre              NVARCHAR(200) NOT NULL,
    PrincipioActivo     NVARCHAR(300) NULL,
    Concentracion       NVARCHAR(100) NULL,
    Presentacion        NVARCHAR(100) NULL,
    UnidadMedida        VARCHAR(30) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Medicamentos_Activo DEFAULT 1,

    CONSTRAINT PK_Medicamentos PRIMARY KEY (MedicamentoID),
    CONSTRAINT UQ_Medicamentos_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Prescripciones
(
    PrescripcionID      BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID          BIGINT NOT NULL,
    PacienteID          BIGINT NOT NULL,
    MedicoID            INT NOT NULL,
    FechaPrescripcion   DATETIME2 NOT NULL CONSTRAINT DF_Prescripciones_Fecha DEFAULT SYSDATETIME(),
    Observaciones       NVARCHAR(MAX) NULL,

    CONSTRAINT PK_Prescripciones PRIMARY KEY (PrescripcionID),

    CONSTRAINT FK_Prescripciones_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_Prescripciones_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Prescripciones_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID)
);
GO

CREATE TABLE dbo.Prescripcion_Detalle
(
    PrescripcionDetalleID BIGINT IDENTITY(1,1) NOT NULL,
    PrescripcionID        BIGINT NOT NULL,
    MedicamentoID         INT NOT NULL,
    Dosis                 NVARCHAR(100) NULL,
    Frecuencia            NVARCHAR(100) NULL,
    Duracion              NVARCHAR(100) NULL,
    ViaAdministracion    NVARCHAR(100) NULL,
    Cantidad              DECIMAL(12,2) NULL,
    Indicaciones          NVARCHAR(1000) NULL,

    CONSTRAINT PK_Prescripcion_Detalle
        PRIMARY KEY (PrescripcionDetalleID),

    CONSTRAINT FK_PrescripcionDetalle_Prescripcion
        FOREIGN KEY (PrescripcionID) REFERENCES dbo.Prescripciones(PrescripcionID),

    CONSTRAINT FK_PrescripcionDetalle_Medicamento
        FOREIGN KEY (MedicamentoID) REFERENCES dbo.Medicamentos(MedicamentoID)
);
GO


/* ============================================================
   14. TRATAMIENTOS
   ============================================================ */

CREATE TABLE dbo.Tratamientos
(
    TratamientoID       BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    AtencionID          BIGINT NOT NULL,
    MedicoID            INT NOT NULL,
    Nombre              NVARCHAR(200) NOT NULL,
    Descripcion         NVARCHAR(MAX) NULL,
    FechaInicio         DATE NULL,
    FechaFin            DATE NULL,
    Estado              VARCHAR(30) NOT NULL CONSTRAINT DF_Tratamientos_Estado DEFAULT 'ACTIVO',

    CONSTRAINT PK_Tratamientos PRIMARY KEY (TratamientoID),

    CONSTRAINT FK_Tratamientos_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Tratamientos_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_Tratamientos_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID),

    CONSTRAINT CK_Tratamientos_Fechas
        CHECK (FechaFin IS NULL OR FechaInicio IS NULL OR FechaFin >= FechaInicio)
);
GO


/* ============================================================
   15. ESTUDIOS
   ============================================================ */

CREATE TABLE dbo.Catalogo_Estudios
(
    EstudioID           INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(50) NOT NULL,
    Nombre              NVARCHAR(200) NOT NULL,
    TipoEstudio         NVARCHAR(100) NULL,
    Descripcion         NVARCHAR(1000) NULL,
    UnidadResultado     NVARCHAR(50) NULL,
    RangoReferencia     NVARCHAR(200) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Estudios_Activo DEFAULT 1,

    CONSTRAINT PK_Catalogo_Estudios PRIMARY KEY (EstudioID),
    CONSTRAINT UQ_Catalogo_Estudios_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Solicitudes_Estudio
(
    SolicitudEstudioID  BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID          BIGINT NOT NULL,
    PacienteID          BIGINT NOT NULL,
    MedicoID            INT NOT NULL,
    FechaSolicitud      DATETIME2 NOT NULL CONSTRAINT DF_Solicitudes_Fecha DEFAULT SYSDATETIME(),
    Prioridad           VARCHAR(30) NOT NULL CONSTRAINT DF_Solicitudes_Prioridad DEFAULT 'NORMAL',
    Observaciones       NVARCHAR(MAX) NULL,
    Estado              VARCHAR(30) NOT NULL CONSTRAINT DF_Solicitudes_Estado DEFAULT 'SOLICITADO',

    CONSTRAINT PK_Solicitudes_Estudio PRIMARY KEY (SolicitudEstudioID),

    CONSTRAINT FK_Solicitudes_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_Solicitudes_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Solicitudes_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID)
);
GO

CREATE TABLE dbo.Solicitud_Estudio_Detalle
(
    SolicitudEstudioDetalleID BIGINT IDENTITY(1,1) NOT NULL,
    SolicitudEstudioID        BIGINT NOT NULL,
    EstudioID                 INT NOT NULL,
    Indicaciones              NVARCHAR(1000) NULL,
    Estado                    VARCHAR(30) NOT NULL CONSTRAINT DF_SolicitudDetalle_Estado DEFAULT 'SOLICITADO',

    CONSTRAINT PK_Solicitud_Estudio_Detalle
        PRIMARY KEY (SolicitudEstudioDetalleID),

    CONSTRAINT FK_SolicitudDetalle_Solicitud
        FOREIGN KEY (SolicitudEstudioID) REFERENCES dbo.Solicitudes_Estudio(SolicitudEstudioID),

    CONSTRAINT FK_SolicitudDetalle_Estudio
        FOREIGN KEY (EstudioID) REFERENCES dbo.Catalogo_Estudios(EstudioID)
);
GO

CREATE TABLE dbo.Resultados_Estudio
(
    ResultadoEstudioID       BIGINT IDENTITY(1,1) NOT NULL,
    SolicitudEstudioDetalleID BIGINT NOT NULL,
    FechaResultado            DATETIME2 NOT NULL CONSTRAINT DF_Resultados_Fecha DEFAULT SYSDATETIME(),
    Resultado                 NVARCHAR(MAX) NULL,
    ValorNumerico             DECIMAL(18,6) NULL,
    Unidad                    NVARCHAR(50) NULL,
    RangoReferencia           NVARCHAR(200) NULL,
    Observaciones             NVARCHAR(MAX) NULL,
    UsuarioRegistroID         INT NULL,

    CONSTRAINT PK_Resultados_Estudio
        PRIMARY KEY (ResultadoEstudioID),

    CONSTRAINT FK_Resultados_SolicitudDetalle
        FOREIGN KEY (SolicitudEstudioDetalleID)
        REFERENCES dbo.Solicitud_Estudio_Detalle(SolicitudEstudioDetalleID),

    CONSTRAINT FK_Resultados_Usuario
        FOREIGN KEY (UsuarioRegistroID)
        REFERENCES dbo.Usuarios(UsuarioID)
);
GO


/* ============================================================
   16. PROCEDIMIENTOS
   ============================================================ */

CREATE TABLE dbo.Procedimientos
(
    ProcedimientoID     INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(50) NOT NULL,
    Nombre              NVARCHAR(250) NOT NULL,
    Descripcion         NVARCHAR(1000) NULL,
    DuracionMinutos     INT NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Procedimientos_Activo DEFAULT 1,

    CONSTRAINT PK_Procedimientos PRIMARY KEY (ProcedimientoID),
    CONSTRAINT UQ_Procedimientos_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Atencion_Procedimiento
(
    AtencionProcedimientoID BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID              BIGINT NOT NULL,
    ProcedimientoID         INT NOT NULL,
    MedicoID                INT NULL,
    FechaRealizacion        DATETIME2 NOT NULL CONSTRAINT DF_AtProc_Fecha DEFAULT SYSDATETIME(),
    Resultado               NVARCHAR(MAX) NULL,
    Observaciones           NVARCHAR(MAX) NULL,
    Estado                  VARCHAR(30) NOT NULL CONSTRAINT DF_AtProc_Estado DEFAULT 'REALIZADO',

    CONSTRAINT PK_Atencion_Procedimiento
        PRIMARY KEY (AtencionProcedimientoID),

    CONSTRAINT FK_AtProc_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_AtProc_Procedimiento
        FOREIGN KEY (ProcedimientoID) REFERENCES dbo.Procedimientos(ProcedimientoID),

    CONSTRAINT FK_AtProc_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID)
);
GO

CREATE TABLE dbo.Indicaciones_Medicas
(
    IndicacionID        BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID          BIGINT NOT NULL,
    MedicoID            INT NOT NULL,
    Indicacion           NVARCHAR(MAX) NOT NULL,
    FechaRegistro       DATETIME2 NOT NULL CONSTRAINT DF_Indicaciones_Fecha DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Indicaciones_Medicas PRIMARY KEY (IndicacionID),

    CONSTRAINT FK_Indicaciones_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_Indicaciones_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID)
);
GO

CREATE TABLE dbo.Referencias_Medicas
(
    ReferenciaID        BIGINT IDENTITY(1,1) NOT NULL,
    AtencionID          BIGINT NOT NULL,
    PacienteID          BIGINT NOT NULL,
    MedicoID            INT NOT NULL,
    EspecialidadID      INT NULL,
    Institucion         NVARCHAR(200) NULL,
    Motivo              NVARCHAR(2000) NOT NULL,
    Observaciones       NVARCHAR(MAX) NULL,
    FechaReferencia     DATE NOT NULL CONSTRAINT DF_Referencias_Fecha DEFAULT CAST(GETDATE() AS DATE),
    Estado              VARCHAR(30) NOT NULL CONSTRAINT DF_Referencias_Estado DEFAULT 'PENDIENTE',

    CONSTRAINT PK_Referencias_Medicas PRIMARY KEY (ReferenciaID),

    CONSTRAINT FK_Referencias_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_Referencias_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Referencias_Medico
        FOREIGN KEY (MedicoID) REFERENCES dbo.Medicos(MedicoID),

    CONSTRAINT FK_Referencias_Especialidad
        FOREIGN KEY (EspecialidadID) REFERENCES dbo.Especialidades(EspecialidadID)
);
GO


/* ============================================================
   17. ARCHIVOS CLINICOS
   ============================================================ */

CREATE TABLE dbo.Archivos_Clinicos
(
    ArchivoClinicoID   BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    AtencionID          BIGINT NULL,
    TipoArchivo         VARCHAR(50) NOT NULL,
    NombreArchivo       NVARCHAR(255) NOT NULL,
    RutaArchivo         NVARCHAR(1000) NOT NULL,
    Extension            VARCHAR(20) NULL,
    TamanoBytes         BIGINT NULL,
    FechaCarga          DATETIME2 NOT NULL CONSTRAINT DF_Archivos_Fecha DEFAULT SYSDATETIME(),
    UsuarioCargaID      INT NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Archivos_Activo DEFAULT 1,

    CONSTRAINT PK_Archivos_Clinicos PRIMARY KEY (ArchivoClinicoID),

    CONSTRAINT FK_Archivos_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Archivos_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_Archivos_Usuario
        FOREIGN KEY (UsuarioCargaID) REFERENCES dbo.Usuarios(UsuarioID)
);
GO


/* ============================================================
   18. SERVICIOS Y TARIFAS
   ============================================================ */

CREATE TABLE dbo.Servicios
(
    ServicioID          INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(50) NOT NULL,
    Nombre              NVARCHAR(250) NOT NULL,
    TipoServicio        VARCHAR(50) NOT NULL,
    Descripcion         NVARCHAR(1000) NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_Servicios_Activo DEFAULT 1,

    CONSTRAINT PK_Servicios PRIMARY KEY (ServicioID),
    CONSTRAINT UQ_Servicios_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Tarifas
(
    TarifaID            INT IDENTITY(1,1) NOT NULL,
    ServicioID          INT NOT NULL,
    AseguradoraID       INT NULL,
    NombreTarifa        NVARCHAR(150) NOT NULL,
    Precio              DECIMAL(18,2) NOT NULL,
    Moneda              CHAR(3) NOT NULL CONSTRAINT DF_Tarifas_Moneda DEFAULT 'USD',
    FechaInicio         DATE NOT NULL,
    FechaFin            DATE NULL,
    Activa              BIT NOT NULL CONSTRAINT DF_Tarifas_Activa DEFAULT 1,

    CONSTRAINT PK_Tarifas PRIMARY KEY (TarifaID),

    CONSTRAINT FK_Tarifas_Servicio
        FOREIGN KEY (ServicioID) REFERENCES dbo.Servicios(ServicioID),

    CONSTRAINT FK_Tarifas_Aseguradora
        FOREIGN KEY (AseguradoraID) REFERENCES dbo.Aseguradoras(AseguradoraID),

    CONSTRAINT CK_Tarifas_Precio
        CHECK (Precio >= 0),

    CONSTRAINT CK_Tarifas_Fechas
        CHECK (FechaFin IS NULL OR FechaFin >= FechaInicio)
);
GO


/* ============================================================
   19. FACTURACION
   ============================================================ */

CREATE TABLE dbo.Formas_Pago
(
    FormaPagoID        INT IDENTITY(1,1) NOT NULL,
    Codigo              VARCHAR(30) NOT NULL,
    Nombre              NVARCHAR(100) NOT NULL,
    Activo              BIT NOT NULL CONSTRAINT DF_FormasPago_Activo DEFAULT 1,

    CONSTRAINT PK_Formas_Pago PRIMARY KEY (FormaPagoID),
    CONSTRAINT UQ_FormasPago_Codigo UNIQUE (Codigo)
);
GO

CREATE TABLE dbo.Facturas
(
    FacturaID           BIGINT IDENTITY(1,1) NOT NULL,
    NumeroFactura       VARCHAR(50) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    AseguradoraID       INT NULL,
    AtencionID          BIGINT NULL,
    FechaFactura        DATETIME2 NOT NULL CONSTRAINT DF_Facturas_Fecha DEFAULT SYSDATETIME(),
    Subtotal             DECIMAL(18,2) NOT NULL,
    Descuento            DECIMAL(18,2) NOT NULL CONSTRAINT DF_Facturas_Descuento DEFAULT 0,
    Impuesto             DECIMAL(18,2) NOT NULL CONSTRAINT DF_Facturas_Impuesto DEFAULT 0,
    Total                DECIMAL(18,2) NOT NULL,
    Saldo                DECIMAL(18,2) NOT NULL,
    Estado               VARCHAR(30) NOT NULL CONSTRAINT DF_Facturas_Estado DEFAULT 'PENDIENTE',
    UsuarioCreacionID   INT NULL,

    CONSTRAINT PK_Facturas PRIMARY KEY (FacturaID),
    CONSTRAINT UQ_Facturas_Numero UNIQUE (NumeroFactura),

    CONSTRAINT FK_Facturas_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Facturas_Aseguradora
        FOREIGN KEY (AseguradoraID) REFERENCES dbo.Aseguradoras(AseguradoraID),

    CONSTRAINT FK_Facturas_Atencion
        FOREIGN KEY (AtencionID) REFERENCES dbo.Atenciones(AtencionID),

    CONSTRAINT FK_Facturas_Usuario
        FOREIGN KEY (UsuarioCreacionID) REFERENCES dbo.Usuarios(UsuarioID),

    CONSTRAINT CK_Facturas_Importes
        CHECK (
            Subtotal >= 0 AND
            Descuento >= 0 AND
            Impuesto >= 0 AND
            Total >= 0 AND
            Saldo >= 0
        )
);
GO

CREATE TABLE dbo.Factura_Detalle
(
    FacturaDetalleID    BIGINT IDENTITY(1,1) NOT NULL,
    FacturaID           BIGINT NOT NULL,
    ServicioID          INT NOT NULL,
    Descripcion         NVARCHAR(500) NOT NULL,
    Cantidad             DECIMAL(12,2) NOT NULL,
    PrecioUnitario      DECIMAL(18,2) NOT NULL,
    Descuento           DECIMAL(18,2) NOT NULL CONSTRAINT DF_FacturaDetalle_Descuento DEFAULT 0,
    Impuesto            DECIMAL(18,2) NOT NULL CONSTRAINT DF_FacturaDetalle_Impuesto DEFAULT 0,
    Total               DECIMAL(18,2) NOT NULL,

    CONSTRAINT PK_Factura_Detalle PRIMARY KEY (FacturaDetalleID),

    CONSTRAINT FK_FacturaDetalle_Factura
        FOREIGN KEY (FacturaID) REFERENCES dbo.Facturas(FacturaID),

    CONSTRAINT FK_FacturaDetalle_Servicio
        FOREIGN KEY (ServicioID) REFERENCES dbo.Servicios(ServicioID),

    CONSTRAINT CK_FacturaDetalle_Cantidad
        CHECK (Cantidad > 0),

    CONSTRAINT CK_FacturaDetalle_Precio
        CHECK (PrecioUnitario >= 0)
);
GO

CREATE TABLE dbo.Pagos
(
    PagoID              BIGINT IDENTITY(1,1) NOT NULL,
    FacturaID           BIGINT NOT NULL,
    FormaPagoID         INT NOT NULL,
    FechaPago           DATETIME2 NOT NULL CONSTRAINT DF_Pagos_Fecha DEFAULT SYSDATETIME(),
    Monto               DECIMAL(18,2) NOT NULL,
    Referencia          VARCHAR(200) NULL,
    Observaciones       NVARCHAR(1000) NULL,
    UsuarioRegistroID   INT NULL,

    CONSTRAINT PK_Pagos PRIMARY KEY (PagoID),

    CONSTRAINT FK_Pagos_Factura
        FOREIGN KEY (FacturaID) REFERENCES dbo.Facturas(FacturaID),

    CONSTRAINT FK_Pagos_FormaPago
        FOREIGN KEY (FormaPagoID) REFERENCES dbo.Formas_Pago(FormaPagoID),

    CONSTRAINT FK_Pagos_Usuario
        FOREIGN KEY (UsuarioRegistroID) REFERENCES dbo.Usuarios(UsuarioID),

    CONSTRAINT CK_Pagos_Monto
        CHECK (Monto > 0)
);
GO

CREATE TABLE dbo.Creditos_Medicos
(
    CreditoID           BIGINT IDENTITY(1,1) NOT NULL,
    PacienteID          BIGINT NOT NULL,
    FacturaID           BIGINT NULL,
    Tipo                VARCHAR(30) NOT NULL,
    MontoOriginal       DECIMAL(18,2) NOT NULL,
    MontoDisponible     DECIMAL(18,2) NOT NULL,
    FechaCreacion       DATETIME2 NOT NULL CONSTRAINT DF_Creditos_Fecha DEFAULT SYSDATETIME(),
    FechaVencimiento    DATE NULL,
    Estado              VARCHAR(30) NOT NULL CONSTRAINT DF_Creditos_Estado DEFAULT 'ACTIVO',
    Observaciones       NVARCHAR(1000) NULL,

    CONSTRAINT PK_Creditos_Medicos PRIMARY KEY (CreditoID),

    CONSTRAINT FK_Creditos_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID),

    CONSTRAINT FK_Creditos_Factura
        FOREIGN KEY (FacturaID) REFERENCES dbo.Facturas(FacturaID),

    CONSTRAINT CK_Creditos_Montos
        CHECK (
            MontoOriginal >= 0 AND
            MontoDisponible >= 0 AND
            MontoDisponible <= MontoOriginal
        )
);
GO


/* ============================================================
   20. NOTIFICACIONES
   ============================================================ */

CREATE TABLE dbo.Notificaciones
(
    NotificacionID     BIGINT IDENTITY(1,1) NOT NULL,
    UsuarioID          INT NULL,
    PacienteID         BIGINT NULL,
    Tipo               VARCHAR(50) NOT NULL,
    Titulo             NVARCHAR(200) NOT NULL,
    Mensaje             NVARCHAR(MAX) NOT NULL,
    FechaCreacion       DATETIME2 NOT NULL CONSTRAINT DF_Notificaciones_Fecha DEFAULT SYSDATETIME(),
    FechaLectura        DATETIME2 NULL,
    Leida               BIT NOT NULL CONSTRAINT DF_Notificaciones_Leida DEFAULT 0,

    CONSTRAINT PK_Notificaciones PRIMARY KEY (NotificacionID),

    CONSTRAINT FK_Notificaciones_Usuario
        FOREIGN KEY (UsuarioID) REFERENCES dbo.Usuarios(UsuarioID),

    CONSTRAINT FK_Notificaciones_Paciente
        FOREIGN KEY (PacienteID) REFERENCES dbo.Pacientes(PacienteID)
);
GO


/* ============================================================
   21. AUDITORIA
   ============================================================ */

CREATE TABLE dbo.Auditoria
(
    AuditoriaID        BIGINT IDENTITY(1,1) NOT NULL,
    UsuarioID           INT NULL,
    FechaHora            DATETIME2 NOT NULL CONSTRAINT DF_Auditoria_Fecha DEFAULT SYSDATETIME(),
    Accion               VARCHAR(30) NOT NULL,
    TablaAfectada       VARCHAR(128) NOT NULL,
    RegistroID          VARCHAR(100) NULL,
    DatosAnteriores     NVARCHAR(MAX) NULL,
    DatosNuevos         NVARCHAR(MAX) NULL,
    DireccionIP         VARCHAR(50) NULL,
    Observaciones       NVARCHAR(1000) NULL,

    CONSTRAINT PK_Auditoria PRIMARY KEY (AuditoriaID),

    CONSTRAINT FK_Auditoria_Usuario
        FOREIGN KEY (UsuarioID) REFERENCES dbo.Usuarios(UsuarioID)
);
GO


/* ============================================================
   22. INDICES PRINCIPALES
   ============================================================ */

CREATE INDEX IX_Pacientes_Nombre
ON dbo.Pacientes(Apellidos, Nombres);
GO

CREATE INDEX IX_Citas_Fecha
ON dbo.Citas(FechaHoraInicio);
GO

CREATE INDEX IX_Citas_Paciente
ON dbo.Citas(PacienteID, FechaHoraInicio);
GO

CREATE INDEX IX_Citas_Medico
ON dbo.Citas(MedicoID, FechaHoraInicio);
GO

CREATE INDEX IX_Atenciones_Paciente
ON dbo.Atenciones(PacienteID, FechaInicio);
GO

CREATE INDEX IX_Atenciones_Medico
ON dbo.Atenciones(MedicoID, FechaInicio);
GO

CREATE INDEX IX_AtencionDiagnostico_Atencion
ON dbo.Atencion_Diagnostico(AtencionID);
GO

CREATE INDEX IX_Prescripciones_Paciente
ON dbo.Prescripciones(PacienteID, FechaPrescripcion);
GO

CREATE INDEX IX_SolicitudesEstudio_Paciente
ON dbo.Solicitudes_Estudio(PacienteID, FechaSolicitud);
GO

CREATE INDEX IX_Facturas_Paciente
ON dbo.Facturas(PacienteID, FechaFactura);
GO

CREATE INDEX IX_Facturas_Estado
ON dbo.Facturas(Estado, Saldo);
GO

CREATE INDEX IX_Pagos_Factura
ON dbo.Pagos(FacturaID, FechaPago);
GO

CREATE INDEX IX_Auditoria_Fecha
ON dbo.Auditoria(FechaHora);
GO

CREATE INDEX IX_Auditoria_Usuario
ON dbo.Auditoria(UsuarioID, FechaHora);
GO