using MedicalAppointmentSystem.BusinessLogic.Interfaces;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Command;

public class CompleteAppointmentCommand : IAppointmentCommand
{
    private readonly IAppointmentService _appointmentService;
    private readonly int _appointmentId;
    private readonly int _doctorId;
    private readonly string _doctorComment;

    public CompleteAppointmentCommand(
        IAppointmentService appointmentService,
        int appointmentId,
        int doctorId,
        string doctorComment)
    {
        _appointmentService = appointmentService;
        _appointmentId = appointmentId;
        _doctorId = doctorId;
        _doctorComment = doctorComment;
    }

    public async Task ExecuteAsync()
    {
        await _appointmentService.CompleteAppointmentAsync(
            _appointmentId,
            _doctorId,
            _doctorComment);
    }
}