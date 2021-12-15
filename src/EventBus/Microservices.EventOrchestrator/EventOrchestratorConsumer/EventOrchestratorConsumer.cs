using Microservices.EventOrchestrator.Constant;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microservices.EventOrchestrator.EventOrchestrator;
using System.Text;
using Microservices.EventOrchestrator.OrchestratorEvent.Identity;
using Newtonsoft.Json;
using Microservices.EventOrchestrator.EventBusResult;
using Microservices.EventOrchestrator.OrchestratorEvent.User;
using Microservices.EventOrchestrator.OrchestratorEvent.Chat;
using Microservices.EventOrchestrator.OrchestratorEvent.Notification;

namespace Microservices.EventOrchestrator.EventOrchestratorConsumer
{
    public class EventOrchestratorConsumer : BackgroundService
    {
        private readonly Microservices.EventOrchestrator.EventOrchestrator.EventOrchestrator _orchestrator;
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;


        public EventOrchestratorConsumer(Microservices.EventOrchestrator.EventOrchestrator.EventOrchestrator orchestrator)
        {
            this._connectionFactory = new ConnectionFactory() { Uri = new Uri(RabbitMQConstants.HostUri) };
            this._connection = _connectionFactory.CreateConnection();
            this._channel = _connection.CreateModel();
            this._orchestrator = orchestrator;
        }

        //Consumer sadece kuyruğu bilir
        //Microservicelerden publish edilen OrchestratorEvent'ler burada consume edilerek, handle edilmekte
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _channel.QueueDeclare(queue: RabbitMQConstants.EventOrchestratorQueueName, durable: true, exclusive: false, autoDelete: false);
            this._channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(_channel);
            _channel.BasicConsume(RabbitMQConstants.EventOrchestratorQueueName, false, consumer);

            consumer.Received += Consumer_Received;        

            return Task.CompletedTask;
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs args)
        {
            
           string eventName = args.RoutingKey.Split(".").Last();
           string message = Encoding.UTF8.GetString(args.Body.ToArray());

           var result =  this.HandleOrchestratorEvent(eventName, message).GetAwaiter().GetResult();

           if (result.Succeed)
           {
              //Handle işlemi başarılı ise ack ediyoruz
               _channel.BasicAck(args.DeliveryTag, false);
            }

        }


        //OrchestratorEvent'i Handle Ediyoruz
        private async Task<IEventBusResult> HandleOrchestratorEvent(string eventName, string @event)
        {
            return eventName switch
            {
                "IdentityTestEvent" => await this._orchestrator.HandleOrchestrationEvent<IdentityTestOrchestratorEvent>(JsonConvert.DeserializeObject<IdentityTestOrchestratorEvent>(@event)),
                "UserTestEvent" => await this._orchestrator.HandleOrchestrationEvent<UserTestOrchestratorEvent>(JsonConvert.DeserializeObject<UserTestOrchestratorEvent>(@event)),
                "ChatTestEvent" => await this._orchestrator.HandleOrchestrationEvent<ChatTestOrchestratorEvent>(JsonConvert.DeserializeObject<ChatTestOrchestratorEvent>(@event)),
                "NotificationTestEvent" => await this._orchestrator.HandleOrchestrationEvent<NotificationTestOrchestratorEvent>(JsonConvert.DeserializeObject<NotificationTestOrchestratorEvent>(@event))
            };
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
