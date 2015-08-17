using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ValidationPoc.Domain;
using ValidationPoc.EntityFramework;

namespace ValidationPoc.Command.Handlers
{
    public class RemoveAnswersCommandHandler : ICommandHandlerAsync<RemoveAnswersCommand,int>
    {
        private readonly DataContext dataContext;

        public RemoveAnswersCommandHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<int> HandleAsync(RemoveAnswersCommand command)
        {
            var answers = await dataContext.Set<Answers>().SingleAsync(x => x.Id == command.Id);
            dataContext.Set<Answers>().Remove(answers);
            //await dataContext.SaveChangesAsync();
            return answers.Id;
        }
    }
}