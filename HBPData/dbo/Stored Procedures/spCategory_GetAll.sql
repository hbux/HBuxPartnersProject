CREATE PROCEDURE [dbo].[spCategory_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Title], [ParentId]
	FROM dbo.Category
END