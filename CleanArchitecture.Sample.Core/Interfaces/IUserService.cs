using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Sample.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User user, CancellationToken token);
        Task<User> GetAsync(int id);
        IEnumerable<User> GetAllAsync();
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(User user, CancellationToken token);
    }
}