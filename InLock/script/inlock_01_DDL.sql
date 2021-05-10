CREATE DATABASE Inlock_Games_Tarde
GO 

USE Inlock_Games_Tarde
GO 

CREATE TABLE Estudios 
(
   IdEstudio    INT PRIMARY KEY IDENTITY, 
   NomeEstudio  VARCHAR(100) NOT NULL
)
GO

CREATE TABLE Jogos 
(
   IdJogo          INT PRIMARY KEY IDENTITY, 
   IdEstudio       INT FOREIGN KEY REFERENCES Estudios(IdEstudio),
   NomeJogo        VARCHAR(200) NOT NULL, 
   Descricao       VARCHAR(250) NOT NULL,
   DataLancamento  DATE NOT NULL, 
   Valor           SMALLMONEY NOT NULL
)
GO

CREATE TABLE TipoUsuarios 
(
  IdTipoUsuario  INT PRIMARY KEY IDENTITY, 
  Titulo         VARCHAR(200) NOT NULL
)
GO

CREATE TABLE Usuario 
(
  IdUsuario INT PRIMARY KEY IDENTITY,
  IdTipoUsuario int foreign key references TipoUsuarios(idTipoUsuario),
  Email     VARCHAR(100) unique NOT NULL, 
  Senha     VARCHAR(50) NOT NULL 
)
GO