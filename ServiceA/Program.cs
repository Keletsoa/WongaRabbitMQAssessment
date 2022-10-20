// See https://aka.ms/new-console-template for more information
using RabbitService;

RabbitMessagingService messagingService = new RabbitMessagingService();
var connection = messagingService.GetConnection();
var model = connection.CreateModel();
//messagingService.SetUpQueue(model);

Console.WriteLine("Enter your name and press Enter. Quit with 'exit'.");
while (true)
{
    string message = Console.ReadLine();
    if (message.ToLower() == "exit") break;

    messagingService.SendMessage(message, model);
}

Console.ReadKey();