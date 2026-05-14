using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Observer;

public interface IAppointmentObserver
{
    Task UpdateAsync(Appointment appointment, string eventMessage);
}