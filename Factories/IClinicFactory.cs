using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Interfaces;

namespace MedicalAppointmentSystem.Factories;

public interface IClinicFactory
{
    MedicalService CreateService();
    INotificationService CreateNotificationService();
}