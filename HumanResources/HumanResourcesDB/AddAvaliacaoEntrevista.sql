CREATE PROCEDURE [dbo].[AddAvaliacaoEntrevista]
	@EntrevistaId INT,
	@EscalaAvaliacaoId INT,
	@Descricao NVARCHAR(200)
AS
	UPDATE Entrevistas
	SET EscalaAvaliacaoId = @EscalaAvaliacaoId,
		Descricao = @Descricao
	WHERE Id = @EntrevistaId
RETURN 0
