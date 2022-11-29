using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Sample.Core.Entities;

namespace CleanArchitecture.Sample.Core.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user, CancellationToken token);
        Task<User> GetAsync(int id);
        IEnumerable<User> GetAllAsync();
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(User user, CancellationToken token);
    }
}