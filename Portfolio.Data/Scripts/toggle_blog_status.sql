CREATE PROCEDURE ToggleBlogStatus
(
    @id uniqueidentifier
)
    AS
BEGIN
    SET NOCOUNT ON

UPDATE Blog
SET IsActive = ~IsActive
WHERE Id = @id
END
GO