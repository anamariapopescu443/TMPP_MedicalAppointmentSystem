using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalAppointmentSystem.Web.Controllers;

public class DoctorProfileController : Controller
{
    private readonly IDoctorProfileService _doctorProfileService;
    private readonly ILookupService _lookupService;

    public DoctorProfileController(
        IDoctorProfileService doctorProfileService,
        ILookupService lookupService)
    {
        _doctorProfileService = doctorProfileService;
        _lookupService = lookupService;
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

        await LoadDropdownsAsync();

        return View(doctor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateProfile(
        string firstName,
        string lastName,
        string phoneNumber,
        string email,
        string idnp,
        int hospitalId,
        int departmentId,
        string specialization)
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

        doctor.FirstName = firstName;
        doctor.LastName = lastName;
        doctor.PhoneNumber = phoneNumber;
        doctor.Email = email;
        doctor.IDNP = idnp;
        doctor.HospitalId = hospitalId;
        doctor.DepartmentId = departmentId;
        doctor.Specialization = specialization;

        await _doctorProfileService.UpdateDoctorProfileAsync(doctor);

        HttpContext.Session.SetString("FullName", doctor.FullName);

        TempData["Success"] = "Doctor profile updated successfully.";

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

    private async Task LoadDropdownsAsync()
    {
        var hospitals = await _lookupService.GetHospitalsAsync();

        ViewBag.Hospitals = new SelectList(hospitals, "Id", "Name");
    }
}