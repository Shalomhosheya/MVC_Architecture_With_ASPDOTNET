var builder = WebApplication.CreateBuilder(args);

// Configure services BEFORE building the app
SqlServerBootstrap.Initialize(builder.Services, builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();