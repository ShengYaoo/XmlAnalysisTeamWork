CREATE TABLE [dbo].[桃園公共自行車即時服務資料]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [areaId] NCHAR(10) NULL, 
    [areaName] NCHAR(10) NULL, 
    [parkName] NCHAR(10) NULL, 
    [totalSpace] INT NULL, 
    [surpluSpace] NCHAR(10) NULL, 
    [payGuide] NCHAR(10) NULL, 
    [introduction] NCHAR(10) NULL, 
    [address] NCHAR(10) NULL, 
    [wgsx] FLOAT NULL, 
    [wgsy] FLOAT NULL, 
    [parkId] NCHAR(10) NULL
	)
