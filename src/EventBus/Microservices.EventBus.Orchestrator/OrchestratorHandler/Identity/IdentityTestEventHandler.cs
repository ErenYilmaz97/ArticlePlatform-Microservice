using MediatR;
using Microservices.EventBus.Orchestrator.Event.Identity;
using Microservices.EventBus.Orchestrator.EventBusResult;
using Microservices.EventBus.Orchestrator.EventPublisher.Interface;

namespace Microservices.EventBus.Orchestrator.OrchestratorHandler.Identity;

public class IdentityTestEventHandler : IRequestHandler<IdentityTestEvent, IEventBusResult>
{
    private readonly IEventPublisher _eventPublisher;

    public IdentityTestEventHandler(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }

    public async Task<IEventBusResult> Handle(IdentityTestEvent request, CancellationToken cancellationToken)
    {
        _eventPublisher.PublishIdentityEvent(request);
        return new EventBusSuccessResult("");
    }
}