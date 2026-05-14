using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Adapter;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentSystem.Web.Controllers;

public class PatientProfileController : Controller
{
    private readonly IPatientProfileService _patientProfileService;
    private readonly IMedicalCardStorage _medicalCardStorage;

    public PatientProfileController(
        IPatientProfileService patientProfileService,
        IMedicalCardStorage medicalCardStorage)
    {
        _patientProfileService = patientProfileService;
        _medicalCardStorage = medicalCardStorage;
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

        return View(patient);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateProfile(
        string firstName,
        string lastName,
        string phoneNumber,
        string email,
        string idnp,
        DateTime dateOfBirth)
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

        patient.FirstName = firstName;
        patient.LastName = lastName;
        patient.PhoneNumber = phoneNumber;
        patient.Email = email;
        patient.IDNP = idnp;
        patient.DateOfBirth = dateOfBirth;

        await _patientProfileService.UpdatePatientProfileAsync(patient);

        HttpContext.Session.SetString("FullName", patient.FullName);

        TempData["Success"] = "Profile updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UploadMedicalCard(IFormFile medicalCard)
    {
        var role = HttpContext.Session.GetString("UserRole");
        var patientId = HttpContext.Session.GetInt32("UserId");

        if (role != "Patient" || patientId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        if (medicalCard == null || medicalCard.Length == 0)
        {
            TempData["Error"] = "Please choose a file.";
            return RedirectToAction(nameof(Index));
        }

        try
        {
            using var stream = medicalCard.OpenReadStream();

            var filePath = await _medicalCardStorage.SaveMedicalCardAsync(
                stream,
                medicalCard.FileName,
                medicalCard.ContentType);

            await _patientProfileService.UpdateMedicalCardPathAsync(
                patientId.Value,
                filePath);

            TempData["Success"] = "Medical card uploaded successfully.";
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }
}