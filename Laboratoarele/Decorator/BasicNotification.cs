namespace MedicalAppointmentSystem.Decorator
{
    public class BasicNotification : INotificationComponent
    {
        public void Send(string message)
        {
            Console.WriteLine("Basic notification: " + message);
        }
    }
}