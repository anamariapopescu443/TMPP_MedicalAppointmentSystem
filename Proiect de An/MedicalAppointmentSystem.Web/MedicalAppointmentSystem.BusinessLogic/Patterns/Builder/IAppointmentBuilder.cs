using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Builder;

public interface IAppointmentBuilder
{
    IAppointmentBuilder WithPatient(int patientId);
    IAppointmentBuilder WithHospital(int hospitalId);
    IAppointmentBuilder WithDepartment(int departmentId);
    IAppointmentBuilder WithDoctor(int doctorId);
    IAppointmentBuilder WithMedicalService(int medicalServiceId);
    IAppointmentBuilder WithDate(DateTime appointmentDate);
    IAppointmentBuilder WithReason(string reason);
    IAppointmentBuilder WithType(AppointmentType type);

    Appointment Build();
}