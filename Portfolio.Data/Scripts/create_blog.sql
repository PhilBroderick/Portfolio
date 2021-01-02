CREATE TABLE Blog (
    Id uniqueidentifier NOT NULL PRIMARY KEY,
    Title nvarchar(255) NOT NULL,
    Content text NOT NULL,
    Created datetime DEFAULT GETDATE()
)