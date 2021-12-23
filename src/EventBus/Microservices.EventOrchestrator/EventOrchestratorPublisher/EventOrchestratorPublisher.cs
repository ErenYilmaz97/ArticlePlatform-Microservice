using Microservices.EventOrchestrator.Constant;
using Microservices.EventOrchestrator.Enum;
using Microservices.EventOrchestrator.EventPublisher.Abstract;
using Microservices.EventOrchestrator.OrchestratorEvent.Abstract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Microservices.EventOrchestrator.EventOrchestratorPublisher
{
    public class EventOrchestratorPublisher : IEventOrchestratorPublisher
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public EventOrchestratorPublisher()
        {
            _connectionFactory = new ConnectionFactory() { Uri = new Uri(RabbitMQConstants.HostUri) };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

        }


        public void PublishOrchestratorEvent<TOrchestratorEvent>(OrchestratorEventType eventType, TOrchestratorEvent @event) where TOrchestratorEvent : class, IOrchestratorEvent
        {
            this.CheckConnection();

            _channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: RabbitMQConstants.EventOrchestratorQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: RabbitMQConstants.EventOrchestratorQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.OrchestratorQueueBindKey);


            string eventName = this.GetOrchestratorEventName(eventType);
            string messageRouteKey = "Orchestrator.Events." + eventName;
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            var messageProperty = _channel.CreateBasicProperties();
            messageProperty.Persistent = true;

            try
            {
                _channel.BasicPublish(exchange: RabbitMQConstants.ExchangeName, routingKey: messageRouteKey, basicProperties: messageProperty, body: messageBody);
            }
            catch (Exception)
            {
                //Mesaj Publish Edilemedi. Dbye Kayıt Üretilebilir, Hangfire tarafından scheduler tetiklenebilir
            }
            finally
            {
                this.DisposeConnection();
            }

        }



        private string GetOrchestratorEventName(OrchestratorEventType eventType)
        {
            return eventType switch
            {
                OrchestratorEventType.IdentityTestEvent => "IdentityTestEvent",
                OrchestratorEventType.UserTestEvent => "UserTestEvent",
                OrchestratorEventType.ChatTestEvent => "ChatTestEvent",
                OrchestratorEventType.NotificationTestEvent => "NotificationTestEvent",
            };
        }


        private void CheckConnection()
        {
            if(_connectionFactory == null || _connection == null || _channel == null || !_connection.IsOpen)
            {
                _connectionFactory = new ConnectionFactory() { Uri = new Uri(RabbitMQConstants.HostUri) };
                _connection = _connectionFactory.CreateConnection();
                _channel = _connection.CreateModel();
            }
        }


        private void DisposeConnection()
        {
            this._connection.Close();
            this._connection.Dispose();
            this._channel.Dispose();
            this._connectionFactory = null;
        }
    }
}
