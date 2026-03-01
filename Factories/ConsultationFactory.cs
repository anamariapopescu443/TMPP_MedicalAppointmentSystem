using MedicalAppointmentSystem.Models;

namespace MedicalAppointmentSystem.Factories;

public class ConsultationFactory : MedicalServiceFactory
{
    public override MedicalService CreateService()
    {
        return new Consultation();
    }
}