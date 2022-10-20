// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitService;

RabbitMessagingService messagingService = new RabbitMessagingService();
IConnection connection = messagingService.GetConnection();
IModel model = connection.CreateModel();
messagingService.ReceiveMessage(model);
