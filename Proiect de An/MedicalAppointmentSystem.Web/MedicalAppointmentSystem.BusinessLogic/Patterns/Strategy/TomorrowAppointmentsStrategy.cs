using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Strategy;

public class TomorrowAppointmentsStrategy : IAppointmentFilterStrategy
{
    public IEnumerable<Appointment> Filter(IEnumerable<Appointment> appointments)
    {
        var tomorrow = DateTime.Today.AddDays(1);

        return appointments.Where(a => a.AppointmentDate.Date == tomorrow);
    }
}