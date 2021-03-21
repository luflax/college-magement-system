CREATE TABLE [dbo].[Subject] (
    [Id] INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NULL,
    [CourseId]  INT           NULL,
	[TeacherId] INT			NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([CourseID]) 
        REFERENCES [dbo].[Course] ([Id]) ON DELETE CASCADE,
	FOREIGN KEY ([TeacherId]) 
        REFERENCES [dbo].[Teacher] ([Id]) ON DELETE CASCADE
)