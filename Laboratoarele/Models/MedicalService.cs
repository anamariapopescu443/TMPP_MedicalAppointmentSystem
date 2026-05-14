namespace MedicalAppointmentSystem.Models;

public abstract class MedicalService
{
    public string ServiceName { get; protected set; } = string.Empty;

    public abstract decimal GetPrice();
}