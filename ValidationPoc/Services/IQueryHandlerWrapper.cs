using System.Threading.Tasks;
using ValidationPoc.Query;

namespace ValidationPoc.Services
{
    public interface IQueryHandlerWrapper
    {
        Task<TResult> HandleAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}