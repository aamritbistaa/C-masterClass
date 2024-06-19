CREATE TABLE [dbo].[ContactPhoneNumbers]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
	[ContactId] INT NOT NULL,
	[PhoneNumberId] INT NOT NULL
)