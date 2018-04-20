CREATE TABLE [dbo].[桃園公共自行車即時服務資料] (
    [Id]           INT        NOT NULL  IDENTITY (1, 1),
    [areaId]       NCHAR (10) NULL,
    [areaName]     NCHAR (10) NULL,
    [parkName]     NCHAR (10) NULL,
    [totalSpace]   INT        NULL,
    [surplusSpace] NCHAR (10) NULL,
    [payGuide]     NCHAR (10) NULL,
    [introduction] NCHAR (10) NULL,
    [address]      NCHAR (10) NULL,
    [wgsx]         FLOAT (53) NULL,
    [wgsy]         FLOAT (53) NULL,
    [parkId]       NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

