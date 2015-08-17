using System.Linq;
using System.Threading.Tasks;
using PagedList.EntityFramework;
using ValidationPoc.Domain;
using ValidationPoc.Dto;
using ValidationPoc.EntityFramework;

namespace ValidationPoc.Query.Handlers
{
    public class GetQuestionnaireSummaryPageQueryHandler : IQueryHandlerAsync<GetQuestionnaireSummaryPageQuery, QuestionnaireSummaryCollection>
    {
        private readonly DataContext dataContext;

        public GetQuestionnaireSummaryPageQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<QuestionnaireSummaryCollection> HandleAsync(GetQuestionnaireSummaryPageQuery query)
        {
            var pagedList = await dataContext.Set<Answers>()
                .OrderByDescending(x => x.DateCompleted)
                .Select(x => new QuestionnaireSummary
                {
                    Id = x.Id,
                    DateCompleted = x.DateCompleted
                }).ToPagedListAsync(query.Page, query.PageSize);

            return new QuestionnaireSummaryCollection
            {
                Items = pagedList.ToList(),
                Page = pagedList.PageNumber,
                TotalItemCount = pagedList.TotalItemCount,
                HasNextPage = pagedList.HasNextPage,
                HasPreviousPage = pagedList.HasPreviousPage
            };
        }
    }
}