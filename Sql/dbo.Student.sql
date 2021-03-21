CREATE TABLE [dbo].[Student] (
    [Id] INT           IDENTITY (1, 1) NOT NULL,
	[UserId] INT NOT NULL,
    [RegistrationNumber]    INT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([UserId]) 
        REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
)