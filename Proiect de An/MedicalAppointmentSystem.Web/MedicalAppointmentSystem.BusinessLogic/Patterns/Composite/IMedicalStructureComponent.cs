namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Composite;

public interface IMedicalStructureComponent
{
    string Name { get; }

    decimal GetTotalPrice();

    List<IMedicalStructureComponent> GetChildren();
}