using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.FactoryMethod;

public class OnlineAppointmentFactory : IAppointmentFactory
{
    public Appointment CreateAppointment(Appointment appointment)
    {
        appointment.Type = AppointmentType.Online;
        appointment.Status = AppointmentStatus.Pending;
        appointment.DoctorComment = "Online appointment request created.";

        return appointment;
    }
}