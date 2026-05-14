namespace MedicalAppointmentSystem.Decorator
{
    public class EmailDecorator : NotificationDecorator
    {
        public EmailDecorator(INotificationComponent notification)
            : base(notification)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("Email notification added: " + message);
        }
    }
}