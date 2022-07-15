﻿CREATE TABLE [dbo].[ProductCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(539192, 1),
	[ProductId] INT NOT NULL,
	[CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_ProductCategory_ToProduct] FOREIGN KEY (ProductId) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_ProductCategory_ToCategory] FOREIGN KEY (CategoryId) REFERENCES [Category]([Id])
)
