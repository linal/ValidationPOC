using AutoMapper;
using ValidationPoc.Domain;
using ValidationPoc.Dto;

namespace ValidationPoc.Command.AutomapperProfiles
{
    public class AnswersMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Questionnaire, Answers>();
            CreateMap<Dto.PreviousName, Domain.PreviousName>();
        }
    }
}