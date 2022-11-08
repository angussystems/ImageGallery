using Microsoft.EntityFrameworkCore;
using MRI.IdentityServer.DbContexts;
using MRI.IdentityServer.Services;
using Serilog;
using System.Reflection;

namespace MRI.IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<ILocalUserService, LocalUserService>();  

        builder.Services.AddDbContext<IdentityDbContext>(options => {
            options.UseSqlServer(builder.Configuration.GetConnectionString
                ("IdentityServerConnectionString"));
        
        });
        var migrationsAssembly = typeof(Program).GetTypeInfo()
            .Assembly.GetName().Name;


        builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;
            }).AddProfileService<LocalUserProfileService>()
             //.AddInMemoryIdentityResources(Config.IdentityResources)
             //.AddInMemoryApiScopes(Config.ApiScopes)
             //.AddInMemoryClients(Config.Clients)
             //.AddInMemoryApiResources(Config.ApiResources)
             //.AddTestUsers(TestUsers.Users);
             .AddConfigurationStore(options =>
              {
                  options.ConfigureDbContext = optionsBuilder =>
                  optionsBuilder.UseSqlServer(
                      builder.Configuration
                      .GetConnectionString("IdentityServerConnectionString"),
                              sqlOptions => sqlOptions
                              .MigrationsAssembly(migrationsAssembly));
              }).AddConfigurationStoreCache()
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = optionsBuilder =>
                   optionsBuilder.UseSqlServer(builder.Configuration
                   .GetConnectionString("IdentityServerConnectionString"),
                         sqlOptions => sqlOptions
                         .MigrationsAssembly(migrationsAssembly));
                options.EnableTokenCleanup = true;
            });
        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
