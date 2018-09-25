CREATE PROCEDURE [dbo].[CreateEntrevista]
	@CandidatoId  INT,
    @DataHora     DATETIME
AS
	INSERT INTO Entrevistas
	(CandidatoId, DataHora)
	VALUES
	(@CandidatoId, @DataHora)

RETURN 0
