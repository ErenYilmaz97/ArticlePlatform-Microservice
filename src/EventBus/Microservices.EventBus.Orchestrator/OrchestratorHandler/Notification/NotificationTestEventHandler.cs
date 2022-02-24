using MediatR;
using Microservices.EventBus.Orchestrator.Event.Notification;
using Microservices.EventBus.Orchestrator.EventBusResult;

namespace Microservices.EventBus.Orchestrator.OrchestratorHandler.Notification;

public class NotificationTestEventHandler : IRequestHandler<NotificationTestEvent, IEventBusResult>
{
    public Task<IEventBusResult> Handle(NotificationTestEvent request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}