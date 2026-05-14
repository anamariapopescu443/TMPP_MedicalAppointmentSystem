namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Composite;

public class HospitalComposite : IMedicalStructureComponent
{
    private readonly List<IMedicalStructureComponent> _children = new();

    public string Name { get; }

    public HospitalComposite(string name)
    {
        Name = name;
    }

    public void Add(IMedicalStructureComponent component)
    {
        _children.Add(component);
    }

    public decimal GetTotalPrice()
    {
        return _children.Sum(child => child.GetTotalPrice());
    }

    public List<IMedicalStructureComponent> GetChildren()
    {
        return _children;
    }
}