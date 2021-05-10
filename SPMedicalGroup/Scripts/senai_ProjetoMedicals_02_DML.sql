-- Scripts DML
 
USE ProjetoMedicals;
GO

-- Inserção de Valores Nas Tabelas

INSERT INTO TipoUsuario (NomeTipoUsuario)
VALUES					('Administrador'),
						('Medico'),
						('Paciente');
Go

-- Fazendo registros na tabela Usuario
INSERT INTO Usuario (IdTipoUsuario, NomeUsuario, Email, Senha)
VALUES				(2, 'GustavoL', 'Gustavo@gmail.com', 'Gustavo1.'),
					(1, 'VitorDev', 'Vitor.adm@gmail.com', 'Vitor123.'),
					(2, 'Mariana21', 'Mariana1@gmail.com', 'Mariana18'),
					(2, 'Amanda24', 'Amanda18@gmail.com', 'Amanda123.'),
					(3, 'AndressaS2', 'Andressa@gmail.com', 'Andreassa21..'),
					(3, 'Winicius13', 'WiniciusM@gmail.com', 'Wini2013'),
					(3, 'Patricia2021', 'Patricia@gmail.com', 'Patricia9659'),
					(3, 'Jessica967', 'Jessica213@gmail.com', 'Jessi58097457'),
					(2, 'Lucas645', 'Lucas5@gmail.com', 'Lucas46895.21');
GO


-- Fazendo registros na tabela Especialidade
INSERT INTO Especialidade (Especialidade)
VALUES					  (	'Acupuntura'),
						  ('Anestesiologia'),
						  ('Angiologia'),
						  ('Cardiologia'),
						  ('Cirurgia Cardiovascular' ),
						  ('Cirurgia Da Mão'),
						  ('Cirurgia Do Aparelho Digestivo'),
						  ('Cirurgia Geral'),
						  ('Cirurgia Pediátrica' ),
						  ('Cirurgia Plástica '),
						  ('Cirurgia Torácica' ),
						  ('Cirurgia Vascular'),
						  ('Demartologia'),
						  ('RadioTerapia'),
						  ('Urologia'),
						  ('Pediatra'),
						  ('Psiquiatra ');
GO

-- Fazendo registro na tabela Clinica
INSERT INTO Clinica (NomeFantasia, Endereco, RazaoSocial, CNPJ)
VALUES				('Medical Group', 'Av. Luis Gomes Bandeiras 234, São Paulo - SP', 'Clinica Vitor', '34675658755612');
GO

-- Fazendo registros na tabela Medico
INSERT INTO Medico (IdUsuario, IdEspecialidade, IdClinica, CRM)
VALUES			   (2, 4, 2, '45362 - SP'),
				   (3, 8, 2, '63465 - SP'),
				   (8, 16, 2, '97624 - SP'),
				   (9, 17, 2, '89437 - SP' );
GO

-- Fazendo registros na tabela Paciente
INSERT INTO Paciente (IdUsuario, Nome, RG, CPF, Endereco, DataNascimento, Telefone)
VALUES				  (4, 'Andressa Silva', '5095488891', '57565633224', 'Rua Baltzar Barroso, 20 - Guaianazes, São Paulo - SP - 99654-346', '20/02/2000', '11 20655312'),
					  (5, 'Winicius Manoel', '6787984351', '54642131689', 'Av. Paulista, 654 - Bela Vista , São Paulo - SP - 95679-921', '06/05/1997', '11 85639612'),
					  (6, 'Patricia Santos', '1294823011', '89890328443', 'Rua Luis Gomes, 344 - Jardim Moreno, São Paulo - SP - 12354-023', '12/12/1998', '11 95644535'),
					  (7, 'Jessica Souza', '8940207601', '86940345265', 'Av. Bandeira Gomes, 543 - Jardim Das Bandeiras, São Paulo - SP - 89545-981', '24/11/2001', '11 43894534');
GO

-- Fazendo registros na tabela Situacao
INSERT INTO Situacao (Situacao)
VALUES				 ('Realizada'),
					 ('Agendada'),
					 ('Cancelada');
GO

-- Fazendo registros na tabela Consulta
INSERT INTO Consulta (IdPaciente, IdMedico, Idsituacao, DataConsulta, Descricao)
VALUES				 (1, 8, 1, '12/11/2019', 'Doença arterial periférica'),
					 (2, 8, 1, '23/12/2019', 'Cardiopatia congênita'),
					 (3, 10, 1, '28/12/2019', 'Caxumba'),
					 (4, 10, 3, '01/04/2020', 'Infecções no ouvido e na garganta'),
					 (2, 10, 3, '16/05/2020', 'Catapora'),
					 (4, 11, 2, '28/05/2020', 'Transtorno bipolar'),
					 (1, 11, 2, '12/11/2020', 'Transtornos de Ansiedade');
GO