CREATE PROCEDURE [dbo].[UpdateCandidato]
	@CandidatoId	INT,
	@Nome			NVARCHAR(50),	
	@Nif			NVARCHAR(9),
	@DataNasc		DATE,
	@TipoEscolaridadeId INT
AS
	UPDATE Candidato
	SET DataNasc = @DataNasc,
		Nif = @Nif,
		Nome = @Nome,
		TipoEscolaridadeId = @TipoEscolaridadeId
	WHERE Id = @CandidatoId

RETURN 0
