CREATE TABLE [dbo].[Pharma] (
    [Id]             INT        NOT NULL,
    [類別]           NVARCHAR(MAX) NULL,
    [名稱]           NVARCHAR(MAX) NULL,
    [地址]        NVARCHAR(MAX) NULL,
    [核准類型]    NVARCHAR(MAX) NULL,
    [核定品項] NVARCHAR(MAX) NULL,
    [GMP核定作業內容]            NVARCHAR(MAX) NULL,
    [GDP核定內容]            NVARCHAR(MAX) NULL,
    [備註]           NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
