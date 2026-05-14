namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Adapter;

public class MedicalCardStorageAdapter : IMedicalCardStorage
{
    private readonly LocalFileStorageService _localFileStorageService;

    public MedicalCardStorageAdapter(LocalFileStorageService localFileStorageService)
    {
        _localFileStorageService = localFileStorageService;
    }

    public async Task<string> SaveMedicalCardAsync(Stream fileStream, string fileName, string contentType)
    {
        var allowedTypes = new[]
        {
            "application/pdf",
            "image/jpeg",
            "image/png"
        };

        if (!allowedTypes.Contains(contentType))
        {
            throw new InvalidOperationException("Only PDF, JPG and PNG files are allowed.");
        }

        return await _localFileStorageService.SaveFileAsync(
            fileStream,
            "medical-cards",
            fileName);
    }
}