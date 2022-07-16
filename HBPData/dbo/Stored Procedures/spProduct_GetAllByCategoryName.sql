CREATE PROCEDURE [dbo].[spProduct_GetAllByCategoryName]
	@categoryName NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Product.[Id], Product.[Sku], Product.[Name], Product.[Description], Product.[Weight], 
			Product.[RetailPrice], Product.[QuantityInStock], Product.[CreateDate], Product.[ModifiedDate]
	FROM dbo.Product
	INNER JOIN dbo.ProductCategory
	ON dbo.ProductCategory.ProductId = dbo.Product.Id
	INNER JOIN Category
	ON dbo.Category.Id = dbo.ProductCategory.CategoryId
	WHERE dbo.Category.Title = @categoryName
END