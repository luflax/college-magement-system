CREATE TABLE [dbo].[Teacher] (
    [Id] INT           IDENTITY (1, 1) NOT NULL,
	[UserId] INT NOT NULL,
    [Salary]    MONEY NULL
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([UserId]) 
        REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
)