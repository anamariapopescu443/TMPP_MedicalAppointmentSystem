using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.FactoryMethod;

public interface IAppointmentFactory
{
    Appointment CreateAppointment(Appointment appointment);
}