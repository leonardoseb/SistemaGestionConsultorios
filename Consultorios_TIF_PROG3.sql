-- ELIMINACION DE DATABASE 

use master
drop database BDConsultorios_ProgV2

-- CREACION DE LA BASE DE DATOS 


CREATE DATABASE BDConsultorios_ProgV2
GO


USE BDConsultorios_ProgV2
GO

-- CREACION DE LAS TABLAS



CREATE TABLE Especialidades
(
CodEspecialidad_Esp char(5) NOT NULL,
Descripcion_Esp varchar(25) NOT NULL,
Orientacion_Esp varchar(25) NOT NULL,
Estado_Esp bit DEFAULT (1) NOT NULL

CONSTRAINT PK_Especialidades PRIMARY KEY (CodEspecialidad_Esp)
)
GO


CREATE TABLE Consultorios
(
NumConsultorio_Con char(5) NOT NULL,
CodEspec_Con char(5) NOT NULL,
Estado_Con bit DEFAULT (1) NOT NULL

CONSTRAINT PK_Consultorios PRIMARY KEY (NumConsultorio_Con),
CONSTRAINT FK_Consultorios_Especialidades FOREIGN KEY (CodEspec_Con)
	REFERENCES Especialidades (CodEspecialidad_Esp)
)
GO


CREATE TABLE Pacientes
(
CodPaciente_Pac INT IDENTITY(1,1) NOT NULL,
DNI_Pac char(8) NOT NULL,
Nombre_Pac varchar(15) NOT NULL,
Apellido_Pac varchar(15) NOT NULL,
ObraSocial_Pac varchar(15) NULL,
Direccion_Pac varchar(25) NULL,
Telefono_Pac char(8) NOT NULL,
Email_Pac varchar(25) NOT NULL,
Estado_Pac bit DEFAULT (1) NOT NULL

CONSTRAINT PK_Pacientes PRIMARY KEY (CodPaciente_Pac)
)
GO


CREATE TABLE Profesionales
(
Matricula_Pr char(5) NOT NULL,  
DNI_Pr char(8) NOT NULL,
Nombre_Pr varchar(15) NOT NULL,
Apellido_Pr varchar(15) NOT NULL,
Email_Pr varchar(25) NULL,
Telefono_Pr char(8) NOT NULL,
Estado_Pr bit DEFAULT (1) NOT NULL

CONSTRAINT PK_Profesionales PRIMARY KEY (Matricula_Pr)
)
GO


CREATE TABLE ProfesionalesXEspecialidades
(
Matricula_PxE char(5) NOT NULL,
CodEspecialidad_PxE char(5) NOT NULL,
Estado_PxE bit DEFAULT (1) NOT NULL

CONSTRAINT PK_ProfesionalesXEspecialidades PRIMARY KEY (Matricula_PxE, CodEspecialidad_PxE),

CONSTRAINT FK_ProfesionalesXEspecialidades_Profesionales FOREIGN KEY (Matricula_PxE)
	REFERENCES Profesionales (Matricula_Pr),
CONSTRAINT FK_ProfesionalesXEspecialidades_Especialidades FOREIGN KEY (CodEspecialidad_PxE)
	REFERENCES Especialidades (CodEspecialidad_Esp)
)
GO


CREATE TABLE Turnos
(
Nro_Turno int NOT NULL IDENTITY(1,1), 
Matricula_Tur char(5) NOT NULL,            
CodEspecialidad_Tur char(5) NOT NULL,
NumConsultorio_Tur char(5) NOT NULL,
CodPaciente_Tur INT NOT NULL,
Fecha_Tur DATE NOT NULL,
Estado_Tur bit DEFAULT (1) NOT NULL

CONSTRAINT PK_Turnos PRIMARY KEY (Nro_Turno),

CONSTRAINT FK_Turnos_ProfesionalesXEspecialidades FOREIGN KEY (Matricula_Tur, CodEspecialidad_Tur)
	REFERENCES ProfesionalesXEspecialidades (Matricula_PxE, CodEspecialidad_PxE),	

CONSTRAINT FK_Turnos_Consultorios FOREIGN KEY (NumConsultorio_Tur)
	REFERENCES Consultorios (NumConsultorio_Con),
CONSTRAINT FK_Turnos_Pacientes FOREIGN KEY (CodPaciente_Tur)
	REFERENCES Pacientes (CodPaciente_Pac)
)
GO


