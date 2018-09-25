/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

Delete Entrevistas
delete Candidato
delete TipoEscolaridade
delete EscalaAvaliacao


INSERT INTO TipoEscolaridade
(Descricao)
VALUES
('12º Ano'),
('Curso Profissional'),
('Licenciatura'),
('Mestrado'),
('Doutorado')

INSERT INTO EscalaAvaliacao
(Descricao, Nota)
VALUES
('A',5),
('B',4),
('C',3),
('D',2),
('E',1)

INSERT INTO Candidato
(Nome, Nif, DataNasc, TipoEscolaridadeId)
SELECT 'João António', 123124556, '1982-03-04', (SELECT Id FROM TipoEscolaridade WHERE DESCRICAO = '12º Ano')
UNION
SELECT 'Maria Santo', 128579556, '1990-06-12', (SELECT Id FROM TipoEscolaridade WHERE DESCRICAO = 'Licenciatura')
UNION
SELECT 'Marta Soares', 208137101, '1994-12-04', (SELECT Id FROM TipoEscolaridade WHERE DESCRICAO = 'Licenciatura')
UNION
SELECT 'João António', 908131232, '1986-01-20', (SELECT Id FROM TipoEscolaridade WHERE DESCRICAO = 'Doutorado')


INSERT INTO Entrevistas
(CandidatoId, DataHora, EscalaAvaliacaoId)
SELECT (SELECT Id FROM Candidato WHERE NIF = '123124556'), '2018-07-03', (SELECT Id FROM EscalaAvaliacao WHERE Descricao = 'B')
UNION
SELECT (SELECT Id FROM Candidato WHERE NIF = '123124556'), '2018-08-03', (SELECT Id FROM EscalaAvaliacao WHERE Descricao = 'C')
UNION
SELECT (SELECT Id FROM Candidato WHERE NIF = '128579556'), '2018-07-04', (SELECT Id FROM EscalaAvaliacao WHERE Descricao = 'D')
UNION
SELECT (SELECT Id FROM Candidato WHERE NIF = '208137101'), '2018-07-10', (SELECT Id FROM EscalaAvaliacao WHERE Descricao = 'D')
UNION
SELECT (SELECT Id FROM Candidato WHERE NIF = '208137101'), '2018-07-20', null
GO
