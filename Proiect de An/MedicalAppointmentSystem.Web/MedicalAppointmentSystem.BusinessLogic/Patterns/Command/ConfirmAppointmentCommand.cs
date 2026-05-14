using MedicalAppointmentSystem.BusinessLogic.Interfaces;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Command;

public class ConfirmAppointmentCommand : IAppointmentCommand
{
    private readonly IAppointmentService _appointmentService;
    private readonly int _appointmentId;
    private readonly int _doctorId;

    public ConfirmAppointmentCommand(
        IAppointmentService appointmentService,
        int appointmentId,
        int doctorId)
    {
        _appointmentService = appointmentService;
        _appointmentId = appointmentId;
        _doctorId = doctorId;
    }

    public async Task ExecuteAsync()
    {
        await _appointmentService.ConfirmAppointmentAsync(_appointmentId, _doctorId);
    }
}