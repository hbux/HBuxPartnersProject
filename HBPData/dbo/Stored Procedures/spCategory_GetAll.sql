CREATE PROCEDURE [dbo].[spCategory_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Title]
	FROM dbo.Category
	WHERE [ParentId] IS NULL
END