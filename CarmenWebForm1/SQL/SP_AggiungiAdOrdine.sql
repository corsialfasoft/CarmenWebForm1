CREATE PROCEDURE SP_AggiungiAdOrdine
	@IdProd int,
	@qta int,
	@IdOrdine int
AS
INSERT INTO RichiesteProdotti
(Richieste_Id, Prodotti_Id, quantita)
VALUES (@IdOrdine, @IdProd, @qta)
GO