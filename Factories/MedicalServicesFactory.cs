using MedicalAppointmentSystem.Models;

namespace MedicalAppointmentSystem.Factories;

public abstract class MedicalServiceFactory
{
    public abstract MedicalService CreateService();
}