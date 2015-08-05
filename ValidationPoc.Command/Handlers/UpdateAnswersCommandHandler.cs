using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ValidationPoc.Domain;
using ValidationPoc.Dto;
using ValidationPoc.EntityFramework;
using PreviousName = ValidationPoc.Domain.PreviousName;

namespace ValidationPoc.Command.Handlers
{
    public class UpdateAnswersCommandHandler : ICommandHandlerAsync<UpdateAnswersCommand, Questionnaire>
    {
        private readonly DataContext dataContext;

        public UpdateAnswersCommandHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Questionnaire> HandleAsync(UpdateAnswersCommand command)
        {
            var answers = await dataContext.Set<Answers>().Include(x => x.PreviousNames).FirstOrDefaultAsync(x => x.Id == command.Id);

            if (answers == null)
            {
                throw new Exception("Answers not found");
            }

            // remove the old previous name before the update
            if (answers.PreviousNames != null && answers.PreviousNames.Any())
            {
                dataContext.Set<PreviousName>().RemoveRange(answers.PreviousNames);
            }

            answers = Mapper.Map(command.Questionnaire, answers);

            dataContext.Set<Answers>().AddOrUpdate(answers);
            await dataContext.SaveChangesAsync();

            return command.Questionnaire;
        }
    }
}