using System.Threading.Tasks;
using ValidationPoc.Query;

namespace ValidationPoc.Services
{
    public interface IQueryHandlerDispatcher
    {
        Task<TResult> HandleAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}