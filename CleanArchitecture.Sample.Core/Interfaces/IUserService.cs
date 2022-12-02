using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Sample.Core.Entities;

namespace CleanArchitecture.Sample.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user, CancellationToken token);
        Task<User> GetUserAsync(int id);
        IEnumerable<User> GetAllUsersAsync();
        public Task DeleteUserAsync(int id, CancellationToken token);
        public Task UpdateUserAsync(User user, CancellationToken token);
    }
}