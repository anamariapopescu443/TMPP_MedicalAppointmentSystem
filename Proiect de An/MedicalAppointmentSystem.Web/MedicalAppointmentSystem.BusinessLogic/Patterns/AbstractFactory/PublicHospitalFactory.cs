namespace MedicalAppointmentSystem.BusinessLogic.Patterns.AbstractFactory;

public class PublicHospitalFactory : IMedicalInstitutionFactory
{
    public InstitutionAppointmentPolicy CreateAppointmentPolicy()
    {
        return new InstitutionAppointmentPolicy
        {
            InstitutionCategory = "Public Hospital",
            ConfirmationRule = "Standard confirmation by doctor.",
            PricingRule = "Standard public medical service pricing.",
            PriorityLevel = 1,
            Description = "Appointments in public hospitals follow standard confirmation and priority rules."
        };
    }
}