﻿CREATE TABLE [Payments2].[JobEvent]
(
	JobEventId BIGINT NOT NULL IDENTITY(1,1) CONSTRAINT PK_JobEvent PRIMARY KEY CLUSTERED,
	JobId BIGINT NOT NULL CONSTRAINT FK_JobEvent__Job FOREIGN KEY REFERENCES [Payments2].[Job] (JobId),
	EventId UNIQUEIDENTIFIER NOT NULL,
	ParentEventId UNIQUEIDENTIFIER NULL,
	[Status] TINYINT NOT NULL CONSTRAINT FK_JobEvent__JobEventStatus FOREIGN KEY REFERENCES [Payments2].[JobEventStatus] (Id) CONSTRAINT DF_Job_Event__Status DEFAULT (1),
	StartTime DATETIMEOFFSET NULL,
	EndTime DATETIMEOFFSET NULL, 
    MessageName NVARCHAR(250) NOT NULL,
	CreationDate DATETIMEOFFSET NOT NULL CONSTRAINT DF_JobEvent__CreationDate DEFAULT (SYSDATETIMEOFFSET()),
	CONSTRAINT UC_JobEvent__JobId_EventId UNIQUE (JobId,EventId)
)
GO

CREATE INDEX [IX_JobEvent__Search] ON [Payments2].[JobEvent](
	JobEventId,
	JobId,
	EventId,
	[Status],
	EndTime
)
GO