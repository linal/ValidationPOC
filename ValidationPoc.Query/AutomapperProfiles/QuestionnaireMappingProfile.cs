using AutoMapper;
using ValidationPoc.Domain;
using ValidationPoc.Dto;

namespace ValidationPoc.Query.AutomapperProfiles
{
    public class QuestionnaireMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Answers, Questionnaire>();
            CreateMap<Domain.PreviousName, Dto.PreviousName>();
        }
    }
}