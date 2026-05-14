using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.FactoryMethod;

public class StandardAppointmentFactory : IAppointmentFactory
{
    public Appointment CreateAppointment(Appointment appointment)
    {
        appointment.Type = AppointmentType.Standard;
        appointment.Status = AppointmentStatus.Pending;
        appointment.DoctorComment = "Standard appointment request created.";

        return appointment;
    }
}