using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentSystem.Web.Controllers;

public class DoctorDashboardController : Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly IDoctorProfileService _doctorProfileService;

    public DoctorDashboardController(
        IAppointmentService appointmentService,
        IDoctorProfileService doctorProfileService)
    {
        _appointmentService = appointmentService;
        _doctorProfileService = doctorProfileService;
    }

    public async Task<IActionResult> Index()
    {
        var role = HttpContext.Session.GetString("UserRole");
        var doctorId = HttpContext.Session.GetInt32("UserId");

        if (role != "Doctor" || doctorId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var doctor = await _doctorProfileService.GetDoctorByIdAsync(doctorId.Value);

        if (doctor == null)
        {
            return NotFound();
        }

        var allAppointments = await _appointmentService.GetAllAppointmentsAsync();

        var doctorAppointments = allAppointments
            .Where(a => a.DoctorId == doctorId.Value)
            .OrderByDescending(a => a.AppointmentDate)
            .ToList();

        var todayAppointments = doctorAppointments
            .Where(a => a.AppointmentDate.Date == DateTime.Today)
            .ToList();

        var tomorrowAppointments = doctorAppointments
            .Where(a => a.AppointmentDate.Date == DateTime.Today.AddDays(1))
            .ToList();

        var nextAppointment = doctorAppointments
            .Where(a => a.AppointmentDate >= DateTime.Now &&
                        a.Status != AppointmentStatus.Declined &&
                        a.Status != AppointmentStatus.Cancelled &&
                        a.Status != AppointmentStatus.Completed)
            .OrderBy(a => a.AppointmentDate)
            .FirstOrDefault();

        ViewBag.FullName = doctor.FullName;
        ViewBag.Specialization = doctor.Specialization;
        ViewBag.HospitalName = doctor.Hospital?.Name;
        ViewBag.DepartmentName = doctor.Department?.Name;

        ViewBag.TotalRequests = doctorAppointments.Count;
        ViewBag.PendingRequests = doctorAppointments.Count(a => a.Status == AppointmentStatus.Pending);
        ViewBag.ConfirmedRequests = doctorAppointments.Count(a => a.Status == AppointmentStatus.Confirmed);
        ViewBag.CompletedRequests = doctorAppointments.Count(a => a.Status == AppointmentStatus.Completed);

        ViewBag.TodayAppointments = todayAppointments.Count;
        ViewBag.TomorrowAppointments = tomorrowAppointments.Count;
        ViewBag.NextAppointment = nextAppointment;

        return View();
    }
}