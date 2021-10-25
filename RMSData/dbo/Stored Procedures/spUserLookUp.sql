CREATE PROCEDURE [dbo].[spUserLookUp]
	@Id nvarchar(128)
AS
Begin
	Select FirstName, LastName , Email, CreatedDate from [dbo].[User]
		where Id = @Id;
End