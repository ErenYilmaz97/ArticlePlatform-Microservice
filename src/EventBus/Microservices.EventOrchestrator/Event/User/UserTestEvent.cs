using Microservices.EventOrchestrator.Event.Abstract;
using Microservices.EventOrchestrator.EventInfoObject.User;

namespace Microservices.EventOrchestrator.Event.User
{
    public class UserTestEvent : Event<UserTestEventInfo>
    {
        public UserTestEvent(UserTestEventInfo eventInfo):base(eventInfo)
        {

        }
    }
}
