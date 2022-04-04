using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Sample.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Sample.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _dbContext;

        public UserService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User user, CancellationToken token)
        {
            await _dbContext.Users.AddAsync(user, token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<User> GetAllAsync()
        {
            return (_dbContext.Users.Select(x => x)).AsEnumerable();
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var user = _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            _dbContext.Users.Remove(user.Result);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(User user, CancellationToken token)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}