namespace ValidationPoc.Query
{
    public class GetQuestionnaireSummaryPageQuery : IQuery
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}