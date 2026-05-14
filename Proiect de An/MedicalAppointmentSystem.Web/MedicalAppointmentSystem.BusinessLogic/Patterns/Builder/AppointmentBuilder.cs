using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Builder;

public class AppointmentBuilder : IAppointmentBuilder
{
    private readonly Appointment _appointment = new();

    public IAppointmentBuilder WithPatient(int patientId)
    {
        _appointment.PatientId = patientId;
        return this;
    }

    public IAppointmentBuilder WithHospital(int hospitalId)
    {
        _appointment.HospitalId = hospitalId;
        return this;
    }

    public IAppointmentBuilder WithDepartment(int departmentId)
    {
        _appointment.DepartmentId = departmentId;
        return this;
    }

    public IAppointmentBuilder WithDoctor(int doctorId)
    {
        _appointment.DoctorId = doctorId;
        return this;
    }

    public IAppointmentBuilder WithMedicalService(int medicalServiceId)
    {
        _appointment.MedicalServiceId = medicalServiceId;
        return this;
    }

    public IAppointmentBuilder WithDate(DateTime appointmentDate)
    {
        _appointment.AppointmentDate = appointmentDate;
        return this;
    }

    public IAppointmentBuilder WithReason(string reason)
    {
        _appointment.Reason = reason;
        return this;
    }

    public IAppointmentBuilder WithType(AppointmentType type)
    {
        _appointment.Type = type;
        return this;
    }

    public Appointment Build()
    {
        _appointment.Status = AppointmentStatus.Pending;
        _appointment.CreatedAt = DateTime.Now;

        return _appointment;
    }
}