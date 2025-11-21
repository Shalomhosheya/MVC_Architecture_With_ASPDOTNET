public static class SqlServerBootstrap
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {
        // Add your SQL Server services here
        services.AddDbContext<YourDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}