CREATE TABLE HistoriasClinicas
(
Legajo_HC INT NOT NULL IDENTITY (1,1), 
CodPaciente_HC INT NOT NULL UNIQUE,
Estado_HC bit DEFAULT (1) NOT NULL


CONSTRAINT PK_HistoriasClinicas PRIMARY KEY (Legajo_HC),

CONSTRAINT FK_HistoriasClinicas_Pacientes FOREIGN KEY (CodPaciente_HC)
	REFERENCES Pacientes (CodPaciente_Pac)
)
GO



CREATE TABLE DetalleHistoriasClinicas
(
Nro_Detalle_DHC INT NOT NULL IDENTITY(1,1),
Legajo_DHC INT NOT NULL,              
Matricula_DHC char(5) NOT NULL,		
CodEspecialidad_DHC char(5) NOT NULL,
MotivoConsulta_DHC varchar(50) NOT NULL,
Diagnostico_DHC varchar(50) NULL,
FechaConsulta_DHC smalldatetime NOT NULL,
Estado_DHC bit DEFAULT (1) NOT NULL

CONSTRAINT PK_DetalleHistoriasClinicas PRIMARY KEY (Nro_Detalle_DHC),

CONSTRAINT FK_DetalleHistoriasClinicas_HistoriasClinicas FOREIGN KEY (Legajo_DHC)
	REFERENCES HistoriasClinicas (Legajo_HC),

CONSTRAINT FK_DetalleHistoriasClinicas_ProfesionalesXEspecialidades FOREIGN KEY (Matricula_DHC, CodEspecialidad_DHC)
	REFERENCES ProfesionalesXEspecialidades (Matricula_PxE, CodEspecialidad_PxE)
)
GO

SELECT COUNT(*) 
FROM Turnos 
WHERE(Fecha_Tur >= CAST('14/12/2022' AS datetime)) 
AND (Fecha_Tur <= CAST('23/12/2022' AS datetime)) 
AND (Estado_Tur = 0)


----------- CARGA DE DATOS --------------------


INSERT INTO Especialidades (CodEspecialidad_Esp , Descripcion_Esp, Orientacion_Esp )
SELECT 'ESP01','Pediatria','bebes, niños y adolesc.' union
SELECT 'ESP02','Neurologia','sistema nervioso' union
SELECT 'ESP03','Cardiologia','sistema circulatorio' union
SELECT 'ESP04','Neumologia','aparato respiratorio' union
SELECT 'ESP05','Oncologia','cancer, quimioterapia' union
SELECT 'ESP06','Cirugia','operaciones' union
SELECT 'ESP07','Cirugia Pediatrica','operaciones niños y jov.' union
SELECT 'ESP08','Cirugia Plastica','correccion anormalidades' union
SELECT 'ESP09','Clinica Medica','consultas ambulatorias' union
SELECT 'ESP10','Dermatologia','estructura de la piel' union
SELECT 'ESP11','Endocrinologia','sistema endocrino' union
SELECT 'ESP12','Fisiatria','fisica y rehabilitacion' union
SELECT 'ESP13','Ginecologia','aparato genital femenino' union
SELECT 'ESP14','Hematologia','enfermedades de la sangre' union
SELECT 'ESP15','Infectologia','agentes infecciosos' 
GO


