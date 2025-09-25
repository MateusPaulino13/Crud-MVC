using Microsoft.EntityFrameworkCore;
using Crud_MVC.Data;
using Crud_MVC.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
namespace Crud_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Crud_MVCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Crud_MVCContext"))
            );

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<SalesRecordService>();

            var app = builder.Build();
            var seedingService = app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>();
            var sellerService = app.Services.CreateScope().ServiceProvider.GetRequiredService<SellerService>();
            var departmentService = app.Services.CreateScope().ServiceProvider.GetRequiredService<DepartmentService>();
            var salesRecordService = app.Services.CreateScope().ServiceProvider.GetRequiredService<SalesRecordService>();

            var enUS = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            seedingService.Seed();

            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
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
