using System.Data.Entity.ModelConfiguration;
using ValidationPoc.Domain;

namespace ValidationPoc.EntityFramework.EntityMapping
{
    public class AnswersEntityMapping : EntityTypeConfiguration<Answers>
    {
        public AnswersEntityMapping()
        {
            ToTable("Answer");
            HasKey(x => x.Id);
            Property(x => x.Name);
            Property(x => x.AnswerMoreQuestions);
            Property(x => x.SeeMoreQuestions);
            Property(x => x.Velocity);
            Property(x => x.Color);
            Property(x => x.TypeOfGreen);
            Property(x => x.UltimateQuestion);
            HasMany(x => x.PreviousNames);
        }
    }
}