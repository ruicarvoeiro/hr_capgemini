CREATE PROCEDURE [dbo].[GetCandidatos]
	@Nome nVarchar(50) = '',
	@Nif nVarchar(9) = ''
AS
	SELECT  [Candidato].Id,
			[Nome],
			[Nif],
			[DataNasc],
			[TipoEscolaridadeId],
			[Descricao]
	FROM Candidato
	INNER JOIN TipoEscolaridade ON Candidato.TipoEscolaridadeId = TipoEscolaridade.Id
	WHERE ((Candidato.Nome = @Nome AND @Nome <> '') OR @Nome = '')
	AND ((Candidato.Nif = @Nif AND @Nif <> '') OR @Nif = '')


RETURN 0
