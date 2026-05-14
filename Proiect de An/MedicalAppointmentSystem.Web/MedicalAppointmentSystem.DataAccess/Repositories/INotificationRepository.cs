using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.DataAccess.Repositories;

public interface INotificationRepository
{
    Task CreateAsync(Notification notification);
    Task<List<Notification>> GetByPatientIdAsync(int patientId);
}