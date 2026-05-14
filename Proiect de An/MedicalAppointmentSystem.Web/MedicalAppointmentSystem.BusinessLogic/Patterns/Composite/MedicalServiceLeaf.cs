namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Composite;

public class MedicalServiceLeaf : IMedicalStructureComponent
{
    public string Name { get; }

    public decimal Price { get; }

    public MedicalServiceLeaf(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public decimal GetTotalPrice()
    {
        return Price;
    }

    public List<IMedicalStructureComponent> GetChildren()
    {
        return new List<IMedicalStructureComponent>();
    }
}