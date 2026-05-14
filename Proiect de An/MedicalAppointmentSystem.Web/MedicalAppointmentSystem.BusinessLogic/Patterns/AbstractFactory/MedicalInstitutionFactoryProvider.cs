using MedicalAppointmentSystem.Domain.Enums;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.AbstractFactory;

public static class MedicalInstitutionFactoryProvider
{
    public static IMedicalInstitutionFactory GetFactory(HospitalType hospitalType)
    {
        return hospitalType switch
        {
            HospitalType.PublicHospital => new PublicHospitalFactory(),
            HospitalType.PrivateClinic => new PrivateClinicFactory(),
            HospitalType.DiagnosticCenter => new DiagnosticCenterFactory(),
            _ => new PublicHospitalFactory()
        };
    }
}