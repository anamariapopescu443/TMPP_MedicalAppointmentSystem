using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Strategy;

public class TodayAppointmentsStrategy : IAppointmentFilterStrategy
{
    public IEnumerable<Appointment> Filter(IEnumerable<Appointment> appointments)
    {
        var today = DateTime.Today;

        return appointments.Where(a => a.AppointmentDate.Date == today);
    }
}