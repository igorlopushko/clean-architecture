using AutoMapper;
using CleanArchitecture.Sample.Api.Models;
using CleanArchitecture.Sample.Core.Entities;

namespace CleanArchitecture.Sample.Api.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<UserModel, User>().ReverseMap();
        }
    }
}