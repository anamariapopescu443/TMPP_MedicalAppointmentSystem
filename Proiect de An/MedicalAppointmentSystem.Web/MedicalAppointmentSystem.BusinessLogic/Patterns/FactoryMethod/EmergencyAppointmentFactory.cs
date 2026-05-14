using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.FactoryMethod;

public class EmergencyAppointmentFactory : IAppointmentFactory
{
    public Appointment CreateAppointment(Appointment appointment)
    {
        appointment.Type = AppointmentType.Emergency;
        appointment.Status = AppointmentStatus.Pending;
        appointment.DoctorComment = "Emergency appointment request created. High priority.";

        return appointment;
    }
}