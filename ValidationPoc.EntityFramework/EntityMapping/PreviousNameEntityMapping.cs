using System.Data.Entity.ModelConfiguration;
using ValidationPoc.Domain;

namespace ValidationPoc.EntityFramework.EntityMapping
{
    public class PreviousNameEntityMapping : EntityTypeConfiguration<PreviousName>
    {
        public PreviousNameEntityMapping()
        {
            ToTable("PreviousName");
            Property(x => x.FirstName).HasMaxLength(100);
            Property(x => x.Surname).HasMaxLength(100);
        }
    }
}