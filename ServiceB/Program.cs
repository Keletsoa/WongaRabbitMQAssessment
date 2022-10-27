// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitService;

RabbitMessagingService messagingService = new RabbitMessagingService();
IConnection connection = messagingService.GetConnection();
IModel model = connection.CreateModel();
var message = messagingService.ReceiveMessage(model);

Console.WriteLine("Hello {0}, I am your father!", message);
Console.ReadKey();