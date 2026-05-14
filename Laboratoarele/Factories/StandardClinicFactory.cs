using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Services;
using MedicalAppointmentSystem.Interfaces;

namespace MedicalAppointmentSystem.Factories;

public class StandardClinicFactory : IClinicFactory
{
    public MedicalService CreateService()
    {
        return new Consultation();
    }

    public INotificationService CreateNotificationService()
    {
        return new EmailNotificationService();
    }
}