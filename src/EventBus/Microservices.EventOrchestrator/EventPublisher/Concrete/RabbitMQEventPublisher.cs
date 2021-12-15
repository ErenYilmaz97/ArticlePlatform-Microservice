using Microservices.EventOrchestrator.Constant;
using Microservices.EventOrchestrator.EventBusResult;
using Microservices.EventOrchestrator.EventPublisher.Abstract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Microservices.EventOrchestrator.EventPublisher.Concrete
{
    internal class RabbitMQEventPublisher : IEventPublisher
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQEventPublisher()
        {
            this.CreateConnection();
        }

        public IEventBusResult PublishArticleEvent<TEvent>(string messageName, TEvent @event)
        {
            //Create Connection If It Not Exist
            this.CheckConnection();

            _channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: RabbitMQConstants.ArticleEventsQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: RabbitMQConstants.ArticleEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.ArticleQueueBindKey);

            string messageRouteKey = "ArticleService.Events." + messageName;
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            var messageProperty = _channel.CreateBasicProperties();
            messageProperty.Persistent = true;

            try
            {
                _channel.BasicPublish(exchange: RabbitMQConstants.ExchangeName, routingKey: messageRouteKey, basicProperties: messageProperty, body: messageBody);
                return new SuccessEventBusResult();
            }

            catch (Exception ex)
            {
                return new SuccessEventBusResult($"{messageName} Mesajı Publish Edilemedi.");
            }
            finally
            {
                this.DisposeConnection();
            }
        }


        public IEventBusResult PublishChatEvent<TEvent>(string messageName, TEvent @event)
        {
            //Create Connection If It Not Exist
            this.CheckConnection();

            _channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: RabbitMQConstants.ChatEventsQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: RabbitMQConstants.ChatEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.ChatQueueBindKey);

            string messageRouteKey = "ChatService.Events." + messageName;
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            var messageProperty = _channel.CreateBasicProperties();
            messageProperty.Persistent = true;

            try
            {
                _channel.BasicPublish(exchange: RabbitMQConstants.ExchangeName, routingKey: messageRouteKey, basicProperties: messageProperty, body: messageBody);
                return new SuccessEventBusResult();
            }

            catch (Exception ex)
            {
                return new SuccessEventBusResult($"{messageName} Mesajı Publish Edilemedi.");
            }

            finally
            {
                this.DisposeConnection();
            }
        }


        public IEventBusResult PublishFavoriteEvent<TEvent>(string messageName, TEvent @event)
        {
            //Create Connection If It Not Exist
            this.CheckConnection();

            _channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: RabbitMQConstants.FavoriteEventsQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: RabbitMQConstants.FavoriteEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.FavoriteQueueBindKey);

            string messageRouteKey = "FavoriteService.Events." + messageName;
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            var messageProperty = _channel.CreateBasicProperties();
            messageProperty.Persistent = true;

            try
            {
                _channel.BasicPublish(exchange: RabbitMQConstants.ExchangeName, routingKey: messageRouteKey, basicProperties: messageProperty, body: messageBody);
                return new SuccessEventBusResult();
            }

            catch (Exception ex)
            {
                return new SuccessEventBusResult($"{messageName} Mesajı Publish Edilemedi.");
            }

            finally
            {
                this.DisposeConnection();
            }
        }


        public IEventBusResult PublishForumEvent<TEvent>(string messageName, TEvent @event)
        {
            //Create Connection If It Not Exist
            this.CheckConnection();

            _channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: RabbitMQConstants.ForumEventsQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: RabbitMQConstants.ForumEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.ForumQueueBindKey);

            string messageRouteKey = "ForumService.Events." + messageName;
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            var messageProperty = _channel.CreateBasicProperties();
            messageProperty.Persistent = true;

            try
            {
                _channel.BasicPublish(exchange: RabbitMQConstants.ExchangeName, routingKey: messageRouteKey, basicProperties: messageProperty, body: messageBody);
                return new SuccessEventBusResult();
            }

            catch (Exception ex)
            {
                return new SuccessEventBusResult($"{messageName} Mesajı Publish Edilemedi.");
            }

            finally
            {
                this.DisposeConnection();
            }
        }


        public IEventBusResult PublishIdentityEvent<TEvent>(string messageName, TEvent @event)
        {
            //Create Connection If It Not Exist
            this.CheckConnection();

            _channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: RabbitMQConstants.IdentityEventsQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: RabbitMQConstants.IdentityEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.IdentityQueueBindKey);

            string messageRouteKey = "IdentityService.Events." + messageName;
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            var messageProperty = _channel.CreateBasicProperties();
            messageProperty.Persistent = true;

            try
            {
                _channel.BasicPublish(exchange: RabbitMQConstants.ExchangeName, routingKey: messageRouteKey, basicProperties: messageProperty, body: messageBody);
                return new SuccessEventBusResult();
            }

            catch (Exception ex)
            {
                return new SuccessEventBusResult($"{messageName} Mesajı Publish Edilemedi.");
            }

            finally
            {
                this.DisposeConnection();
            }
        }


        public IEventBusResult PublishNotificationEvent<TEvent>(string messageName, TEvent @event)
        {
            //Create Connection If It Not Exist
            this.CheckConnection();

            _channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: RabbitMQConstants.NotificationEventsQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: RabbitMQConstants.NotificationEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.NotificationQueueBindKey);

            string messageRouteKey = "NotificationService.Events." + messageName;
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            var messageProperty = _channel.CreateBasicProperties();
            messageProperty.Persistent = true;

            try
            {
                _channel.BasicPublish(exchange: RabbitMQConstants.ExchangeName, routingKey: messageRouteKey, basicProperties: messageProperty, body: messageBody);
                return new SuccessEventBusResult();
            }

            catch (Exception ex)
            {
                return new SuccessEventBusResult($"{messageName} Mesajı Publish Edilemedi.");
            }

            finally
            {
                this.DisposeConnection();
            }
        }


        public IEventBusResult PublishUserEvent<TEvent>(string messageName, TEvent @event)
        {
            //Create Connection If It Not Exist
            this.CheckConnection();

            _channel.ExchangeDeclare(exchange: RabbitMQConstants.ExchangeName, type: ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(queue: RabbitMQConstants.UserEventsQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: RabbitMQConstants.UserEventsQueueName, exchange: RabbitMQConstants.ExchangeName, routingKey: RabbitMQConstants.UserQueueBindKey);

            string messageRouteKey = "UserService.Events." + messageName;
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            var messageProperty = _channel.CreateBasicProperties();
            messageProperty.Persistent = true;

            try
            {
                _channel.BasicPublish(exchange: RabbitMQConstants.ExchangeName, routingKey: messageRouteKey, basicProperties: messageProperty, body: messageBody);
                return new SuccessEventBusResult();
            }

            catch (Exception ex)
            {
                return new SuccessEventBusResult($"{messageName} Mesajı Publish Edilemedi.");
            }

            finally
            {
                this.DisposeConnection();
            }
        }


        private void CreateConnection()
        {
            if (_connectionFactory == null || _connection == null || _channel == null || !_connection.IsOpen)
            {
                _connectionFactory = new ConnectionFactory();
                _connectionFactory.Uri = new Uri(RabbitMQConstants.HostUri);
                _connection = _connectionFactory.CreateConnection();
                _channel = _connection.CreateModel();
            }
        }

        private void CheckConnection()
        {
            if (_connectionFactory == null || _connection == null || _channel == null || !_connection.IsOpen)
            {
                this.CreateConnection();
            }
        }

        public void Dispose()
        {
            this._connectionFactory = null;
            this._connection.Close();
            this._connection = null;
            this._channel = null;
        }

        public void DisposeConnection()
        {
            this._connection.Close();
            this._connection.Dispose();
            this._channel.Dispose();
        }
    }
}
