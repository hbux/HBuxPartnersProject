﻿CREATE PROCEDURE [dbo].[spPhoto_GetById]
	@productId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [ProductId], [BlobName], [BlobContainerUri], [BlobType]
	FROM dbo.Photo
	WHERE dbo.Photo.ProductId = @productId
END