using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitService
{
    public class RabbitMessagingService
    {
        private string _hostName = "localhost";
        private string _userName = "guest";
        private string _password = "guest";
        private string _exchangeName = "";
        private string _queueName = "Wonga Communicator";
        private string _routinKey = "wongaRabbit";
        private bool _durable = false;
        private bool _exclusive = false;
        private bool _autoDelete = false;

        public IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = _hostName;
            //connectionFactory.UserName = _userName;
            //connectionFactory.Password = _password;

            return connectionFactory.CreateConnection();
        }

        public void SetUpQueue(IModel model)
        {
            model.QueueDeclare(_queueName, _durable, false, false, null);
        }

        public void SendMessage(string message, IModel model)
        {
            model.QueueDeclare(queue: _queueName,
                                durable: _durable,
                                exclusive: _exclusive,
                                autoDelete: _autoDelete,
                                arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            model.BasicPublish(exchange: _exchangeName,
                                routingKey: _routinKey,
                                basicProperties: null,
                                body: body);
        }

        public string ReceiveMessage(IModel model)
        {
            string msg = string.Empty;

            model.QueueDeclare(queue: _queueName,
                                durable: _durable,
                                exclusive: _exclusive,
                                autoDelete: _autoDelete,
                                arguments: null);

            var consumer = new EventingBasicConsumer(model);
            consumer.Received += (theModel, basicDeliverEventArgs) =>
            {
                var body = basicDeliverEventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                msg += message;
                //Console.WriteLine(, );
            };

            model.BasicConsume(queue: _queueName,
                                autoAck: true,
                                consumer: consumer);

            return msg;
            //Console.ReadKey();
        }
    }
}
