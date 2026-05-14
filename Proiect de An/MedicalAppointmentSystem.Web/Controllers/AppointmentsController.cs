using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Proxy;
using MedicalAppointmentSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Command;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Strategy;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Facade;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Prototype;

namespace MedicalAppointmentSystem.Web.Controllers;

public class AppointmentsController : Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly ILookupService _lookupService;
    private readonly IAppointmentAccessProxy _appointmentAccessProxy;
    private readonly IAppointmentFacade _appointmentFacade;
    private readonly IAppointmentPrototypeService _appointmentPrototypeService;

    public AppointmentsController(
        IAppointmentService appointmentService,
        ILookupService lookupService,
        IAppointmentAccessProxy appointmentAccessProxy,
        IAppointmentFacade appointmentFacade,
        IAppointmentPrototypeService appointmentPrototypeService)
    {
        _appointmentService = appointmentService;
        _lookupService = lookupService;
        _appointmentAccessProxy = appointmentAccessProxy;
        _appointmentFacade = appointmentFacade;
        _appointmentPrototypeService = appointmentPrototypeService;
    }

    public async Task<IActionResult> Index(string? filter)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var userId = HttpContext.Session.GetInt32("UserId");

        if (string.IsNullOrEmpty(role) || userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var appointments = await _appointmentAccessProxy
            .GetAppointmentsForUserAsync(role, userId.Value);

        var strategy = AppointmentFilterContext.CreateStrategy(filter);
        var context = new AppointmentFilterContext(strategy);

        var filteredAppointments = context.ApplyFilter(appointments);

        ViewBag.Role = role;
        ViewBag.Filter = filter ?? "all";

        return View(filteredAppointments);
    }

    public async Task<IActionResult> Details(int id)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var userId = HttpContext.Session.GetInt32("UserId");

        if (string.IsNullOrEmpty(role) || userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

        if (appointment == null)
        {
            return NotFound();
        }

        if (role == "Patient" && appointment.PatientId != userId.Value)
        {
            return RedirectToAction(nameof(Index));
        }

        if (role == "Doctor" && appointment.DoctorId != userId.Value)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Role = role;

        return View(appointment);
    }

    public async Task<IActionResult> Create()
    {
        var role = HttpContext.Session.GetString("UserRole");

        if (role != "Patient")
        {
            return RedirectToAction("Login", "Account");
        }

        await LoadDropdownsAsync();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Appointment appointment)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var userId = HttpContext.Session.GetInt32("UserId");

        if (role != "Patient" || userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        if (appointment.AppointmentDate <= DateTime.Now)
        {
            TempData["Error"] = "Appointment date must be in the future.";
            await LoadDropdownsAsync();
            return View(appointment);
        }

        if (string.IsNullOrWhiteSpace(appointment.Reason))
        {
            TempData["Error"] = "Please describe the reason for the appointment.";
            await LoadDropdownsAsync();
            return View(appointment);
        }

        if (appointment.HospitalId <= 0 ||
            appointment.DepartmentId <= 0 ||
            appointment.DoctorId <= 0 ||
            appointment.MedicalServiceId <= 0)
        {
            TempData["Error"] = "Please select hospital, department, doctor and medical service.";
            await LoadDropdownsAsync();
            return View(appointment);
        }

        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Please complete all required fields correctly.";
            await LoadDropdownsAsync();
            return View(appointment);
        }

        await _appointmentFacade.CreateAppointmentAsync(
            userId.Value,
            appointment.HospitalId,
            appointment.DepartmentId,
            appointment.DoctorId,
            appointment.MedicalServiceId,
            appointment.AppointmentDate,
            appointment.Reason,
            appointment.Type);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var userId = HttpContext.Session.GetInt32("UserId");

        if (role != "Patient" || userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

        if (appointment == null)
        {
            return NotFound();
        }

        if (appointment.PatientId != userId.Value)
        {
            return RedirectToAction(nameof(Index));
        }

        await LoadDropdownsAsync();

        return View(appointment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Appointment appointment)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var userId = HttpContext.Session.GetInt32("UserId");

        if (role != "Patient" || userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        appointment.PatientId = userId.Value;

        if (!ModelState.IsValid)
        {
            await LoadDropdownsAsync();
            return View(appointment);
        }

        await _appointmentService.UpdateAppointmentAsync(appointment);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var userId = HttpContext.Session.GetInt32("UserId");

        if (role != "Patient" || userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

        if (appointment == null)
        {
            return NotFound();
        }

        if (appointment.PatientId != userId.Value)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(appointment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var userId = HttpContext.Session.GetInt32("UserId");

        if (role != "Patient" || userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

        if (appointment == null)
        {
            return NotFound();
        }

        if (appointment.PatientId != userId.Value)
        {
            return RedirectToAction(nameof(Index));
        }

        await _appointmentService.DeleteAppointmentAsync(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Confirm(int id)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var doctorId = HttpContext.Session.GetInt32("UserId");

        if (role != "Doctor" || doctorId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        try
        {
            IAppointmentCommand command = new ConfirmAppointmentCommand(
                _appointmentService,
                id,
                doctorId.Value);

            await command.ExecuteAsync();
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Decline(int id, string declineReason)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var doctorId = HttpContext.Session.GetInt32("UserId");

        if (role != "Doctor" || doctorId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        try
        {
            IAppointmentCommand command = new DeclineAppointmentCommand(
                _appointmentService,
                id,
                doctorId.Value,
                declineReason);

            await command.ExecuteAsync();
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Complete(int id, string doctorComment)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var doctorId = HttpContext.Session.GetInt32("UserId");

        if (role != "Doctor" || doctorId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        try
        {
            IAppointmentCommand command = new CompleteAppointmentCommand(
                _appointmentService,
                id,
                doctorId.Value,
                doctorComment);

            await command.ExecuteAsync();
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateFollowUp(int id, DateTime followUpDate)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var doctorId = HttpContext.Session.GetInt32("UserId");

        if (role != "Doctor" || doctorId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        try
        {
            await _appointmentPrototypeService.CreateFollowUpFromExistingAsync(
                id,
                doctorId.Value,
                followUpDate);
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartmentsByHospital(int hospitalId)
    {
        var departments = await _lookupService.GetDepartmentsAsync();

        var result = departments
            .Where(d => d.HospitalId == hospitalId)
            .Select(d => new
            {
                id = d.Id,
                name = d.Name
            })
            .ToList();

        return Json(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctorsByDepartment(int departmentId)
    {
        var doctors = await _lookupService.GetDoctorsAsync();

        var result = doctors
            .Where(d => d.DepartmentId == departmentId)
            .Select(d => new
            {
                id = d.Id,
                name = $"{d.FullName} - {d.Specialization}"
            })
            .ToList();

        return Json(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetServicesByDepartment(int departmentId)
    {
        var services = await _lookupService.GetMedicalServicesAsync();

        var result = services
            .Where(s => s.DepartmentId == departmentId)
            .Select(s => new
            {
                id = s.Id,
                name = $"{s.Name} ({s.Price} MDL)"
            })
            .ToList();

        return Json(result);
    }

    private async Task LoadDropdownsAsync()
    {
        var hospitals = await _lookupService.GetHospitalsAsync();

        ViewBag.Hospitals = new SelectList(
            hospitals,
            "Id",
            "Name"
        );
    }
}