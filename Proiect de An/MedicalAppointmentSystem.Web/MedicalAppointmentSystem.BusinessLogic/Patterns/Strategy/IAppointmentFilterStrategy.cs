using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Strategy;

public interface IAppointmentFilterStrategy
{
    IEnumerable<Appointment> Filter(IEnumerable<Appointment> appointments);
}