using MediatR;
using Microservices.EventBus.Orchestrator.Event.User;
using Microservices.EventBus.Orchestrator.EventBusResult;

namespace Microservices.EventBus.Orchestrator.OrchestratorHandler.User;

public class UserTestEventHandler : IRequestHandler<UserTestEvent, IEventBusResult>
{
    public Task<IEventBusResult> Handle(UserTestEvent request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}