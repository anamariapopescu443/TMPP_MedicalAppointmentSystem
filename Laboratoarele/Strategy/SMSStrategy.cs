namespace MedicalAppointmentSystem.Strategy
{
    public class SMSStrategy : INotificationStrategy
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS: " + message);
        }
    }
}