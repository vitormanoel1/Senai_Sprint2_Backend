USE Inlock_Games_Tarde
GO

SELECT * FROM TipoUsuarios
GO

SELECT * FROM Estudios
GO

SELECT * FROM Jogos
GO

--Listar todos os jogos e seus respectivos estúdios;
SELECT NomeJogo, NomeEstudio FROM Jogos 
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio 
GO

--Buscar e trazer na lista todos os estúdios com os respectivos jogos.
SELECT Estudios.NomeEstudio, NomeJogo FROM Estudios
LEFT JOIN Jogos
ON Estudios.IdEstudio = Jogos.IdEstudio
GO

--Buscar um usuário por e-mail e senha (login);
SELECT IdUsuario, Email, Senha FROM Usuario
WHERE Email = 'admin@admin.com' and Senha = 'admin'
GO

--Buscar um jogo por idJogo;
SELECT IdJogo, NomeJogo FROM Jogos
WHERE IdJogo = 1
GO

--Buscar um estúdio por idEstudio;
SELECT IdEstudio, NomeEstudio FROM Estudios
WHERE IdEstudio = 3
GO
