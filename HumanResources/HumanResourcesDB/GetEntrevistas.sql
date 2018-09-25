CREATE PROCEDURE [dbo].[GetEntrevistas]
	@CandidatoId int = 0
AS
	SELECT Entrevistas.Id,
			CandidatoId,
			Nome,
			Nif,
			DataHora,
			EscalaAvaliacaoId,
			EscalaAvaliacao.Descricao AS EscaDescricao,
			Nota,
			Entrevistas.Descricao AS EntDescricao
	FROM Entrevistas
	INNER JOIN Candidato ON Entrevistas.CandidatoId = Candidato.Id
	LEFT JOIN EscalaAvaliacao ON EscalaAvaliacao.Id = Entrevistas.EscalaAvaliacaoId
	WHERE ((Candidato.Id =  @CandidatoId AND @CandidatoId <> 0) OR @CandidatoId = 0)
RETURN 0