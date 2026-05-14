using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Interfaces;

public interface INotificationService
{
    Task<List<Notification>> GetNotificationsForPatientAsync(int patientId);
}