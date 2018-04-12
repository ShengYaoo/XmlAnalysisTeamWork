CREATE TABLE [dbo].[Pharma] (
    [Id]             INT        NOT NULL,
    [type]           NVARCHAR(MAX) NULL,
    [name]           NVARCHAR(MAX) NULL,
    [address]        NVARCHAR(MAX) NULL,
    [formulation]    NVARCHAR(MAX) NULL,
    [approved_items] NVARCHAR(MAX) NULL,
    [GMP]            NVARCHAR(MAX) NULL,
    [GDP]            NVARCHAR(MAX) NULL,
    [note]           NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

