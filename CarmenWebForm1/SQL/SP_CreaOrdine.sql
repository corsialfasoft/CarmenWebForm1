CREATE PROCEDURE SP_CreaOrdine
AS
INSERT INTO RichiesteSet
(Data)
VALUES (getdate());

DECLARE @idGiorno int SET @idGiorno = (SELECT IDENT_CURRENT ('RichiesteSet'))
GO