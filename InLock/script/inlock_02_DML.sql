USE Inlock_Games_Tarde
GO 

INSERT INTO TipoUsuarios (Titulo)
VALUES                  ('administrador'),
                         ('cliente')
GO

INSERT INTO Usuario (IdTipoUsuario, Email, Senha)
VALUES              (1, 'admin@admin.com', 'admin'),
                    (2, 'cliente@cliente.com', 'cliente')
GO

INSERT INTO Estudios (NomeEstudio)
VALUES              ('Blizzard'),   
                     ('Rockstar Studios'),
					 ('Square Enix')
GO

INSERT INTO Jogos (IdEstudio, NomeJogo, Descricao, DataLancamento, Valor)
VALUES            (1, 'Diablo 3', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '15/05/2012', 99.00),
                  (2, 'Red Dead Redemption II', 'jogo eletrônico de ação-aventura western', '26/10/2018', 120.00)
GO
