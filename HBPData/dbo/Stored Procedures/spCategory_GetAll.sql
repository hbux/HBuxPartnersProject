CREATE PROCEDURE [dbo].[spCategory_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Title], [ParentId], [Level]
	FROM dbo.Category
END