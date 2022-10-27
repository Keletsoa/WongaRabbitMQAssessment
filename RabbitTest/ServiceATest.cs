using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using RabbitService;

namespace RabbitTest
{
    public class ServiceATest
    {
        [Fact]
        public void TestPass()
        {
            var messagingService = new RabbitMessagingService();
            var connection = messagingService.GetConnection();
            var model = connection.CreateModel();

            messagingService.SendMessage("Keletso", model);
            var message = messagingService.ReceiveMessage(model);
            Assert.Equal("Keletso", message);
            //Assert.NotEqual("Wonga", message);
        }

        [Fact]
        public void TestFail()
        {
            var messagingService = new RabbitMessagingService();
            var connection = messagingService.GetConnection();
            var model = connection.CreateModel();

            messagingService.SendMessage("Keletso", model);
            var message = messagingService.ReceiveMessage(model);
            Assert.Equal("Wonga", message);
            //Assert.NotEqual("Wonga", message);
        }
    }
}