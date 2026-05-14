namespace MedicalAppointmentSystem.Strategy
{
    public class EmailStrategy : INotificationStrategy
    {
        public void Send(string message)
        {
            Console.WriteLine("Email: " + message);
        }
    }
}