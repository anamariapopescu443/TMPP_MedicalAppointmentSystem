using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Interfaces;

public interface IAuthService
{
    Task<(bool Success, string Role, int UserId, string FullName, string Error)> LoginAsync(
        string email,
        string password);

    Task<(bool Success, string Error)> RegisterPatientAsync(Patient patient);

    Task<(bool Success, string Error)> RegisterDoctorAsync(Doctor doctor);
}