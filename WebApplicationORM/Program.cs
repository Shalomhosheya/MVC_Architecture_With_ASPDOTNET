using Microsoft.EntityFrameworkCore;
using WebApplicationORM.Models;
using WebApplicationORM.Repository;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);


var serverVersion = new MySqlServerVersion(new Version(8, 0, 33)); // replace with your MySQL version

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        serverVersion
    )
);

// ✅ 2. Register your repository
builder.Services.AddScoped<UserRepository>();

// ✅ 3. Add Controllers with Views (MVC)
builder.Services.AddControllersWithViews();

// -----------------------
var app = builder.Build();  // <-- build AFTER adding services
// -----------------------

// ✅ 4. Middleware
app.UseStaticFiles();
app.UseRouting();

// ✅ 5. Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}"
);

app.Run();