INSERT INTO Consultorios (NumConsultorio_Con , CodEspec_Con)
SELECT '1','ESP01' union
SELECT '2','ESP02' union
SELECT '3','ESP03' union
SELECT '4','ESP04' union
SELECT '5','ESP05' union
SELECT '6','ESP06' union
SELECT '7','ESP07' union
SELECT '8','ESP08' union
SELECT '9','ESP09' union
SELECT '10','ESP10' union
SELECT '11','ESP11' union
SELECT '12','ESP12' union
SELECT '13','ESP13' union
SELECT '14','ESP14' union
SELECT '15','ESP15' 
GO


INSERT INTO Pacientes (DNI_Pac , Nombre_Pac , Apellido_Pac, ObraSocial_Pac, Direccion_Pac ,Telefono_Pac ,Email_Pac  )
SELECT '1122333','Carlos','Gonzalez','OSDE','Av. Peron 123','1122344','carlos@gmail.com' union
SELECT '33444555','Maria','Garcia','GALENO','Av. Pueyrredon 321','11213935','mariarosa@gmail.com'  union
SELECT '66777888','Francisco','Segundo','MEDICUS','Calle Ortiz 555','11455122','fran@gmail.com' union
SELECT '99111222', 'Morena', 'Lopez', 'AVALIAN', 'Calle Belgrano 23', '11253943', 'morenal@gmail.com' union
SELECT '33333555', 'Matias', 'Gomez', 'OMINT', 'Av. Balbin 5512', '1155923', 'matiasg@gmail.com' union
SELECT '22111333', 'Marcos', 'Suarez', 'OSDE', 'Acassuso 45','1123472', 'marcoss@gmail.com' union
SELECT '11333222', 'Rosa', 'Montero', 'MEDICUS', 'Aconcagua 324', '11284234', 'rosam@gmail.com' union
SELECT '11444555', 'Miriam', 'Fernandez','AVALIAN', 'Achega 334', '11898345', 'miriamf@gmail.com' union 
SELECT '11555444', 'Sabrina', 'Hernandez', 'OSDE', 'Callao 89', '11435564', 'sabrinah@gmail.com' union
SELECT '33555444', 'Lionel', 'Messi', 'GALENO', 'Caseros 789', '11678362', 'lionelm@gmail.com' union
SELECT '22333111', 'Fernanda', 'Jackson', 'GALENO', 'Cespedes 1009', '11442487', 'fernandaj@gmail.com' union
SELECT '22444333', 'Mauricio', 'Suarez', 'MEDICUS', 'Olivera 2933', '11990923', 'mauricios@gmail.com' union
SELECT '22555111', 'Ivan', 'Rojas', 'OSDE', 'Quintana 900', '11238753', 'ivanr@gmail.com' union
SELECT '22666111', 'Roxana', 'Arena', 'OMINT', 'Comodoro 999', '11822934', 'roxanaa@gmail.com' union
SELECT '33555888', 'Fabian', 'Olivera', 'AVALIAN', 'Uruguay 1192','1134323', 'fabiano@gmail.com'
GO


INSERT INTO Profesionales(Matricula_Pr , DNI_Pr , Nombre_Pr , Apellido_Pr, Email_Pr , Telefono_Pr  )
SELECT '11111','30123456','Lucas','Hernandez','lucasg@gmail.com','11233344' union
SELECT '22222','40654987','Barbara','Olivera','barby@hotmail.com','11532453' union
SELECT '33333','25132456','Francisco','Gomez','francisco@gmail.com','11423456' union
SELECT '44444','23444555','Franco','Gutierrez','franco@hotmail.com','11423452' union
SELECT '55555','16744234','Gisela','Ritondo','gisela@gmail.com','11423452' union
SELECT '66666','23899098','Paola','Olivera', 'paola@gmail.com', '11238927' union
SELECT '77777','33456321','Pedro','Perez', 'pedro@gmail.com', '11892367' union
SELECT '88888','23444232','Alejandro','Saez', 'alejandro@gmail.com', '11223455' union
SELECT '99999','22255512','Jose','Jimenez','jose@gmail.com','11232222' union
SELECT '11112','20001233','Ramona','Navarro', 'ramona@gmail.com','11298777' union
SELECT '22221','45539595','Miguel','Gonzalez','miguel@gmail.com','11435532' union
SELECT '33331','31855583','Angela','Moreno','angela@gmail.com','11233323' union
SELECT '33332','21333929','Andres','Marin','andres@gmail.com','11099923' union
SELECT '44441','19023453','Emilia','Ortiz','emilia@gmail.com','11334534' union
SELECT '44442','10002345','Joaquin','Torres', 'joaquin@gmail.com', '11009334'
GO

