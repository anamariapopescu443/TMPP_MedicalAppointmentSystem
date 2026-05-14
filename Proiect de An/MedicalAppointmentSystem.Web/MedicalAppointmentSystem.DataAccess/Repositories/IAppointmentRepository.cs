using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.DataAccess.Repositories;

public interface IAppointmentRepository
{
    Task<List<Appointment>> GetAllAsync();
    Task<Appointment?> GetByIdAsync(int id);
    Task CreateAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(int id);
}