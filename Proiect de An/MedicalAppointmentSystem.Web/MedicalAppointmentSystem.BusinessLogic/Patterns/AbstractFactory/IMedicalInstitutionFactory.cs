namespace MedicalAppointmentSystem.BusinessLogic.Patterns.AbstractFactory;

public interface IMedicalInstitutionFactory
{
    InstitutionAppointmentPolicy CreateAppointmentPolicy();
}