INSERT INTO profesionalesxespecialidades (Matricula_PxE, CodEspecialidad_PxE)
SELECT '33333','ESP01' union
SELECT '33333','ESP05' union
SELECT '55555','ESP02' union
SELECT '55555','ESP03' union
SELECT '44444','ESP03' union
SELECT '44444','ESP05' union
SELECT '22222','ESP04' union
SELECT '22222','ESP01' union
SELECT '11111','ESP05' union 
SELECT '11111','ESP02' union
SELECT '44441','ESP10' union
SELECT '44442','ESP12' union
SELECT '33332','ESP11' union
SELECT '22221','ESP13' union
SELECT '11112','ESP14' 
GO

INSERT INTO HistoriasClinicas (CodPaciente_HC)
SELECT '1' union
SELECT '2' union
SELECT '3' union
SELECT '4' union
SELECT '5' union
SELECT '6' union
SELECT '7' union
SELECT '8' union
SELECT '9' union
SELECT '10' union
SELECT '11' union
SELECT '12' union
SELECT '13' union
SELECT '14' union
SELECT '15'
GO

INSERT INTO DetalleHistoriasClinicas (Legajo_DHC, Matricula_DHC, CodEspecialidad_DHC, MotivoConsulta_DHC, Diagnostico_DHC, FechaConsulta_DHC)
SELECT '1','11111','ESP05','Fiebre','Angina, se receto medicamento','2/1/2022' union
SELECT '2','11111','ESP02','Dolor de cabeza', 'lesion medula','2/11/2022' union
SELECT '3','44441','ESP10','erupcion cutanea','psoriasis','1/2/2022' union
SELECT '3','44441','ESP10','erupcion cutanea','psoriasis','3/11/2022' union
SELECT '2','55555','ESP03','Latidos irregulares', 'arritmia', '9/8/2022' union
SELECT '4','55555','ESP02','difultad resp.','trast. sist. nervioso','8/10/2022' union
SELECT '5','11112','ESP14','cansancio','trast. de la sangre','1/11/2022' union
SELECT '6','22221','ESP13','ardor genital','candidiasis','2/11/2022' union
SELECT '6','22221','ESP13','dolor abdominal','dismenorrea','4/11/2022' union
SELECT '7','44442','ESP12','dolor espalda','estres','3/9/2022' union
SELECT '8','44444','ESP05','bulto sospechoso','tumor benigno','2/8/2022' union
SELECT '9','44441','ESP10','picazon en rostro','sarpullido','9/4/2022' union
SELECT '10','22222','ESP04','difultad respiratoria','asma','5/7/2022' union
SELECT '11','33332','ESP11','bulto sospechoso','cancer de tiroides','5/5/2022' union
SELECT '3','44444','ESP03', 'presion alta','hipertension arterial','4/8/2022' union
SELECT '7','55555','ESP02', 'cuadro de gripe','dolor de cuerpo','22/12/2022' 
GO








-- LOGIN 

CREATE TABLE Usuarios
(
IdUsuario INT IDENTITY (1,1) NOT NULL,
NombreUsuario VARCHAR (30) NOT NULL,
Password VARCHAR (30) NOT NULL,
TipoUsuario VARCHAR (30) NOT NULL,
Estado_Usuario bit DEFAULT (1)

CONSTRAINT PK_Usuarios PRIMARY KEY (IdUsuario)
)
GO

