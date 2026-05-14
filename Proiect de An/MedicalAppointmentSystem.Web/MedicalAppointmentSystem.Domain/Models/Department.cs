namespace MedicalAppointmentSystem.Domain.Models;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int HospitalId { get; set; }
    public Hospital? Hospital { get; set; }

    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public ICollection<MedicalService> MedicalServices { get; set; } = new List<MedicalService>();
}