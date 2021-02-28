CREATE TABLE [dbo].[Subscriber](
    [Id] [uniqueidentifier] NOT NULL DEFAULT(newid()),
    [Email] [nvarchar](128) NOT NULL,
    [Subscribed] [bit] NOT NULL,
    [CreatedOn] [datetime] DEFAULT(getdate())
    ) ON [PRIMARY]