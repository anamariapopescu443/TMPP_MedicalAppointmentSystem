using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.BusinessLogic.Patterns.AbstractFactory;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Builder;
using MedicalAppointmentSystem.BusinessLogic.Patterns.FactoryMethod;
using MedicalAppointmentSystem.DataAccess;
using MedicalAppointmentSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Facade;

public class AppointmentFacade : IAppointmentFacade
{
    private readonly IAppointmentBuilder _appointmentBuilder;
    private readonly IAppointmentService _appointmentService;
    private readonly ApplicationDbContext _context;

    public AppointmentFacade(
        IAppointmentBuilder appointmentBuilder,
        IAppointmentService appointmentService,
        ApplicationDbContext context)
    {
        _appointmentBuilder = appointmentBuilder;
        _appointmentService = appointmentService;
        _context = context;
    }

    public async Task CreateAppointmentAsync(
        int patientId,
        int hospitalId,
        int departmentId,
        int doctorId,
        int medicalServiceId,
        DateTime appointmentDate,
        string reason,
        AppointmentType type)
    {
        var builtAppointment = _appointmentBuilder
            .WithPatient(patientId)
            .WithHospital(hospitalId)
            .WithDepartment(departmentId)
            .WithDoctor(doctorId)
            .WithMedicalService(medicalServiceId)
            .WithDate(appointmentDate)
            .WithReason(reason)
            .WithType(type)
            .Build();

        var factory = AppointmentFactoryProvider.GetFactory(type);

        var finalAppointment = factory.CreateAppointment(builtAppointment);

        var hospital = await _context.Hospitals
            .FirstOrDefaultAsync(h => h.Id == hospitalId);

        if (hospital == null)
        {
            throw new Exception("Hospital not found.");
        }

        var institutionFactory = MedicalInstitutionFactoryProvider.GetFactory(hospital.Type);
        var policy = institutionFactory.CreateAppointmentPolicy();

        finalAppointment.DoctorComment =
            $"{finalAppointment.DoctorComment} Institution policy: {policy.InstitutionCategory}. {policy.ConfirmationRule}";

        await _appointmentService.CreateAppointmentAsync(finalAppointment);
    }
}