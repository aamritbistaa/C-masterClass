CREATE TABLE [dbo].[ContactsEmail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContactId] INT NOT NULL, 
    [EmailAddressId] INT NOT NULL
)
