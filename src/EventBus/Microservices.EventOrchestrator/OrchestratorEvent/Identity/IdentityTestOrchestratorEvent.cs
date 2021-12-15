using Microservices.EventOrchestrator.Event.Identity;
using Microservices.EventOrchestrator.EventInfoObject.Identity;
using Microservices.EventOrchestrator.OrchestratorEvent.Abstract;

namespace Microservices.EventOrchestrator.OrchestratorEvent.Identity
{
    public class IdentityTestOrchestratorEvent : IGenericOrchestratorEvent<IdentityTestEvent, IdentityTestEventInfo>
    {
        public IdentityTestEventInfo EventInfo { get; set; }
    }
}
