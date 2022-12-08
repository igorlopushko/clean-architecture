using CleanArchitecture.Sample.Infrastructure.Persistence.Config;
using CleanArchitecture.Sample.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Sample.Infrastructure.Persistence
{
    public static class ApplicationDbExtension
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var postgresConfig = configuration.GetSection(PostgresSettings.SectionName).Get<PostgresSettings>();
            services.AddSingleton(postgresConfig);

            var name = typeof(ApplicationDbContext).Assembly.FullName;

            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(
                opt => opt.UseNpgsql(postgresConfig.ConnectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly(name)));
        }

        public static void RunDbContextMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetService<IApplicationDbContext>();
            
            dbContext.Database.Migrate();
        }
    }
}