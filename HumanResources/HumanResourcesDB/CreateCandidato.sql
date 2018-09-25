CREATE PROCEDURE [dbo].[CreateCandidato]
	@Nome       NVARCHAR (50),
    @Nif        NVARCHAR (9),
    @DataNasc	DATE,
    @TipoEscolaridadeId INT
AS
	INSERT INTO Candidato
	(Nome, Nif, DataNasc, TipoEscolaridadeId)
	VALUES
	(@Nome, @Nif, @DataNasc, @TipoEscolaridadeId)

RETURN 0
