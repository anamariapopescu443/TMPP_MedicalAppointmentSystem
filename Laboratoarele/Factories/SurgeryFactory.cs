using MedicalAppointmentSystem.Models;

namespace MedicalAppointmentSystem.Factories;

public class SurgeryFactory : MedicalServiceFactory
{
    public override MedicalService CreateService()
    {
        return new Surgery();
    }
}