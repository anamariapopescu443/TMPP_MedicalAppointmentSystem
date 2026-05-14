using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.FactoryMethod;

public class FollowUpAppointmentFactory : IAppointmentFactory
{
    public Appointment CreateAppointment(Appointment appointment)
    {
        appointment.Type = AppointmentType.FollowUp;
        appointment.Status = AppointmentStatus.Pending;
        appointment.DoctorComment = "Follow-up appointment request created.";

        return appointment;
    }
}