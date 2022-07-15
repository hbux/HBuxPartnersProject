﻿CREATE TABLE [dbo].[Photo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(340192, 1),
	[Name] NVARCHAR(450) NOT NULL,
	[Type] NVARCHAR(10) NOT NULL,
	[ProductId] INT NOT NULL,
    CONSTRAINT [FK_Photo_ToProduct] FOREIGN KEY (ProductId) REFERENCES [Product]([Id])
)