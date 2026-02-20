namespace MedicalAppointmentSystem.Interfaces;

using MedicalAppointmentSystem.Models;

public interface IAppointmentRepository
{
    void Add(Appointment appointment);
}