using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Strategy;

public class ConfirmedAppointmentsStrategy : IAppointmentFilterStrategy
{
    public IEnumerable<Appointment> Filter(IEnumerable<Appointment> appointments)
    {
        return appointments.Where(a => a.Status == AppointmentStatus.Confirmed);
    }
}