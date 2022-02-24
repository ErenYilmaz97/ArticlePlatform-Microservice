using Microservices.EventBus.Orchestrator.EventInfo.Interface;

namespace Microservices.EventBus.Orchestrator.EventInfo.Identity;

public class IdentityTestEventInfo : IEventInfoObject
{
     string TestValue { get; set; }
}