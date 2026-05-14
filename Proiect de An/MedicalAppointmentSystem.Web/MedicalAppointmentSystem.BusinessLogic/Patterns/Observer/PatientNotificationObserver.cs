using MedicalAppointmentSystem.DataAccess.Repositories;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Observer;

public class PatientNotificationObserver : IAppointmentObserver
{
    private readonly INotificationRepository _notificationRepository;

    public PatientNotificationObserver(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task UpdateAsync(Appointment appointment, string eventMessage)
    {
        var notification = new Notification
        {
            PatientId = appointment.PatientId,
            AppointmentId = appointment.Id,
            Message = eventMessage,
            IsRead = false,
            CreatedAt = DateTime.Now
        };

        await _notificationRepository.CreateAsync(notification);
    }
}