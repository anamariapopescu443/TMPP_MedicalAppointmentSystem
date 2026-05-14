namespace MedicalAppointmentSystem.BusinessLogic.Patterns.AbstractFactory;

public class PrivateClinicFactory : IMedicalInstitutionFactory
{
    public InstitutionAppointmentPolicy CreateAppointmentPolicy()
    {
        return new InstitutionAppointmentPolicy
        {
            InstitutionCategory = "Private Clinic",
            ConfirmationRule = "Faster confirmation for private clinic appointments.",
            PricingRule = "Premium pricing policy.",
            PriorityLevel = 2,
            Description = "Private clinics use faster confirmation and premium service rules."
        };
    }
}