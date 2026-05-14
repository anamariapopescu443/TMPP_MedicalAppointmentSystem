namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Command;

public interface IAppointmentCommand
{
    Task ExecuteAsync();
}