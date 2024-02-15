create database DBPruebaPactia

use DBPruebaPactia

create table Tasks(
	IdTask uniqueidentifier NOT NULL,
	NameTask NVARCHAR(200) NOT NULL,
	StateTask NVARCHAR(12) NOT NULL
);

create table Users(
	IdUser uniqueidentifier NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	DocumentNumber NVARCHAR(15) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Password NVARCHAR(200) NOT NULL
);

-- Insertar usuario para generar el token de seguridad
insert into Users (IdUser, FullName, DocumentNumber, Email, Password) values (NEWID(), 'Juan Roncero', '123456', 'prueba@gmail.com', 'MQAyADMANAA1AA==')

--Ingresar con las creadenciales 
--User: prueba@gmail.com
--Password: 12345

-- Procedimiento almacenado para registros tareas 
CREATE PROCEDURE SP_CreateTask
(
@IdTask uniqueidentifier,
@NameTask NVARCHAR(200),
@StateTask NVARCHAR(12)
)
AS
INSERT INTO Tasks (IdTask, NameTask, StateTask) VALUES
(
@IdTask,
@NameTask,
@StateTask
);

-- Procedimiento almacenado para consultar todas las tareas 
CREATE PROCEDURE SP_GetAllTasks
AS
select IdTask, NameTask, StateTask from Tasks


-- Procedimiento almacenado para consultar tareas por Id 
CREATE PROCEDURE SP_GetByIdTask
(
@IdTask uniqueidentifier
)
AS
select IdTask, NameTask, StateTask from Tasks where IdTask = @IdTask

-- Procedimiento almacenado para actualizar tareas por Id 
CREATE PROCEDURE SP_UpdateTask
(
@IdTask uniqueidentifier,
@NameTask NVARCHAR(200),
@StateTask NVARCHAR(12)
)
AS
UPDATE Tasks SET NameTask = @NameTask, StateTask = @StateTask WHERE IdTask = @IdTask;

-- Procedimiento almacenado para Eliminar tareas por Id 
CREATE PROCEDURE SP_DeleteTaskById
(
@IdTask uniqueidentifier
)
AS
select IdTask, NameTask, StateTask from Tasks where IdTask = @IdTask

-- Procedimiento almacenado para consultar si la credenciales y el usuario es correcto
CREATE PROCEDURE SP_GetUserLogin
(
@Email varchar(50),
@Password varchar(100)
)
AS
SELECT top 1
idUser,
Email,
DocumentNumber,
Password,
FullName
FROM Users where Email = @Email AND Password = @Password