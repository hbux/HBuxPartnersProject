CREATE TABLE [dbo].[ProductCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(100, 1),
	[ProductId] INT NOT NULL,
	[CategoryId] INT NOT NULL
)
