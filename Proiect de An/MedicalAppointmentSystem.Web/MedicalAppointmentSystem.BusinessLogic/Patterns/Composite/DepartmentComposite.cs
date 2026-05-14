namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Composite;

public class DepartmentComposite : IMedicalStructureComponent
{
    private readonly List<IMedicalStructureComponent> _children = new();

    public string Name { get; }

    public DepartmentComposite(string name)
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