namespace Microservices.EventOrchestrator.Constant
{
    public class RabbitMQConstants
    {
        public const string HostUri = "amqps://gceugtpl:U1OctC8595Ke_XyipHFRIfnUuDmyHOf7@fish.rmq.cloudamqp.com/gceugtpl";
        public const string ExchangeName = "Event-Router";

        //Queue Names
        public const string IdentityEventsQueueName = "IdentityService.Events";
        public const string UserEventsQueueName = "UserService.Events";
        public const string ChatEventsQueueName = "ChatEvents.Events";
        public const string NotificationEventsQueueName = "NotificationService.Events";
        public const string ArticleEventsQueueName = "ArticleService.Events";
        public const string ForumEventsQueueName = "ForumService.Events";
        public const string FavoriteEventsQueueName = "FavoriteService.Events";
        public const string EventOrchestratorQueueName = "Orchestrator-Events";


        //Queue Bind Route Keys
        public const string IdentityQueueBindKey = "IdentityService.Events.*";
        public const string UserQueueBindKey = "UserService.Events.*";
        public const string ChatQueueBindKey = "ChatService.Events.*";
        public const string NotificationQueueBindKey = "NotificationService.Events.*";
        public const string ArticleQueueBindKey = "ArticleService.Events.*";
        public const string ForumQueueBindKey = "ForumService.Events.*";
        public const string FavoriteQueueBindKey = "FavoriteService.Events.*";
        public const string OrchestratorQueueBindKey = "Orchestrator.Events.*";

    }
}
