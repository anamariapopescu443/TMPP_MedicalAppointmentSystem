using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentSystem.Web.Controllers;

public class NotificationsController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<IActionResult> Index()
    {
        var role = HttpContext.Session.GetString("UserRole");
        var patientId = HttpContext.Session.GetInt32("UserId");

        if (role != "Patient" || patientId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var notifications = await _notificationService
            .GetNotificationsForPatientAsync(patientId.Value);

        return View(notifications);
    }
}