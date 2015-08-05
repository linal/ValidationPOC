using System.Threading.Tasks;

namespace ValidationPoc.Query.Handlers
{
    public interface IQueryHandlerAsync<TQuery, TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}