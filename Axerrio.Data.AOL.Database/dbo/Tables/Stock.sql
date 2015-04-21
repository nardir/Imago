CREATE TABLE [dbo].[Stock] (
    [StockKey]           INT           IDENTITY (1, 1) NOT NULL,
    [StockTypeId]        INT           NOT NULL,
    [LogisticIdentifier] NVARCHAR (50) NULL,
    [Created]            DATETIME      CONSTRAINT [DF_Stock_Created] DEFAULT (getdate()) NOT NULL,
    [Modified]           DATETIME      CONSTRAINT [DF_Stock_Modified] DEFAULT (getdate()) NOT NULL,
    [ArticleKey] INT NOT NULL, 
    CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED ([StockKey] ASC),
    CONSTRAINT [FK_Stock_StockType] FOREIGN KEY ([StockTypeId]) REFERENCES [dbo].[StockType] ([StockTypeId]),
	CONSTRAINT [FK_Stock_Article] FOREIGN KEY ([ArticleKey]) REFERENCES [dbo].[Article] ([ArticleKey])
);
GO
CREATE NONCLUSTERED INDEX [IX_FK_Stock_StockType]
    ON [dbo].[Stock]([StockTypeId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_FK_Stock_Article]
    ON [dbo].[Stock]([ArticleKey] ASC);
