using Single_Responsibility_Principle.After;
using System.Net.Mail;

namespace Single_Responsibility_Principle.After
{
    public interface INotificatoin
    {
        void Send(string message, string receiveAddress);
    }
    public class NotificationEmailService : INotificatoin
    {
        public void Send(string message, string receiveAddress)
        {
            HttpClient client = new HttpClient();
            client.Send(new HttpRequestMessage { });
        }
    }

    public class NotificationSmsService : INotificatoin
    {
        public void Send(string message, string receiveAddress)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = ""
            };
            smtpClient.Send(new MailMessage(message, receiveAddress));
        }
    }

}

public class OrderProcessor
{
    private readonly INotificatoin _smsService;
    private readonly INotificatoin _emailService;
    public OrderProcessor()
    {
        _smsService = new NotificationSmsService();
        _emailService = new NotificationEmailService();
    }
    public void ProccesOrder(int quantity, string item, string phoneNumber, string emailAddress)
    {
        //implement business logic 

        _smsService.Send($"your order for {quantity} {item} has been processed", phoneNumber);
        _emailService.Send($"your order for {quantity} {item} has been processed", emailAddress);
    }
}
