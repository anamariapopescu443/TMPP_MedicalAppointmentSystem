namespace MedicalAppointmentSystem.Decorator
{
    public class SMSDecorator : NotificationDecorator
    {
        public SMSDecorator(INotificationComponent notification)
            : base(notification)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("SMS notification added: " + message);
        }
    }
}