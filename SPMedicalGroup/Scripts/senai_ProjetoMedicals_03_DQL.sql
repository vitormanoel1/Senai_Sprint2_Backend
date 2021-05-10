-- Scripts DQL

USE ProjetoMedicals;

-- Script para visualizar as tabelas criadas
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Especialidade;
SELECT * FROM Clinica;
SELECT * FROM Medico;
SELECT * FROM Paciente;
SELECT * FROM Situacao;
SELECT * FROM Consulta;

-- O administrador pode cadastrar qualquer tipo de usuário (administrador, paciente ou médico)
SELECT IdUsuario, NomeTipoUsuario, Email 
FROM Usuario
INNER JOIN TipoUsuario
ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario;

-- O administrador poderá agendar uma consulta, com as seguintes informações quem é o paciente,
-- data do agendamento e qual médico vai atender a consulta. o médico possui uma determinada especialidade
SELECT idConsulta, Nome, dataConsulta, CRM
FROM Consulta 
INNER JOIN Medico
ON Medico.IdMedico = Consulta.IdConsulta
INNER JOIN Paciente
ON Paciente.IdPaciente = Consulta.IdPaciente; 

-- O administrador poderá cancelar o agendamento das consultas
SELECT NomeTipoUsuario[Situacao], Email 
FROM Usuario
INNER JOIN TipoUsuario
ON Usuario.IdTipoUsuario = tipoUsuario.IdTipoUsuario
where Email = 'Vitor.adm@gmail.com';

-- O administrador tem que informar os dados da clínica (endereço, CNPJ, nome fantasia e razão social)
SELECT IdClinica, Endereco, CNPJ, NomeFantasia, RazaoSocial 
FROM clinica;

-- O médico poderá ver os agendamentos consultas associadas a ele
SELECT CRM, Nome, DataConsulta, Descricao 
FROM Consulta 
INNER JOIN  Medico
ON Medico.IdMedico = Consulta.IdMedico
INNER JOIN Paciente
ON Paciente.idPaciente = Consulta.IdMedico
WHERE Medico.IdMedico = 3;

-- O médico poderá incluir a descrição da consulta que estará vinculada ao paciente
SELECT Nome,Descricao 
FROM Paciente 
LEFT JOIN Consulta
ON Consulta.IdConsulta = Paciente.IdPaciente;


-- O paciente poderá visualizar suas próprias consultas
SELECT Nome, DataConsulta, CRM, Descricao 
FROM Paciente
INNER JOIN Consulta 
ON Consulta.IdConsulta = Paciente.IdPaciente
INNER JOIN Medico 
ON Medico.IdMedico = Paciente.IdPaciente;