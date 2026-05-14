namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Adapter;

public class LocalFileStorageService
{
    private readonly string _rootPath;

    public LocalFileStorageService(string rootPath)
    {
        _rootPath = rootPath;
    }

    public async Task<string> SaveFileAsync(Stream fileStream, string folderName, string fileName)
    {
        var uploadFolder = Path.Combine(_rootPath, "uploads", folderName);

        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }

        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var fullPath = Path.Combine(uploadFolder, uniqueFileName);

        using var outputStream = new FileStream(fullPath, FileMode.Create);
        await fileStream.CopyToAsync(outputStream);

        return $"/uploads/{folderName}/{uniqueFileName}";
    }
}