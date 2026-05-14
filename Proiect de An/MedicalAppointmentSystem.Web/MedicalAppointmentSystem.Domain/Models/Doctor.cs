namespace MedicalAppointmentSystem.Domain.Models;

public class Doctor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName => $"Dr. {FirstName} {LastName}";

    public string Specialization { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string IDNP { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public int HospitalId { get; set; }
    public Hospital? Hospital { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}