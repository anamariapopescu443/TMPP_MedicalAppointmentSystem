namespace MedicalAppointmentSystem.Domain.Models;

public class Notification
{
    public int Id { get; set; }

    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    public int AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool IsRead { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}