CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductName] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT  getutcdate(), 
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [RetialPrice] MONEY NOT NULL
)
