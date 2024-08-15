using System.Net.Mail;

namespace Single_Responsibility_Principle.Before
{
    //befor using Solid Principle
    public class NotificationService
    {
        public void SendEmailNotification(string message, string emailAddress)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = ""
            };
            smtpClient.Send(new MailMessage(message, emailAddress));

        }

        public void SendSmsNotification(string message, string phoneNumber)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Send(new HttpRequestMessage { });
        }

    }

    public class OrderProcessor
    {
        private readonly NotificationService _notificationService;

        public OrderProcessor() => _notificationService = new NotificationService();

        public void ProcessOrder(int quantity, string item, string phoneNumber, string emailAddress)
        {
            //implement business logic 

            _notificationService.SendSmsNotification($"your order for {quantity} {item} has been processed", phoneNumber);
            _notificationService.SendEmailNotification($"your order for {quantity} {item} has been processed", emailAddress);
        }

    }
}

