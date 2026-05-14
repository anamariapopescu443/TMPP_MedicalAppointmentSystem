using MedicalAppointmentSystem.DataAccess.Repositories;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Proxy;

public class AppointmentAccessProxy : IAppointmentAccessProxy
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentAccessProxy(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<Appointment>> GetAppointmentsForUserAsync(string role, int userId)
    {
        var appointments = await _appointmentRepository.GetAllAsync();

        if (role == "Patient")
        {
            return appointments
                .Where(a => a.PatientId == userId)
                .ToList();
        }

        if (role == "Doctor")
        {
            return appointments
                .Where(a => a.DoctorId == userId)
                .ToList();
        }

        return new List<Appointment>();
    }
}