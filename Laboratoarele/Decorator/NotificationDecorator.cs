namespace MedicalAppointmentSystem.Decorator
{
    public abstract class NotificationDecorator : INotificationComponent
    {
        protected readonly INotificationComponent _notification;

        protected NotificationDecorator(INotificationComponent notification)
        {
            _notification = notification;
        }

        public virtual void Send(string message)
        {
            _notification.Send(message);
        }
    }
}