using MedicalAppointmentSystem.DataAccess.Repositories;
using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Prototype;

public class AppointmentPrototypeService : IAppointmentPrototypeService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentPrototypeService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Appointment> CreateFollowUpFromExistingAsync(
        int appointmentId,
        int doctorId,
        DateTime followUpDate)
    {
        var originalAppointment = await _appointmentRepository.GetByIdAsync(appointmentId);

        if (originalAppointment == null)
        {
            throw new Exception("Original appointment not found.");
        }

        if (originalAppointment.DoctorId != doctorId)
        {
            throw new Exception("You do not have access to this appointment.");
        }

        if (originalAppointment.Status != AppointmentStatus.Completed)
        {
            throw new Exception("Follow-up can be created only from completed appointments.");
        }

        var followUpAppointment = originalAppointment.CloneAsFollowUp(followUpDate);

        await _appointmentRepository.CreateAsync(followUpAppointment);

        return followUpAppointment;
    }
}