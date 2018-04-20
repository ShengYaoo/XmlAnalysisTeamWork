CREATE TABLE [dbo].[Table]
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
