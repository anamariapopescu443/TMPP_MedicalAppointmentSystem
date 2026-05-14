using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Strategy;

public class AllAppointmentsStrategy : IAppointmentFilterStrategy
{
    public IEnumerable<Appointment> Filter(IEnumerable<Appointment> appointments)
    {
        return appointments;
    }
}