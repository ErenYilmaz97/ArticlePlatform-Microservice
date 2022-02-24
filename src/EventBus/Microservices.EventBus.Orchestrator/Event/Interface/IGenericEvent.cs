using Microservices.EventBus.Orchestrator.EventInfo.Interface;
namespace Microservices.EventBus.Orchestrator.Event.Interface;

//Generic Event Interface. Can access event name and event info.
public interface IGenericEvent<TEventInfo> : IEvent where TEventInfo : class, IEventInfoObject
{ 
    TEventInfo EventInfo { get; set; }   
}