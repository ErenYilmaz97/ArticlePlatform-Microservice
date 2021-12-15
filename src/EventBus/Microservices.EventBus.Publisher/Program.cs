using Microservices.EventOrchestrator.Enum;
using Microservices.EventOrchestrator.EventInfoObject.Chat;
using Microservices.EventOrchestrator.EventInfoObject.Identity;
using Microservices.EventOrchestrator.EventInfoObject.Notification;
using Microservices.EventOrchestrator.EventInfoObject.User;
using Microservices.EventOrchestrator.EventOrchestratorPublisher;
using Microservices.EventOrchestrator.OrchestratorEvent.Chat;
using Microservices.EventOrchestrator.OrchestratorEvent.Identity;
using Microservices.EventOrchestrator.OrchestratorEvent.Notification;
using Microservices.EventOrchestrator.OrchestratorEvent.User;

namespace Microservices.EventBus.Publisher { 
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();

            var orchestratorEventPublisher = new EventOrchestratorPublisher();
            var testEventInfo = new IdentityTestEventInfo() { TestValue = "IdentityTestValue"};
            var testEvent = new IdentityTestOrchestratorEvent() { EventInfo = testEventInfo};

            orchestratorEventPublisher.PublishOrchestratorEvent<IdentityTestOrchestratorEvent>(OrchestratorEventType.IdentityTestEvent, testEvent);
            Console.WriteLine("Identity Event Published");


            Console.ReadLine();
            var testEventInfo2 = new UserTestEventInfo() { TestValue = "IdentityTestValue" };
            var testEvent2 = new UserTestOrchestratorEvent() { EventInfo = testEventInfo2 };

            orchestratorEventPublisher.PublishOrchestratorEvent<UserTestOrchestratorEvent>(OrchestratorEventType.UserTestEvent, testEvent2);
            Console.WriteLine("User Event Published");


            Console.ReadLine();
            var testEventInfo3 = new ChatTestEventInfo() { TestValue = "IdentityTestValue" };
            var testEvent3 = new ChatTestOrchestratorEvent() { EventInfo = testEventInfo3 };

            orchestratorEventPublisher.PublishOrchestratorEvent<ChatTestOrchestratorEvent>(OrchestratorEventType.ChatTestEvent, testEvent3);
            Console.WriteLine("Chat Event Published");

            Console.ReadLine();
            var testEventInfo4 = new NotificationTestEventInfo() { TestValue = "IdentityTestValue" };
            var testEvent4 = new NotificationTestOrchestratorEvent() { EventInfo = testEventInfo4 };

            orchestratorEventPublisher.PublishOrchestratorEvent<NotificationTestOrchestratorEvent>(OrchestratorEventType.NotificationTestEvent, testEvent4);
            Console.WriteLine("Notification Event Published");

        }
    }
}