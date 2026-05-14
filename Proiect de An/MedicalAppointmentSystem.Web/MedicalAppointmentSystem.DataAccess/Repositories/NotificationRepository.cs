using MedicalAppointmentSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentSystem.DataAccess.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly ApplicationDbContext _context;

    public NotificationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Notification notification)
    {
        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Notification>> GetByPatientIdAsync(int patientId)
    {
        return await _context.Notifications
            .Include(n => n.Appointment)
            .Where(n => n.PatientId == patientId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }
}