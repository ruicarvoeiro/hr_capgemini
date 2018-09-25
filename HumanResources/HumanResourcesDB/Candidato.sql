CREATE TABLE [dbo].[Candidato]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(50) NOT NULL, 
    [Nif] NVARCHAR(50) NOT NULL, 
    [DataNasc] DATE NOT NULL, 
    [TipoEscolaridadeId] INT NOT NULL, 
    CONSTRAINT [FK_Candidato_TipoEscolaridade] FOREIGN KEY ([TipoEscolaridadeId]) REFERENCES [TipoEscolaridade]([Id])
)


GO

CREATE UNIQUE INDEX [IX_Candidato_Nif] ON [dbo].[Candidato] ([Nif])
