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
VALUES            (1, 'Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '15/05/2012', 99.00),
                  (2, 'Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western', '26/10/2018', 120.00)
GO
