CREATE TABLE [dbo].[SubjectStudent] (
    [Id] INT           IDENTITY (1, 1) NOT NULL,
    [SubjectId]  INT           NOT NULL,
	[StudentId] INT			NOT NULL,
	[Grade] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([SubjectId]) 
        REFERENCES [dbo].[Subject] ([Id]) ON DELETE SET NULL,
	FOREIGN KEY ([StudentId]) 
        REFERENCES [dbo].[Student] ([Id]) ON DELETE SET NULL
)