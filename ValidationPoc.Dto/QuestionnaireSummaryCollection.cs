using System.Collections.Generic;

namespace ValidationPoc.Dto
{
    public class QuestionnaireSummaryCollection
    {
        public List<QuestionnaireSummary> Items { get; set; }

        public int Page { get; set; }

        public int TotalItemCount { get; set; }

        public bool HasNextPage { get; set; }

        public bool HasPreviousPage { get; set; }

        public QuestionnaireSummaryCollection()
        {
            Items = new List<QuestionnaireSummary>();
        } 
    }
}