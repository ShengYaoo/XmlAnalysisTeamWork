CREATE TABLE [dbo].[AQI]
(
	[Id] INT NOT NULL , 
    [County] NVARCHAR(MAX) NULL, 
    [AQI] INT NULL, 
    [PM2.5] INT NULL, 
    [Status] NVARCHAR(MAX) NULL, 
    [PublishTime] DATETIME NULL, 
    PRIMARY KEY ([Id])
)
