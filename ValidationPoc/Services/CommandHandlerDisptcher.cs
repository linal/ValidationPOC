using System;
using System.Threading.Tasks;
using SimpleInjector;
using ValidationPoc.Command;
using ValidationPoc.Command.Handlers;

namespace ValidationPoc.Services
{
    public class CommandHandlerDisptcher : ICommandHandlerDisptcher
    {
        private readonly Container container;

        public CommandHandlerDisptcher(Container container)
        {
            this.container = container;
        }

        public async Task<TResult> HandleAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {

            var handler = container.GetInstance<ICommandHandlerAsync<TCommand, TResult>>();

            if (handler == null)
            {
                throw new Exception("Unable to find command handler");
            }

            return await handler.HandleAsync(command);
        }
    }
}