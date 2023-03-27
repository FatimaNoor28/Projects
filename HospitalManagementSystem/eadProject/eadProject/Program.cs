using eadProject.Models;

namespace eadProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            //method 1: register with lifetime
            //builder.Services.Add(new ServiceDescriptor(typeof(IReportsRepo), new ReportsRepository())); //singleton
            //builder.Services.Add(new ServiceDescriptor(typeof(IReportsRepo), typeof(ReportsRepository), ServiceLifetime.Transient));
            //builder.Services.Add(new ServiceDescriptor(typeof(IReportsRepo), typeof(ReportsRepository), ServiceLifetime.Scoped));

            //method 2: register with extension method
            builder.Services.AddSingleton<IReportsRepo, ReportsRepository>();
            builder.Services.AddScoped<IDoctorRepo, DoctorRepository>();
            builder.Services.AddTransient<IPatientRepo, PatientRepository>();
            builder.Services.AddSingleton<IAdminRepo, AdminRepository>();
            builder.Services.AddSingleton<IAppointmentRepo, AppointmentRepository>();
         
            //builder.Services.AddSingleton(typeof(IReportsRepo), typeof(ReportsRepository));


            

            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IAuditedModel, FullAudinModel>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
