using AutoMapper;
using WebApplication1.DTO.Question;
using WebApplication1.Entities;

namespace WebApplication1.Automapper
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile() 
        {
            CreateMap<Question, QuestionGetDto>()
                .ForMember(dest => dest.OptionGetDtos, opt => opt.MapFrom(src => src.Options));

            CreateMap<QuestionPostDto, Question>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.OptionPostDtos));

            CreateMap<QuestionPutDto, Question>();

        }
    }
}
