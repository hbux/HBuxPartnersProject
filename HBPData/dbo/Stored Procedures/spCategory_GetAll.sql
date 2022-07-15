CREATE PROCEDURE [dbo].[spCategory_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name] 
	FROM dbo.Category
END