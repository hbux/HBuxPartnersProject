CREATE PROCEDURE [dbo].[spPhoto_GetByProductId]
	@productId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name], [Type], [ProductId]
	FROM dbo.Photo
	WHERE dbo.Photo.ProductId = @productId
END