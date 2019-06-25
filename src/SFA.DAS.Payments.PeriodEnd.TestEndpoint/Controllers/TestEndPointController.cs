﻿using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using SFA.DAS.Payments.Application.Messaging;
using SFA.DAS.Payments.Model.Core;
using SFA.DAS.Payments.PeriodEnd.TestEndpoint.Application.Repositories;
using SFA.DAS.Payments.PeriodEnd.TestEndpoint.Application.Services;
using SFA.DAS.Payments.PeriodEnd.TestEndpoint.Infrastructure;
using SFA.DAS.Payments.PeriodEnd.TestEndpoint.Models;
using SFA.DAS.Payments.ProviderPayments.Messages.Internal.Commands;

namespace SFA.DAS.Payments.PeriodEnd.TestEndpoint.Controllers
{
    public class TestEndPointController : Controller
    {
        private readonly IEndpointInstanceFactory endpointInstanceFactory;
        private readonly IBuildMonthEndPaymentEvent buildMonthEndPaymentEvent;
        private readonly ITestEndpointConfiguration testEndpointConfiguration;

        public TestEndPointController(IEndpointInstanceFactory endpointInstanceFactory, IBuildMonthEndPaymentEvent buildMonthEndPaymentEvent, ITestEndpointConfiguration testEndpointConfiguration)
        {
            this.endpointInstanceFactory = endpointInstanceFactory;
            this.buildMonthEndPaymentEvent = buildMonthEndPaymentEvent;
            this.testEndpointConfiguration = testEndpointConfiguration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> SendPeriodEnd(SendPeriodEndRequest requestModel)
        {
            var processProviderMonthEndCommand = buildMonthEndPaymentEvent
                .CreateProcessProviderMonthEndCommand(requestModel.Ukprn, requestModel.AcademicYear, requestModel.Period);

            var collectionStartMessage = await buildMonthEndPaymentEvent
                    .CreateCollectionStartedEvent(requestModel.Ukprn, requestModel.AcademicYear);
            
            var endpointInstance = await endpointInstanceFactory.GetEndpointInstance().ConfigureAwait(false);
           await endpointInstance.Publish(collectionStartMessage).ConfigureAwait(false);

            var options = new SendOptions();
            options.SetDestination(testEndpointConfiguration.ProviderPaymentsEndpointName);
            await endpointInstance.Send(processProviderMonthEndCommand, options).ConfigureAwait(false);

            ViewBag.Message = "Month end event successfully sent";

            return View("Index");
        }
    }
}