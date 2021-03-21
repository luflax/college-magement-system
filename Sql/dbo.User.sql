CREATE TABLE [dbo].[User] (
    [Id] INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NULL,
    [Birthday]  TIMESTAMP           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)