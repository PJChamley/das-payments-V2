﻿using System;
using System.Collections.Generic;

namespace SFA.DAS.Payments.Monitoring.Jobs.Messages.Commands
{
    public class RecordJobMessageProcessingStatus : JobsCommand
    {
        public Guid Id { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public bool Succeeded { get; set; }
        public List<GeneratedMessage> GeneratedMessages { get; set; }
        public string MessageName { get; set; }
        public RecordJobMessageProcessingStatus()
        {
            GeneratedMessages = new List<GeneratedMessage>();
        }
    }
}