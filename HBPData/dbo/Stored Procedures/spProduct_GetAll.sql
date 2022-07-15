CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Product.[Id], Product.[Name], Product.[Description], Product.[RetailPrice], 
			Product.[QuantityInStock], Product.[CreateDate]
	FROM dbo.Product
END