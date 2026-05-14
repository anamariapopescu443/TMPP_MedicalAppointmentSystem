namespace MedicalAppointmentSystem.Services;

using MedicalAppointmentSystem.Interfaces;

public class EmailNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}