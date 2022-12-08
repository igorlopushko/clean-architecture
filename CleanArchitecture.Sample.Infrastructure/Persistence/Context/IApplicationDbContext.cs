using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Sample.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArchitecture.Sample.Infrastructure.Persistence.Context
{
    public interface IApplicationDbContext
    {
        DbSet<UserModel> Users { get; set; }
        
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}