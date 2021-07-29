using AutoMapper;
using ExamForWired.Data.Models;
using ExamForWired.Models;

namespace ExamForWired.Business.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile():this("AutoMapperProfileMappings")
        {
        }

        public AutoMapperProfile(string profileName) : base(profileName)
        {
            CreateMap<Exam, ExamModel>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
            CreateMap<ExamModel, Exam>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
            CreateMap<Question, QuestionModel>()
               .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
            CreateMap<Answer, AnswerModel>();
            CreateMap<QuestionModel, Question>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
            CreateMap<AnswerModel, Answer>();
        }
    }
}
