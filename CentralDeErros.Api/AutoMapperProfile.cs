using AutoMapper;
using CentralDeErros.Business;
using CentralDeErros.Business.Models;
using CentralDeErros.Data.Models;
using System;

namespace CentralDeErros.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Error, ErrorDTO>()
                .ForMember(dest => dest.Level, act => act.MapFrom(src => src.Level.Name))
                .ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => src.CreatedAt.ToString("MM/dd/yyyy HH:mm:ss")));

            CreateMap<ErrorDTO, Error>()
                .ForMember(d => d.Level, act => act.Ignore())
                .ForMember(d => d.Category, act => act.Ignore())
                .ForMember(d => d.CreatedAt, act => act.MapFrom(src => DateTime.Now));


            CreateMap<Level, LevelDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
