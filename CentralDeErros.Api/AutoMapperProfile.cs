using AutoMapper;
using CentralDeErros.Business;
using CentralDeErros.Business.Models;
using CentralDeErros.Data.Models;

namespace CentralDeErros.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Error, ErrorDTO>().ReverseMap();
            CreateMap<Level, LevelDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
