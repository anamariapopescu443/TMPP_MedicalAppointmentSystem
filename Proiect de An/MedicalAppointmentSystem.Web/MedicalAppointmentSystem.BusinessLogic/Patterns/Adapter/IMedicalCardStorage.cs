namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Adapter;

public interface IMedicalCardStorage
{
    Task<string> SaveMedicalCardAsync(Stream fileStream, string fileName, string contentType);
}