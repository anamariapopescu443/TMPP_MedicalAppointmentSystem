using MedicalAppointmentSystem.Domain.Enums;

namespace MedicalAppointmentSystem.Domain.Models;

public class Appointment
{
    public int Id { get; set; }

    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    public int HospitalId { get; set; }
    public Hospital? Hospital { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    public int MedicalServiceId { get; set; }
    public MedicalService? MedicalService { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Reason { get; set; } = string.Empty;

    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

    public AppointmentType Type { get; set; } = AppointmentType.Standard;

    public string? DeclineReason { get; set; }

    public string? DoctorComment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? CompletedAt { get; set; }

    public Appointment CloneAsFollowUp(DateTime newDate)
    {
        return new Appointment
        {
            PatientId = this.PatientId,
            HospitalId = this.HospitalId,
            DepartmentId = this.DepartmentId,
            DoctorId = this.DoctorId,
            MedicalServiceId = this.MedicalServiceId,
            AppointmentDate = newDate,
            Reason = $"Follow-up for previous appointment: {this.Reason}",
            Status = AppointmentStatus.Pending,
            Type = AppointmentType.FollowUp,
            CreatedAt = DateTime.Now,
            DoctorComment = "Follow-up appointment created from previous appointment."
        };
    }
}