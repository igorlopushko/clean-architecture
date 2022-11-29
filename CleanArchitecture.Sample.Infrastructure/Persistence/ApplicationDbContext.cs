using CleanArchitecture.Sample.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Sample.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}