INSERT INTO Usuarios (NombreUsuario, Password, TipoUsuario)
SELECT 'admin', '1234', 'Administrador' UNION
SELECT '11111','1234','Profesional' union
SELECT '22222','1234','Profesional' union
SELECT '33333','1234','Profesional' union
SELECT '44444','1234','Profesional' union
SELECT '55555','1234','Profesional'
GO




------------ PROCEDIMIENTOS ------------


CREATE PROCEDURE spAgregarPaciente
(
@DNI_PAC CHAR (8),
@NOMBRE_PAC VARCHAR (15),
@APELLIDO_PAC VARCHAR(15),
@OBRASOCIAL_PAC VARCHAR(15),
@DIRECCION_PAC VARCHAR(25),
@TELEFONO_PAC CHAR(8),
@EMAIL_PAC VARCHAR(25),
@ESTADO_PAC BIT 
)
AS
INSERT INTO Pacientes (DNI_Pac , Nombre_Pac , Apellido_Pac, ObraSocial_Pac, Direccion_Pac ,Telefono_Pac ,Email_Pac, Estado_Pac) VALUES (@DNI_PAC, @NOMBRE_PAC, @APELLIDO_PAC, @OBRASOCIAL_PAC, @DIRECCION_PAC, @TELEFONO_PAC, @EMAIL_PAC, 1)
RETURN 
GO


CREATE PROCEDURE spAgregarProfesional
(
@MATRICULA_PR CHAR (5),
@DNI_PR CHAR (8),
@NOMBRE_PR VARCHAR(15),
@APELLIDO_PR VARCHAR(15),
@EMAIL_PR VARCHAR(25),
@TELEFONO_PR CHAR(8),
@ESTADO_PR BIT 
)
AS
INSERT INTO Profesionales (Matricula_Pr , DNI_Pr , Nombre_Pr, Apellido_Pr, Email_Pr, Telefono_Pr, Estado_Pr) VALUES (@MATRICULA_PR, @DNI_PR, @NOMBRE_PR, @APELLIDO_PR, @EMAIL_PR, @TELEFONO_PR, 1)
RETURN
GO


CREATE PROCEDURE spAgregarProfesionalXEspecialidad
(
@MATRICULA_PXE CHAR (5),
@CODESPECIALIDAD_PXE CHAR (5)
)
AS
INSERT INTO ProfesionalesXEspecialidades (Matricula_PxE, CodEspecialidad_PxE) VALUES (@MATRICULA_PXE , @CODESPECIALIDAD_PXE)
RETURN
GO

CREATE PROCEDURE spAgregarTurno
(
@MATRICULA_TUR CHAR (5),
@CODESPECIALIDAD_TUR CHAR (5),
@NUMCONSULTORIO_TUR CHAR (5),
@CODPACIENTE_TUR INT,
@FECHA_TUR DATE,
@ESTADO_TUR BIT
)
AS
INSERT INTO Turnos (Matricula_Tur, CodEspecialidad_Tur, NumConsultorio_Tur, CodPaciente_Tur, Fecha_Tur, Estado_Tur) VALUES (@MATRICULA_TUR, @CODESPECIALIDAD_TUR, @NUMCONSULTORIO_TUR, @CODPACIENTE_TUR, @FECHA_TUR , @ESTADO_TUR)
RETURN
GO


