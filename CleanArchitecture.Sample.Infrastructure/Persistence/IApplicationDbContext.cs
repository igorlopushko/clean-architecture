using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Sample.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArchitecture.Sample.Infrastructure.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}