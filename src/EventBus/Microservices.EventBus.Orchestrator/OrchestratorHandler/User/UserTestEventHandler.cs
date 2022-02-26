using MediatR;
using Microservices.EventBus.Orchestrator.Event.User;
using Microservices.EventBus.Orchestrator.EventBusResult;
using Microservices.EventBus.Orchestrator.EventPublisher.Interface;

namespace Microservices.EventBus.Orchestrator.OrchestratorHandler.User;

public class UserTestEventHandler : IRequestHandler<UserTestEvent, IEventBusResult>
{
    private readonly IEventPublisher _eventPublisher;

    public UserTestEventHandler(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }
    public async Task<IEventBusResult> Handle(UserTestEvent request, CancellationToken cancellationToken)
    {
        _eventPublisher.PublishUserEvent(request);
        return new EventBusSuccessResult("");
    }
}