CREATE PROCEDURE spActualizarPaciente
(
@DNI_PAC CHAR(8),
@NOMBRE_PAC VARCHAR(15),
@APELLIDO_PAC VARCHAR(15),
@OBRASOCIAL_PAC VARCHAR(15),
@DIRECCION_PAC VARCHAR(25),
@TELEFONO_PAC CHAR(8),
@EMAIL_PAC VARCHAR(25),
@ESTADO_PAC BIT
)
AS
UPDATE Pacientes
SET
DNI_Pac = @DNI_PAC,
Nombre_Pac = @NOMBRE_PAC,
Apellido_Pac = @APELLIDO_PAC,
ObraSocial_Pac = @OBRASOCIAL_PAC,
Direccion_Pac = @DIRECCION_PAC,
Telefono_Pac = @TELEFONO_PAC,
Email_Pac = @EMAIL_PAC,
Estado_Pac = @ESTADO_PAC
WHERE DNI_Pac = @DNI_PAC
RETURN
GO


CREATE PROCEDURE spEliminarPaciente
(
@DNI_PAC char(8)
)
AS 
IF EXISTS (SELECT * FROM Pacientes WHERE DNI_Pac = @DNI_PAC)
BEGIN
UPDATE Pacientes SET Estado_Pac = 0 WHERE DNI_Pac = @DNI_PAC
END
RETURN
GO


CREATE PROCEDURE spActualizarProfesional
(
@MATRICULA_PR CHAR (5),
@DNI_PR CHAR (8),
@NOMBRE_PR VARCHAR(15),
@APELLIDO_PR VARCHAR(15),
@EMAIL_PR VARCHAR(25),
@TELEFONO_PR CHAR(8),
@ESTADO_PR BIT
)
AS
UPDATE Profesionales
SET
DNI_Pr = @DNI_PR,
Nombre_Pr = @NOMBRE_PR,
Apellido_Pr = @APELLIDO_PR,
Email_Pr = @EMAIL_PR,
Telefono_Pr = @TELEFONO_PR,
Estado_Pr = @ESTADO_PR
WHERE Matricula_Pr = @MATRICULA_PR
RETURN
GO

CREATE PROCEDURE spEliminarProfesional
(
@MATRICULA_PR CHAR(5)
)
AS
IF EXISTS (SELECT * FROM Profesionales WHERE Matricula_Pr = @MATRICULA_PR)
BEGIN
UPDATE Profesionales SET Estado_Pr = 0 WHERE Matricula_Pr = @MATRICULA_PR
END
RETURN 
GO

CREATE PROCEDURE spEliminarTurno
(
@NRO_TURNO int
)
AS
IF EXISTS (SELECT * FROM Turnos WHERE Nro_Turno = @NRO_TURNO)
BEGIN
UPDATE Turnos SET Estado_Tur = 0 WHERE Nro_Turno = @NRO_TURNO
END
RETURN 
GO

-- procedimientos cargar historia clinica y detalle historia clinica


CREATE PROCEDURE spAgregarHistoriaClinica
(
@CodPaciente_HC int
)
AS 
INSERT INTO HistoriasClinicas(CodPaciente_HC) VALUES (@CodPaciente_HC)
RETURN
GO


CREATE PROCEDURE spAgregarHistoriaClinica_Detalle
(
@Legajo_DHC int,
@Matricula_DHC char(5),
@CodEspecialidad_DHC char(5),
@MotivoConsulta_DHC varchar(50),
@Diagnostico_DHC varchar(50),
@FechaConsulta_DHC DATE
)
AS
INSERT INTO DetalleHistoriasClinicas (Legajo_DHC, Matricula_DHC,CodEspecialidad_DHC, MotivoConsulta_DHC,Diagnostico_DHC,FechaConsulta_DHC) VALUES (@Legajo_DHC, @Matricula_DHC, @CodEspecialidad_DHC, @MotivoConsulta_DHC, @Diagnostico_DHC, @FechaConsulta_DHC)
RETURN 
GO

-- consultas


SELECT * FROM Consultorios
SELECT * FROM Profesionales
SELECT * FROM Turnos
SELECT * FROM Especialidades
SELECT * FROM HistoriasClinicas
SELECT * FROM DetalleHistoriasClinicas
SELECT * FROM ProfesionalesXEspecialidades
SELECT * FROM Especialidades
SELECT * FROM Usuarios