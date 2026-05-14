namespace MedicalAppointmentSystem.Bridge
{
    public class EmailChannel : INotificationChannel
    {
        public void Send(string message)
        {
            Console.WriteLine("Email channel: " + message);
        }
    }
}