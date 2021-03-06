﻿CREATE TABLE [Payments2].[DataLockFailure]
(
	[Id] BIGINT NOT NULL CONSTRAINT PK_DataLockFailure PRIMARY KEY IDENTITY, 
	[DataLockEventId] UNIQUEIDENTIFIER,
	[EarningEventId] UNIQUEIDENTIFIER NOT NULL,
    [Ukprn] BIGINT NOT NULL, 
    [LearnerUln] BIGINT NOT NULL, 
    [LearnerReferenceNumber] NVARCHAR(50) NOT NULL, 
    [LearningAimReference] NVARCHAR(8) NOT NULL, 
    [LearningAimProgrammeType] INT NOT NULL, 
    [LearningAimStandardCode] INT NOT NULL, 
    [LearningAimFrameworkCode] INT NOT NULL, 
    [LearningAimPathwayCode] INT NOT NULL, 
    [AcademicYear] SMALLINT NOT NULL, 
    [TransactionType] TINYINT NOT NULL,
    [DeliveryPeriod] TINYINT NOT NULL, 
    [CollectionPeriod] TINYINT NOT NULL, 
    [EarningPeriod] NVARCHAR(MAX) NOT NULL, 
    [Amount] DECIMAL(15, 5) NOT NULL,
    [CreationDate] DATETIME2 NOT NULL DEFAULT sysutcdatetime()
)

GO

CREATE UNIQUE INDEX [IX_DataLockFailure_Key] ON [Payments2].[DataLockFailure] ([Ukprn], [LearningAimFrameworkCode], [LearningAimPathwayCode], [LearningAimProgrammeType], [LearningAimStandardCode], [LearningAimReference], [LearnerReferenceNumber], [AcademicYear], [DeliveryPeriod], [TransactionType])
GO
CREATE NONCLUSTERED INDEX [IX_DataLockFailure__Search] ON [Payments2].[DataLockFailure] ([AcademicYear], [LearnerReferenceNumber], [LearningAimReference], [Ukprn], [TransactionType]) INCLUDE ([Amount], [DataLockEventId], [DeliveryPeriod], [EarningEventId], [LearnerUln], [LearningAimFrameworkCode], [LearningAimPathwayCode], [LearningAimProgrammeType], [LearningAimStandardCode]) WITH (ONLINE = ON)