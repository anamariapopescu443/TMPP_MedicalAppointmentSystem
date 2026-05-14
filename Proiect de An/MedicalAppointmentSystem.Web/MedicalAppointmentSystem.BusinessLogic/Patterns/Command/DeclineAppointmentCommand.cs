using MedicalAppointmentSystem.BusinessLogic.Interfaces;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Command;

public class DeclineAppointmentCommand : IAppointmentCommand
{
    private readonly IAppointmentService _appointmentService;
    private readonly int _appointmentId;
    private readonly int _doctorId;
    private readonly string _declineReason;

    public DeclineAppointmentCommand(
        IAppointmentService appointmentService,
        int appointmentId,
        int doctorId,
        string declineReason)
    {
        _appointmentService = appointmentService;
        _appointmentId = appointmentId;
        _doctorId = doctorId;
        _declineReason = declineReason;
    }

    public async Task ExecuteAsync()
    {
        await _appointmentService.DeclineAppointmentAsync(
            _appointmentId,
            _doctorId,
            _declineReason);
    }
}