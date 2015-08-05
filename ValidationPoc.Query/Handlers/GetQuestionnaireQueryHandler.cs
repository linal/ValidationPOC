using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using ValidationPoc.Domain;
using ValidationPoc.Dto;
using ValidationPoc.EntityFramework;

namespace ValidationPoc.Query.Handlers
{
    public class GetQuestionnaireQueryHandler : IQueryHandlerAsync<GetQuestionnaireQuery, Questionnaire>
    {
        private readonly DataContext dataContext;

        public GetQuestionnaireQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Questionnaire> HandleAsync(GetQuestionnaireQuery query)
        {
            var answers = await dataContext.Set<Answers>().Include(x => x.PreviousNames).FirstOrDefaultAsync(x => x.Id == query.Id);
            return Mapper.Map<Questionnaire>(answers);
        }
    }
}