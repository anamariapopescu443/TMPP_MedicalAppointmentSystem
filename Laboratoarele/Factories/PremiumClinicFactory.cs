using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Services;
using MedicalAppointmentSystem.Interfaces;

namespace MedicalAppointmentSystem.Factories;

public class PremiumClinicFactory : IClinicFactory
{
    public MedicalService CreateService()
    {
        return new Surgery();
    }

    public INotificationService CreateNotificationService()
    {
        return new SMSNotificationService();
    }
}