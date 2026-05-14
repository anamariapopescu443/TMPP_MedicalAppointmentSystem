namespace MedicalAppointmentSystem.Bridge
{
    public class SMSChannel : INotificationChannel
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS channel: " + message);
        }
    }
}