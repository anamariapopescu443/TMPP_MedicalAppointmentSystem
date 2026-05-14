using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Proxy;

public interface IAppointmentAccessProxy
{
    Task<List<Appointment>> GetAppointmentsForUserAsync(string role, int userId);
}