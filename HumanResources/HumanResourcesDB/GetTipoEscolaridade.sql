CREATE PROCEDURE [dbo].[GetTipoEscolaridade]

AS
	SELECT  Id,
			Descricao
	FROM TipoEscolaridade
RETURN 0
