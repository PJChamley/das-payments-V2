﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting;
using SFA.DAS.Payments.EarningEvents.Messages.Events;

[assembly: FabricTransportActorRemotingProvider(RemotingListener = RemotingListener.V2Listener, RemotingClient = RemotingClient.V2Client)]
namespace SFA.DAS.Payments.PaymentsDue.ApprenticeshipPaymentsDueService.Interfaces
{
    public interface IApprenticeshipPaymentsDueService : IActor
    {
        Task HandlePayableEarning(IPayableEarningEvent earning, CancellationToken cancellationToken);
    }
}
