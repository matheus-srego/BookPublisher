USE [editora]
GO

BEGIN TRANSACTION;

CREATE TABLE [dbo].[usuario]
(
	id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	nome NVARCHAR(100) NOT NULL,
	sobrenome NVARCHAR(100) NOT NULL,
	email NVARCHAR(50) UNIQUE NOT NULL,
	senha NVARCHAR(256) NOT NULL,
	tipo_usuario INT NOT NULL CHECK(tipo_usuario IN(0, 1))
);
GO

COMMIT TRANSACTION;
