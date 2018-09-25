CREATE PROCEDURE [dbo].[DeleteCandidato]
	@CandidatoId			INT
AS
	DELETE Candidato
	WHERE Id = @CandidatoId
RETURN 0
