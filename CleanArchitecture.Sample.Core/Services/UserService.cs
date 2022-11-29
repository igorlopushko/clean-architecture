using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Sample.Core.Entities;
using CleanArchitecture.Sample.Core.Interfaces;

namespace CleanArchitecture.Sample.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(User user, CancellationToken token)
        {
            await _userRepository.CreateAsync(user, token);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public IEnumerable<User> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            await _userRepository.DeleteAsync(id, token);
        }

        public async Task UpdateAsync(User user, CancellationToken token)
        {
            await _userRepository.UpdateAsync(user, token);
        }
    }
}