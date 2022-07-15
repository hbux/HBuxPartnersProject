﻿CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(179293, 1),
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[RetailPrice] MONEY NOT NULL,
	[QuantityInStock] INT NOT NULL,
	[CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)