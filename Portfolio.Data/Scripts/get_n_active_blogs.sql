CREATE PROCEDURE GetNActiveBlogs
(
    @numOfBlogs int
)
    AS
BEGIN
    SET NOCOUNT ON

SELECT TOP (@numOfBlogs) * from Blog where IsActive = 1
order by Created desc
END
GO