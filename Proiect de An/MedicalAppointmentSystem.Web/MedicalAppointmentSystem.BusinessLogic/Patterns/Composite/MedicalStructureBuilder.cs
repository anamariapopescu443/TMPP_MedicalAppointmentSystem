using MedicalAppointmentSystem.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Composite;

public class MedicalStructureBuilder
{
    private readonly ApplicationDbContext _context;

    public MedicalStructureBuilder(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<IMedicalStructureComponent>> BuildStructureAsync()
    {
        var hospitals = await _context.Hospitals
            .Include(h => h.Departments)
            .ThenInclude(d => d.MedicalServices)
            .ToListAsync();

        var result = new List<IMedicalStructureComponent>();

        foreach (var hospital in hospitals)
        {
            var hospitalComposite = new HospitalComposite(hospital.Name);

            foreach (var department in hospital.Departments)
            {
                var departmentComposite = new DepartmentComposite(department.Name);

                foreach (var service in department.MedicalServices)
                {
                    var serviceLeaf = new MedicalServiceLeaf(service.Name, service.Price);
                    departmentComposite.Add(serviceLeaf);
                }

                hospitalComposite.Add(departmentComposite);
            }

            result.Add(hospitalComposite);
        }

        return result;
    }
}