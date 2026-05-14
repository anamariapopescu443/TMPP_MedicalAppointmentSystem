namespace MedicalAppointmentSystem.BusinessLogic.Patterns.AbstractFactory;

public class DiagnosticCenterFactory : IMedicalInstitutionFactory
{
    public InstitutionAppointmentPolicy CreateAppointmentPolicy()
    {
        return new InstitutionAppointmentPolicy
        {
            InstitutionCategory = "Diagnostic Center",
            ConfirmationRule = "Appointment focused on investigations and diagnostic services.",
            PricingRule = "Diagnostic service pricing policy.",
            PriorityLevel = 1,
            Description = "Diagnostic centers focus on investigation-based appointments."
        };
    }
}