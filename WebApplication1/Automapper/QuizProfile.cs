using AutoMapper;
using WebApplication1.DTO.Option;
using WebApplication1.DTO.Question;
using WebApplication1.DTO.Quiz;
using WebApplication1.Entities;

namespace WebApplication1.Automapper
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<Quiz, QuizGetDto>();
            CreateMap<Quiz, QuizDetailedGetDto>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationTime))
                .ForMember(dest => dest.QuestionGetDtos, opt => opt.MapFrom(src => src.Questions));

            CreateMap<QuizPostDto, Quiz>()
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.QuestionPostDtos));

            CreateMap<QuizPutDto, Quiz>();
        }
    }
}
