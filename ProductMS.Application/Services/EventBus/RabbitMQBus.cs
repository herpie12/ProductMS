using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ProductMS.Application.Services.EventBus
{
    public class RabbitMQBus : IEventBus
    {
        public RabbitMQBus(IOptions<RabbitMQConfig> rabbitMqOptions)
        {

        }

        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;

                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);
            }
        }

        public class RabbitMQConfig
        {

            public readonly string Hostname;
            public readonly string Password;
            public readonly string QueueName;
            public readonly string Username;
            public IConnection Connection;
        }
    }
}

