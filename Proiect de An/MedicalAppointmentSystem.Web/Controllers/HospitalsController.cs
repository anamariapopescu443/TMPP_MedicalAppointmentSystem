using MedicalAppointmentSystem.BusinessLogic.Patterns.Composite;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentSystem.Web.Controllers;

public class HospitalsController : Controller
{
    private readonly MedicalStructureBuilder _medicalStructureBuilder;

    public HospitalsController(MedicalStructureBuilder medicalStructureBuilder)
    {
        _medicalStructureBuilder = medicalStructureBuilder;
    }

    public async Task<IActionResult> Index()
    {
        var structure = await _medicalStructureBuilder.BuildStructureAsync();

        return View(structure);
    }
}