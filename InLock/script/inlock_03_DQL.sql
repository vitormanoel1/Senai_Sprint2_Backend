USE Inlock_Games_Tarde
GO

SELECT * FROM TipoUsuarios
GO

SELECT * FROM Estudios
GO

SELECT * FROM Jogos
GO

--Listar todos os jogos e seus respectivos est�dios;
SELECT NomeJogo, NomeEstudio FROM Jogos 
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio 
GO

--Buscar e trazer na lista todos os est�dios com os respectivos jogos.
SELECT Estudios.NomeEstudio, NomeJogo FROM Estudios
LEFT JOIN Jogos
ON Estudios.IdEstudio = Jogos.IdEstudio
GO

--Buscar um usu�rio por e-mail e senha (login);
SELECT IdUsuario, Email, Senha FROM Usuario
WHERE Email = 'admin@admin.com' and Senha = 'admin'
GO

--Buscar um jogo por idJogo;
SELECT IdJogo, NomeJogo FROM Jogos
WHERE IdJogo = 1
GO

--Buscar um est�dio por idEstudio;
SELECT IdEstudio, NomeEstudio FROM Estudios
WHERE IdEstudio = 3
GO
