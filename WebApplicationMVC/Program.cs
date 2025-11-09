using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services BEFORE building
builder.Services.AddControllersWithViews();

// Add MySQL connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))
    ));

// Build the app AFTER all services are configured
var app = builder.Build();

// Configure middleware
app.UseStaticFiles();
app.UseRouting();

// Add explicit routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();