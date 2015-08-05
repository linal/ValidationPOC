using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationPoc.EntityFramework.EntityMapping;
using ValidationPoc.EntityFramework.Migrations;

namespace ValidationPoc.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ValidationPoc")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AnswersEntityMapping());
            modelBuilder.Configurations.Add(new PreviousNameEntityMapping());

            modelBuilder.Properties()
                .Where(
                    x =>
                        x.PropertyType.FullName.Equals("System.String") &&
                        !x.GetCustomAttributes(false)
                            .OfType<ColumnAttribute>()
                            .Any(q => q.TypeName != null && q.TypeName.Equals("varchar", StringComparison.InvariantCultureIgnoreCase)))
                .Configure(c => c.HasColumnType("varchar"));
        }
    }
}
