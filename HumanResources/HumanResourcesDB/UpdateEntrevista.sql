CREATE PROCEDURE [dbo].[UpdateEntrevista]
	@EntrevistaId INT,
	@DataHora     DATETIME
AS
	UPDATE Entrevistas
	SET DataHora = @DataHora
	WHERE Id = @EntrevistaId
RETURN 0
