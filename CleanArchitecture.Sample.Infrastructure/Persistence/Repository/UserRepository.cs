using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Sample.Core.Entities;
using CleanArchitecture.Sample.Core.Interfaces;
using CleanArchitecture.Sample.Infrastructure.Persistence.Context;
using CleanArchitecture.Sample.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Sample.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public UserRepository(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User user, CancellationToken token)
        {
            var userModel = _mapper.Map<UserModel>(user);
            
            await _dbContext.Users.AddAsync(userModel, token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<User> GetAsync(int id)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<User>(result);
        }

        public IEnumerable<User> GetAllAsync()
        {
            var result = _dbContext.Users.Select(x => x).AsEnumerable();
            return _mapper.Map<IEnumerable<User>>(result);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var user = _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            _dbContext.Users.Remove(user.Result);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(User user, CancellationToken token)
        {
            var userModel = _mapper.Map<UserModel>(user);
            
            _dbContext.Users.Update(userModel);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}