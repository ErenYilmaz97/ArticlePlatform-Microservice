using MediatR;
using Microservices.EventOrchestrator.EventBusResult;


namespace Microservices.EventOrchestrator.OrchestratorEvent.Abstract
{
    //Her OrchestratorEvent, IRequest interfaceini implemente etmeli. Böylece Mediator patternde command görevi görmektedir
    public interface IOrchestratorEvent : IRequest<IEventBusResult> //Common Interface
    {
    }
}
