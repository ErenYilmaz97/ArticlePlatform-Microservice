using Microservices.EventOrchestrator.Event.User;
using Microservices.EventOrchestrator.EventInfoObject.User;
using Microservices.EventOrchestrator.OrchestratorEvent.Abstract;

namespace Microservices.EventOrchestrator.OrchestratorEvent.User
{
    public class UserTestOrchestratorEvent : IGenericOrchestratorEvent<UserTestEvent, UserTestEventInfo>
    {
        public UserTestEventInfo EventInfo { get; set; }
    }
}
