using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentSystem.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Role = HttpContext.Session.GetString("UserRole");
        ViewBag.FullName = HttpContext.Session.GetString("FullName");

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}