using AutoMapper;
using WebApplication1.DTO.Option;
using WebApplication1.Entities;

namespace WebApplication1.Automapper
{
    public class OptionProfile : Profile
    {
        public OptionProfile() 
        {
            CreateMap<Option, OptionGetDto>();
            CreateMap<OptionPostDto, Option>();
            CreateMap<OptionPutDto, Option>();
        }
    }
}
