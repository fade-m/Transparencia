create database db_transparencia;

use db_transparencia;


Create table [usuario] (
	[usuario] Varchar(50) NOT NULL,
	[idTipoUsuario] Integer NOT NULL,
	[contrasena] Varchar(15) NOT NULL,
	[idUsuario] Integer Identity NOT NULL,
	[email] Varchar(25) NOT NULL,
	[idPersona] Integer NOT NULL,
Primary Key  ([idUsuario])
) 
go

Create table [persona] (
	[idPersona] Integer Identity NOT NULL,
	[nombre] Varchar(30) NOT NULL,
	[apPaterno] Varchar(20) NOT NULL,
	[apMaterno] Varchar(20) NOT NULL,
	[direccion] Varchar(70) NOT NULL,
	[fechaNacimiento] Datetime NOT NULL,
	[cp] Varchar(15) NOT NULL,
	[genero] Varchar(15) NOT NULL,
	[idEstado] Integer NOT NULL,
Primary Key  ([idPersona])
) 
go

Create table [tipoUsuario] (
	[idTipoUsuario] Integer Identity NOT NULL,
	[tipo] Varchar(25) NOT NULL,
	[descripcion] Varchar(100) NULL,
Primary Key  ([idTipoUsuario])
) 
go

Create table [estado] (
	[idEstado] Integer Identity NOT NULL,
	[nombre] Varchar(50) NOT NULL,
	[poblacion] Integer NOT NULL,
Primary Key  ([idEstado])
) 
go

Create table [partidoPolitico] (
	[idPartido] Integer Identity NOT NULL,
	[nombre] Varchar(50) NOT NULL,
Primary Key  ([idPartido])
) 
go

Create table [candidato] (
	[idCandidato] Integer Identity NOT NULL,
	[idPartido] Integer NOT NULL,
	[idUsuario] Integer NOT NULL,
	[idTipoCandidato] Integer NOT NULL,
	[idPresupuesto] Integer NOT NULL,
Primary Key  ([idCandidato])
) 
go

Create table [tipoCandidato] (
	[idTipoCandidato] Integer Identity NOT NULL,
	[tipoCandidato] Varchar(30) NOT NULL,
Primary Key  ([idTipoCandidato])
) 
go

Create table [presupuesto] (
	[idPresupuesto] Integer Identity NOT NULL,
	[prepTotal] Float NOT NULL,
	[idEstado] Integer NOT NULL,
Primary Key  ([idPresupuesto])
) 
go

Create table [programasIngreso] (
	[idProgramaIngreso] Integer Identity NOT NULL,
	[presupuesto] Float NOT NULL,
	[idPresupuesto] Integer NOT NULL,
Primary Key  ([idProgramaIngreso])
) 
go

Create table [egreso] (
	[idEgreso] Integer Identity NOT NULL,
	[idPresupuesto] Integer NOT NULL,
	[idArchivo] Integer NOT NULL,
	[cantidad] Float NOT NULL,
	[descripcion] Varchar(500) NULL,
	[votosPositivos] Integer NULL,
	[votosNegativos] Integer NULL,
	[latitud] Varchar(100) NULL,
	[longitud] Varchar(100) NULL,
Primary Key  ([idEgreso])
) 
go

Create table [archivo] (
	[idArchivo] Integer Identity NOT NULL,
	[ruta] Varchar(200) NOT NULL,
Primary Key  ([idArchivo])
) 
go

Create table [propuestas] (
	[idPropuesta] Integer Identity NOT NULL,
	[descripcion] Varchar(300) NULL,
	[idTipoPropuesta] Integer NOT NULL,
	[idCandidato] Integer NOT NULL,
	[idArchivo] Integer NOT NULL,
Primary Key  ([idPropuesta])
) 
go

Create table [tipoPropuesta] (
	[idTipoPropuesta] Integer Identity NOT NULL,
	[tipoPropuesta] Varchar(50) NOT NULL,
Primary Key  ([idTipoPropuesta])
) 
go

Create table [pregunta] (
	[idPregunta] Integer Identity NOT NULL,
	[idCandidato] Integer NOT NULL,
	[nombre] Varchar(30) NOT NULL,
	[pregunta] Varchar(200) NOT NULL,
	[votosPositivos] Integer NULL,
	[votosNegativos] Integer NULL,
	[respuesta] Varchar(250) NOT NULL,
Primary Key  ([idPregunta])
) 
go


Alter table [candidato] add  foreign key([idUsuario]) references [usuario] ([idUsuario]) 
go
Alter table [usuario] add  foreign key([idPersona]) references [persona] ([idPersona]) 
go
Alter table [usuario] add  foreign key([idTipoUsuario]) references [tipoUsuario] ([idTipoUsuario]) 
go
Alter table [persona] add  foreign key([idEstado]) references [estado] ([idEstado]) 
go
Alter table [presupuesto] add  foreign key([idEstado]) references [estado] ([idEstado]) 
go
Alter table [candidato] add  foreign key([idPartido]) references [partidoPolitico] ([idPartido]) 
go
Alter table [pregunta] add  foreign key([idCandidato]) references [candidato] ([idCandidato]) 
go
Alter table [propuestas] add  foreign key([idCandidato]) references [candidato] ([idCandidato]) 
go
Alter table [candidato] add  foreign key([idTipoCandidato]) references [tipoCandidato] ([idTipoCandidato]) 
go
Alter table [candidato] add  foreign key([idPresupuesto]) references [presupuesto] ([idPresupuesto]) 
go
Alter table [programasIngreso] add  foreign key([idPresupuesto]) references [presupuesto] ([idPresupuesto]) 
go
Alter table [egreso] add  foreign key([idPresupuesto]) references [presupuesto] ([idPresupuesto]) 
go
Alter table [egreso] add  foreign key([idArchivo]) references [archivo] ([idArchivo]) 
go
Alter table [propuestas] add  foreign key([idArchivo]) references [archivo] ([idArchivo]) 
go
Alter table [propuestas] add  foreign key([idTipoPropuesta]) references [tipoPropuesta] ([idTipoPropuesta]) 
go