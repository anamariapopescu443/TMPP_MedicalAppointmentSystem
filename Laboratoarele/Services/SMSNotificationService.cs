using MedicalAppointmentSystem.Interfaces;

namespace MedicalAppointmentSystem.Services
{
    public class SMSNotificationService : INotificationService
    {
        public void Send(string message)   
        {
            Console.WriteLine("SMS sent: " + message);
        }
    }
}