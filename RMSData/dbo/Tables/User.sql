CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY , 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName ] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(256) NOT NULL, 
    [Role] NVARCHAR(50) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
