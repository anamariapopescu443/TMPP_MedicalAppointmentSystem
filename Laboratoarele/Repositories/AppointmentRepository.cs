namespace MedicalAppointmentSystem.Repositories;

using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Interfaces;

public class AppointmentRepository : IAppointmentRepository
{
    public void Add(Appointment appointment)
    {
        Console.WriteLine("Appointment saved to database.");
    }
}