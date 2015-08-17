using System;
using System.Threading.Tasks;
using AutoMapper;
using ValidationPoc.Domain;
using ValidationPoc.Dto;
using ValidationPoc.EntityFramework;

namespace ValidationPoc.Command.Handlers
{
    public class CreateAnswersCommandHandler : ICommandHandlerAsync<CreateAnswersCommand, Questionnaire>
    {
        private readonly DataContext dataContext;

        public CreateAnswersCommandHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Questionnaire> HandleAsync(CreateAnswersCommand command)
        {
            var answers = Mapper.Map<Answers>(command.Questionnaire);

            answers.DateCompleted = DateTime.Now;

            dataContext.Set<Answers>().Add(answers);
            await dataContext.SaveChangesAsync();

            return command.Questionnaire;
        }
    }
}