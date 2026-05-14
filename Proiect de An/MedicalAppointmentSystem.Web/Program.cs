using MedicalAppointmentSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.BusinessLogic.Services;
using MedicalAppointmentSystem.DataAccess.Repositories;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Proxy;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Builder;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Facade;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Prototype;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Composite;
using MedicalAppointmentSystem.BusinessLogic.Patterns.Adapter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAppointmentAccessProxy, AppointmentAccessProxy>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IAppointmentFacade, AppointmentFacade>();
builder.Services.AddScoped<IAppointmentPrototypeService, AppointmentPrototypeService>();
builder.Services.AddScoped<MedicalStructureBuilder>();
builder.Services.AddScoped<IDoctorProfileService, DoctorProfileService>();

builder.Services.AddScoped<IPatientProfileService, PatientProfileService>();

builder.Services.AddScoped(provider =>
{
    var environment = provider.GetRequiredService<IWebHostEnvironment>();
    return new LocalFileStorageService(environment.WebRootPath);
});

builder.Services.AddScoped<IMedicalCardStorage, MedicalCardStorageAdapter>();

builder.Services.AddTransient<IAppointmentBuilder, AppointmentBuilder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
