CREATE PROCEDURE [dbo].[DeleteEntrevista]
	@EntrevistaId INT
AS
	DELETE Entrevistas 
	WHERE Id = @EntrevistaId
RETURN 0
