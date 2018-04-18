CREATE TABLE [dbo].[藥局] (
    [Id]   INT            NOT NULL,
    [機構名稱] NVARCHAR (MAX) NULL,
    [機構狀態] NVARCHAR (MAX) NULL,
    [地址] NVARCHAR (MAX) NULL,
    [電話] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

