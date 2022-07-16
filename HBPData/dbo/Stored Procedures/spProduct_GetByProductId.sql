CREATE PROCEDURE [dbo].[spProduct_GetByProductId]
	@productId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Sku], [Name], [Description], [Weight], [RetailPrice], [QuantityInStock], 
			[CreateDate], [ModifiedDate]
	FROM dbo.Product
	WHERE dbo.Product.Id = @productId
END