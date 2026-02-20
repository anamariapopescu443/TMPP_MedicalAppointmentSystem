namespace MedicalAppointmentSystem.Services;

using MedicalAppointmentSystem.Interfaces;
using MedicalAppointmentSystem.Models;

public class AppointmentService
{
    private readonly IAppointmentRepository _repository;
    private readonly INotificationService _notification;

    public AppointmentService(IAppointmentRepository repository,
                              INotificationService notification)
    {
        _repository = repository;
        _notification = notification;
    }

    public void CreateAppointment(Appointment appointment)
    {
        _repository.Add(appointment);
        _notification.Send("Appointment created successfully.");
    }
}