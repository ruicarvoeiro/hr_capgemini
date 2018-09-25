CREATE PROCEDURE [dbo].[GetEscalaAvaliacao]
	
AS
	SELECT Id,
		   Descricao,
		   Nota
	FROM EscalaAvaliacao
RETURN 0
