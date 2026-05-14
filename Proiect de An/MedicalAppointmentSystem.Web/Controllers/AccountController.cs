using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalAppointmentSystem.Web.Controllers;

public class AccountController : Controller
{
    private readonly IAuthService _authService;
    private readonly ILookupService _lookupService;

    public AccountController(
        IAuthService authService,
        ILookupService lookupService)
    {
        _authService = authService;
        _lookupService = lookupService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _authService.LoginAsync(email, password);

        if (!result.Success)
        {
            ViewBag.Error = result.Error;
            return View();
        }

        HttpContext.Session.SetString("UserRole", result.Role);
        HttpContext.Session.SetInt32("UserId", result.UserId);
        HttpContext.Session.SetString("FullName", result.FullName);

        if (result.Role == "Patient")
        {
            return RedirectToAction("Index", "PatientDashboard");
        }

        if (result.Role == "Doctor")
        {
            return RedirectToAction("Index", "DoctorDashboard");
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        await LoadRegisterDropdownsAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        string role,
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string idnp,
        string password,
        DateTime? dateOfBirth,
        int? hospitalId,
        int? departmentId,
        string? specialization)
    {
        if (role == "Patient")
        {
            var patient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                IDNP = idnp,
                Password = password,
                DateOfBirth = dateOfBirth ?? DateTime.Now
            };

            var result = await _authService.RegisterPatientAsync(patient);

            if (!result.Success)
            {
                ViewBag.Error = result.Error;
                await LoadRegisterDropdownsAsync();
                return View();
            }

            return RedirectToAction("Login");
        }

        if (role == "Doctor")
        {
            if (hospitalId == null || departmentId == null)
            {
                ViewBag.Error = "Hospital and department are required for doctor registration.";
                await LoadRegisterDropdownsAsync();
                return View();
            }

            var doctor = new Doctor
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                IDNP = idnp,
                Password = password,
                HospitalId = hospitalId.Value,
                DepartmentId = departmentId.Value,
                Specialization = specialization ?? ""
            };

            var result = await _authService.RegisterDoctorAsync(doctor);

            if (!result.Success)
            {
                ViewBag.Error = result.Error;
                await LoadRegisterDropdownsAsync();
                return View();
            }

            return RedirectToAction("Login");
        }

        ViewBag.Error = "Please choose a valid role.";
        await LoadRegisterDropdownsAsync();
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
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

    private async Task LoadRegisterDropdownsAsync()
    {
        var hospitals = await _lookupService.GetHospitalsAsync();

        ViewBag.Hospitals = new SelectList(hospitals, "Id", "Name");
    }
}