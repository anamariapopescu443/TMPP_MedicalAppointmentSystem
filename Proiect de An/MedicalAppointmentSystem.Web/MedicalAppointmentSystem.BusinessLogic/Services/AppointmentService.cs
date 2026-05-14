using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.DataAccess.Repositories;
using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;
using MedicalAppointmentSystem.BusinessLogic.Patterns.State;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Observer;

namespace MedicalAppointmentSystem.BusinessLogic.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    private readonly INotificationRepository _notificationRepository;

    public AppointmentService(
        IAppointmentRepository appointmentRepository,
        INotificationRepository notificationRepository)
    {
        _appointmentRepository = appointmentRepository;
        _notificationRepository = notificationRepository;
    }

    public async Task<List<Appointment>> GetAllAppointmentsAsync()
    {
        return await _appointmentRepository.GetAllAsync();
    }

    public async Task<Appointment?> GetAppointmentByIdAsync(int id)
    {
        return await _appointmentRepository.GetByIdAsync(id);
    }

    public async Task CreateAppointmentAsync(Appointment appointment)
    {
        appointment.Status = AppointmentStatus.Pending;
        appointment.CreatedAt = DateTime.Now;

        await _appointmentRepository.CreateAsync(appointment);
    }

    public async Task UpdateAppointmentAsync(Appointment appointment)
    {
        await _appointmentRepository.UpdateAsync(appointment);
    }

    public async Task DeleteAppointmentAsync(int id)
    {
        await _appointmentRepository.DeleteAsync(id);
    }

    public async Task ConfirmAppointmentAsync(int appointmentId, int doctorId)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);

        if (appointment == null)
        {
            throw new Exception("Appointment not found.");
        }

        if (appointment.DoctorId != doctorId)
        {
            throw new Exception("You do not have access to this appointment.");
        }

        var state = AppointmentStateFactory.Create(appointment.Status);
        state.Confirm(appointment);

        await _appointmentRepository.UpdateAsync(appointment);

        var subject = new AppointmentSubject();
        subject.Attach(new PatientNotificationObserver(_notificationRepository));

        await subject.NotifyAsync(
            appointment,
            $"Your appointment was confirmed. Doctor comment: {appointment.DoctorComment}");
    }

    public async Task DeclineAppointmentAsync(int appointmentId, int doctorId, string declineReason)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);

        if (appointment == null)
        {
            throw new Exception("Appointment not found.");
        }

        if (appointment.DoctorId != doctorId)
        {
            throw new Exception("You do not have access to this appointment.");
        }

        var state = AppointmentStateFactory.Create(appointment.Status);
        state.Decline(appointment, declineReason);

        await _appointmentRepository.UpdateAsync(appointment);

        var subject = new AppointmentSubject();
        subject.Attach(new PatientNotificationObserver(_notificationRepository));

        await subject.NotifyAsync(
            appointment,
            $"Your appointment was declined. Reason: {appointment.DeclineReason}");
    }

    public async Task CompleteAppointmentAsync(int appointmentId, int doctorId, string doctorComment)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);

        if (appointment == null)
        {
            throw new Exception("Appointment not found.");
        }

        if (appointment.DoctorId != doctorId)
        {
            throw new Exception("You do not have access to this appointment.");
        }

        var state = AppointmentStateFactory.Create(appointment.Status);
        state.Complete(appointment, doctorComment);

        await _appointmentRepository.UpdateAsync(appointment);

        var subject = new AppointmentSubject();
        subject.Attach(new PatientNotificationObserver(_notificationRepository));

        await subject.NotifyAsync(
            appointment,
            $"Your appointment was completed. Doctor comment: {appointment.DoctorComment}");
    }
}