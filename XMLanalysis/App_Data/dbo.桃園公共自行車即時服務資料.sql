CREATE TABLE [dbo].[桃園公共自行車即時服務資料] (
    [Id]           INT        NOT NULL  IDENTITY (1, 1),
    [areaId]       NCHAR (10) NULL,
    [areaName]     NCHAR (64) NULL,
    [parkName]     NCHAR (64) NULL,
    [totalSpace]   INT        NULL,
    [surplusSpace] NCHAR (64) NULL,
    [payGuide]     NCHAR (256) NULL,
    [introduction] NCHAR (128) NULL,
    [address]      NCHAR (128) NULL,
    [wgsx]         FLOAT (53) NULL,
    [wgsy]         FLOAT (53) NULL,
    [parkId]       NCHAR (32) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

