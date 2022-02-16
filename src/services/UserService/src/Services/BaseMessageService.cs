using RabbitMQ.Client;
using System.Text;

namespace user_service.Services
{
    public abstract class BaseMessageService : IMessageService
    {
        private ConnectionFactory _factory;
        private IConnection _conn;
        private IModel _channel;

        public enum MessageType
        {
            POST,
            PUT,
            DELETE,
        }

        public BaseMessageService(string hostName, int port, string queueName)
        {
            _factory = new ConnectionFactory() { HostName = hostName, Port = port};
            _factory.UserName = "guest";
            _factory.Password = "guest";
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
        }

        public virtual bool Enqueue(string messageString, MessageType messageType)
        {
            var body = Encoding.UTF8.GetBytes("server processed " + messageString);
            _channel.BasicPublish(exchange: "",
                                routingKey: "hello",
                                basicProperties: null,
                                body: body);
            Console.WriteLine(" [x] Published {0} to RabbitMQ", messageString);
            return true;
        }
    }
}
