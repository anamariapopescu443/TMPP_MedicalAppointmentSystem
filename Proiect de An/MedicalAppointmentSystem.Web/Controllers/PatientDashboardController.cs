using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentSystem.Web.Controllers;

public class PatientDashboardController : Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientProfileService _patientProfileService;

    public PatientDashboardController(
        IAppointmentService appointmentService,
        IPatientProfileService patientProfileService)
    {
        _appointmentService = appointmentService;
        _patientProfileService = patientProfileService;
    }

    public async Task<IActionResult> Index()
    {
        var role = HttpContext.Session.GetString("UserRole");
        var patientId = HttpContext.Session.GetInt32("UserId");

        if (role != "Patient" || patientId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var patient = await _patientProfileService.GetPatientByIdAsync(patientId.Value);

        if (patient == null)
        {
            return NotFound();
        }

        var allAppointments = await _appointmentService.GetAllAppointmentsAsync();

        var patientAppointments = allAppointments
            .Where(a => a.PatientId == patientId.Value)
            .OrderByDescending(a => a.AppointmentDate)
            .ToList();

        var nextAppointment = patientAppointments
            .Where(a => a.AppointmentDate >= DateTime.Now &&
                        a.Status != AppointmentStatus.Declined &&
                        a.Status != AppointmentStatus.Cancelled &&
                        a.Status != AppointmentStatus.Completed)
            .OrderBy(a => a.AppointmentDate)
            .FirstOrDefault();

        var lastCompletedAppointment = patientAppointments
            .Where(a => a.Status == AppointmentStatus.Completed)
            .OrderByDescending(a => a.CompletedAt ?? a.AppointmentDate)
            .FirstOrDefault();

        ViewBag.FullName = patient.FullName;

        ViewBag.TotalAppointments = patientAppointments.Count;
        ViewBag.PendingAppointments = patientAppointments.Count(a => a.Status == AppointmentStatus.Pending);
        ViewBag.ConfirmedAppointments = patientAppointments.Count(a => a.Status == AppointmentStatus.Confirmed);
        ViewBag.CompletedAppointments = patientAppointments.Count(a => a.Status == AppointmentStatus.Completed);

        ViewBag.NextAppointment = nextAppointment;
        ViewBag.LastCompletedAppointment = lastCompletedAppointment;
        ViewBag.HasMedicalCard = !string.IsNullOrEmpty(patient.MedicalCardFilePath);

        return View();
    }
}