﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;
using SFA.DAS.Payments.AcceptanceTests.Core;
using SFA.DAS.Payments.Core;
using SFA.DAS.Payments.Monitoring.Jobs.Messages.Commands;
using TechTalk.SpecFlow;
using NServiceBus;
using SFA.DAS.Payments.Monitoring.Jobs.Data;
using SFA.DAS.Payments.Monitoring.Jobs.Data.Model;

namespace SFA.DAS.Payments.Monitoring.AcceptanceTests.Jobs
{
    [Binding]
    public class JobsSteps : StepsBase
    {
        protected JobsDataContext DataContext => Container.Resolve<JobsDataContext>();
        protected JobModel Job
        {
            get => Get<JobModel>();
            set => Set(value);
        }

        public List<GeneratedMessage> GeneratedMessages
        {
            get => Get<List<GeneratedMessage>>();
            set => Set(value);
        }

        public RecordStartedProcessingEarningsJob JobDetails
        {
            get => Get<RecordStartedProcessingEarningsJob>();
            set => Set(value);
        }

        public JobsSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"the payments are for the current collection year")]
        public void GivenThePaymentsAreForTheCurrentCollectionYear()
        {
            SetCurrentCollectionYear();
        }

        [Given(@"the current collection period is R(.*)")]
        [Given(@"the current processing period is (.*)")]
        public void GivenTheCurrentProcessingPeriodIs(byte period)
        {
            CollectionPeriod = period;
        }

        [Given(@"the earnings event service has received a provider earnings job")]
        public void GivenTheEarningsEventServiceHasReceivedAProviderEarningsJob()
        {
            GeneratedMessages = new List<GeneratedMessage>
            {
                new GeneratedMessage {StartTime = DateTimeOffset.UtcNow, MessageName = "SFA.DAS.Payments.EarningEvents.Commands.Internal.ProcessLearnerCommand", MessageId = Guid.NewGuid()},
                new GeneratedMessage {StartTime = DateTimeOffset.UtcNow, MessageName = "SFA.DAS.Payments.EarningEvents.Commands.Internal.ProcessLearnerCommand", MessageId = Guid.NewGuid()},
                new GeneratedMessage {StartTime = DateTimeOffset.UtcNow, MessageName = "SFA.DAS.Payments.EarningEvents.Commands.Internal.ProcessLearnerCommand", MessageId = Guid.NewGuid()},
            };
            JobDetails = new RecordStartedProcessingEarningsJob
            {
                JobId = TestSession.JobId,
                CollectionPeriod = CollectionPeriod,
                CollectionYear = 1819,
                Ukprn = TestSession.Ukprn,
                StartTime = DateTimeOffset.UtcNow,
                IlrSubmissionTime = DateTime.UtcNow.AddSeconds(-10),
                GeneratedMessages = GeneratedMessages,
                
            };

            Console.WriteLine($"Job details: {JobDetails.ToJson()}");
        }

        [Given(@"a provider earnings job has already been recorded")]
        public async Task GivenAProviderEarningsJobHasAlreadyBeenRecorded()
        {
            GeneratedMessages = new List<GeneratedMessage>
            {
                new GeneratedMessage {StartTime = DateTimeOffset.UtcNow, MessageName = "SFA.DAS.Payments.EarningEvents.Commands.Internal.ProcessLearnerCommand", MessageId = Guid.NewGuid()},
                new GeneratedMessage {StartTime = DateTimeOffset.UtcNow, MessageName = "SFA.DAS.Payments.EarningEvents.Commands.Internal.ProcessLearnerCommand", MessageId = Guid.NewGuid()},
                new GeneratedMessage {StartTime = DateTimeOffset.UtcNow, MessageName = "SFA.DAS.Payments.EarningEvents.Commands.Internal.ProcessLearnerCommand", MessageId = Guid.NewGuid()},
            };
            JobDetails = new RecordStartedProcessingEarningsJob
            {
                JobId = TestSession.JobId,
                CollectionPeriod = CollectionPeriod,
                CollectionYear = 1819,
                Ukprn = TestSession.Ukprn,
                StartTime = DateTimeOffset.UtcNow,
                IlrSubmissionTime = DateTime.UtcNow.AddSeconds(-10),
                GeneratedMessages = GeneratedMessages
            };

            Job = new JobModel
            {
                JobType = JobType.EarningsJob,
                StartTime = JobDetails.StartTime,
                CollectionPeriod = JobDetails.CollectionPeriod,
                AcademicYear = JobDetails.CollectionYear,
                Ukprn = JobDetails.Ukprn,
                DcJobId = JobDetails.JobId,
                IlrSubmissionTime = JobDetails.IlrSubmissionTime,
                Status = JobStatus.InProgress,
                LearnerCount = GeneratedMessages.Count
            };
            DataContext.Jobs.Add(Job);
            await DataContext.SaveChangesAsync();
            DataContext.JobSteps.AddRange(
                GeneratedMessages.Select(msg => 
                    new JobStepModel
                    {
                        JobId = Job.Id,
                        StartTime = msg.StartTime,
                        MessageName = msg.MessageName,
                        MessageId = msg.MessageId,
                        Status = JobStepStatus.Queued
                    }));
            await DataContext.SaveChangesAsync();
        }

        [When(@"the final messages for the job are sucessfully processed")]
        public async Task WhenTheFinalMessagesForTheJobAreSucessfullyProcessed()
        {
            foreach (var generatedMessage in GeneratedMessages)
            {
                await MessageSession.Send(new RecordJobMessageProcessingStatus
                {
                    JobId = JobDetails.JobId, MessageName = generatedMessage.MessageName,
                    EndTime = DateTimeOffset.UtcNow, Succeeded = true, Id = generatedMessage.MessageId
                });
            }
        }

        [When(@"the earnings event service notifies the job monitoring service to record the job")]
        public async Task WhenTheEarningsEventServiceNotifiesTheJobMonitoringServiceToRecordTheJob()
        {
            await MessageSession.Send(JobDetails).ConfigureAwait(false);
        }

        [When(@"the final messages for the job are failed to be processed")]
        public async Task WhenTheFinalMessagesForTheJobAreFailedToBeProcessed()
        {
            foreach (var generatedMessage in GeneratedMessages)
            {
                await MessageSession.Send(new RecordJobMessageProcessingStatus
                {
                    JobId = JobDetails.JobId,
                    MessageName = generatedMessage.MessageName,
                    EndTime = DateTimeOffset.UtcNow,
                    Succeeded = false,
                    Id = generatedMessage.MessageId
                });
            }
        }

        [Then(@"the job monitoring service should update the status of the job to show that it has completed with errors")]
        public async Task ThenTheJobMonitoringServiceShouldUpdateTheStatusOfTheJobToShowThatItHasCompletedWithErrors()
        {
            await WaitForIt(() =>
            {
                return DataContext.Jobs.Any(j => j.Id == Job.Id && j.Status == JobStatus.CompletedWithErrors);
            }, $"Status was not updated to Completed for job: {Job.Id}, Dc job id: {JobDetails.JobId}");
        }


        [Then(@"the job monitoring service should record the job")]
        public async Task ThenTheJobMonitoringServiceShouldRecordTheJob()
        {
            await WaitForIt(() =>
            {
                var job = DataContext.Jobs
                    .FirstOrDefault(x => x.DcJobId == JobDetails.JobId);

                if (job == null)
                    return false;
                Job = job;
                Console.WriteLine($"Found job: {Job.Id}, status: {Job.Status}, start time: {job.StartTime}");
                return true;
            }, $"Failed to find job with dc job id: {JobDetails.JobId}");
        }

        [Then(@"the job monitoring service should also record the messages generated by earning events service")]
        public async Task ThenTheJobMonitoringServiceShouldAlsoRecordTheMessagesGeneratedByEarningEventsService()
        {
            await WaitForIt(() =>
            {
                foreach (var generatedMessage in GeneratedMessages)
                {
                    if (!DataContext.JobSteps.Any(step => step.JobId == Job.Id && step.MessageId == generatedMessage.MessageId))
                    {
                        Console.WriteLine($"Failed to find job step {generatedMessage.MessageId} for job: {Job.Id}");
                        return false;
                    }

                    Console.WriteLine($"Found job step: {generatedMessage.MessageId}");
                }
                Console.WriteLine($"Found all expected job steps for job : {Job.Id}, dc job id: {JobDetails.JobId}");
                return true;
            }, $"Failed to find the expected job steps for job: {Job.Id}");
        }


        [Then(@"the job monitoring service should update the status of the job to show that it has completed")]
        public async Task ThenTheJobMonitoringServiceShouldUpdateTheStatusOfTheJobToShowThatItHasCompleted()
        {
            await WaitForIt(() =>
                {
                    return DataContext.Jobs.Any(j => j.Id == Job.Id && j.Status == JobStatus.Completed);
                },$"Status was not updated to Completed for job: {Job.Id}, Dc job id: {JobDetails.JobId}");
        }
    }
}