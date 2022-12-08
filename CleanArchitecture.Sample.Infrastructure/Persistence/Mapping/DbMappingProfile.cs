using AutoMapper;
using CleanArchitecture.Sample.Core.Entities;
using CleanArchitecture.Sample.Infrastructure.Persistence.Models;

namespace CleanArchitecture.Sample.Infrastructure.Persistence.Mapping
{
    public class DbMappingProfile : Profile
    {
        public DbMappingProfile()
        {			
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}