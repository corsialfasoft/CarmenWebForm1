CREATE PROCEDURE SP_CercaProdottoPerDescr
	@Descr nvarchar(50)
AS
SELECT * FROM ProdottiSet
WHERE descrizione like '%' + @Descr + '%'
GO