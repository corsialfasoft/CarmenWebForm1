USE [RICHIESTE]
GO

/****** Oggetto: SqlProcedure [dbo].[SP_CercaProdottoPerDescr] Data script: 18/04/2018 16:52:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_CercaProdottoPerCodice
	@Codice int
AS
SELECT * FROM ProdottiSet
WHERE id=@Codice