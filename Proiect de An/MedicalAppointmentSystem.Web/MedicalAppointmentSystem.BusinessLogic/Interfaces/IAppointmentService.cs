using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Interfaces;

public interface IAppointmentService
{
    Task<List<Appointment>> GetAllAppointmentsAsync();
    Task<Appointment?> GetAppointmentByIdAsync(int id);
    Task CreateAppointmentAsync(Appointment appointment);
    Task UpdateAppointmentAsync(Appointment appointment);
    Task DeleteAppointmentAsync(int id);

    Task ConfirmAppointmentAsync(int appointmentId, int doctorId);
    Task DeclineAppointmentAsync(int appointmentId, int doctorId, string declineReason);
    Task CompleteAppointmentAsync(int appointmentId, int doctorId, string doctorComment);
}