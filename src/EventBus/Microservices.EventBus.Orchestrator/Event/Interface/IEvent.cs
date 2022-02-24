using MediatR;
using Microservices.EventBus.Orchestrator.EventBusResult;

namespace Microservices.EventBus.Orchestrator.Event.Interface;

//Common Event Interface. Only can access event name.
public interface IEvent : IRequest<IEventBusResult>
{ 
    string GetEventName();
}