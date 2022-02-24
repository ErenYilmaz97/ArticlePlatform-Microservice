using MediatR;
using Microservices.EventBus.Orchestrator.Event.Identity;
using Microservices.EventBus.Orchestrator.EventBusResult;

namespace Microservices.EventBus.Orchestrator.OrchestratorHandler.Identity;

public class IdentityTestEventHandler : IRequestHandler<IdentityTestEvent, IEventBusResult>
{
    public Task<IEventBusResult> Handle(IdentityTestEvent request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}