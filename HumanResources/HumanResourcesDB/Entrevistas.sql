CREATE TABLE [dbo].[Entrevistas]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [CandidatoId] INT NOT NULL, 
    [DataHora] DATETIME NOT NULL, 
    [EscalaAvaliacaoId] INT NULL, 
    [Descricao] NVARCHAR(200) NULL, 
    CONSTRAINT [FK_Entrevistas_EscalaAvaliacao] FOREIGN KEY ([EscalaAvaliacaoId]) REFERENCES [EscalaAvaliacao]([Id])
)
