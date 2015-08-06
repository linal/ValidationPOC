using System.Threading.Tasks;
using ValidationPoc.Command;

namespace ValidationPoc.Services
{
    public interface ICommandHandlerWrapper
    {
        Task<TResult> HandleAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }
}