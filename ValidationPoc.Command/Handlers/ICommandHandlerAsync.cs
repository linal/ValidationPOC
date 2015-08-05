using System.ComponentModel;
using System.Threading.Tasks;

namespace ValidationPoc.Command.Handlers
{
    public interface ICommandHandlerAsync<TCommand, TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}