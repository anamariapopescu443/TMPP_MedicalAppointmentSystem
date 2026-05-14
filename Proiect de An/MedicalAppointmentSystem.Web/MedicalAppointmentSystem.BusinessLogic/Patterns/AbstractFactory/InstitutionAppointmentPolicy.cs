namespace MedicalAppointmentSystem.BusinessLogic.Patterns.AbstractFactory;

public class InstitutionAppointmentPolicy
{
    public string InstitutionCategory { get; set; } = string.Empty;

    public string ConfirmationRule { get; set; } = string.Empty;

    public string PricingRule { get; set; } = string.Empty;

    public int PriorityLevel { get; set; }

    public string Description { get; set; } = string.Empty;
}