var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

SqlServerBootstrap.initialize(app.Configuration);

app.Run();