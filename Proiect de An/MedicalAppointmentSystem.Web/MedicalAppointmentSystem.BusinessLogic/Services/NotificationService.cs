using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.DataAccess.Repositories;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<List<Notification>> GetNotificationsForPatientAsync(int patientId)
    {
        return await _notificationRepository.GetByPatientIdAsync(patientId);
    }
}