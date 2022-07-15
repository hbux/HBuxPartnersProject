CREATE PROCEDURE [dbo].[spProduct_GetByProductId]
	@productId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [dbo].[Product].[Id], [dbo].[Product].[Name], [dbo].[Product].[Description], 
			[dbo].[Product].[RetailPrice], [dbo].[Product].[QuantityInStock], [dbo].[Product].[CreateDate], 
			[dbo].[Photo].[Id], [dbo].[Photo].[Name], [dbo].[Photo].[Type], [dbo].[Photo].[ProductId]
	FROM dbo.Product
	INNER JOIN dbo.Photo
	ON dbo.Photo.ProductId = dbo.Product.Id
	WHERE dbo.Product.Id = @productId
END