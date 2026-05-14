namespace MedicalAppointmentSystem.Domain.Models;

public class Patient
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string IDNP { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string? MedicalCardFilePath { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}