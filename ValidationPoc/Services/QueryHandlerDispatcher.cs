using System;
using System.Threading.Tasks;
using SimpleInjector;
using ValidationPoc.Query;
using ValidationPoc.Query.Handlers;

namespace ValidationPoc.Services
{
    public class QueryHandlerDispatcher : IQueryHandlerDispatcher
    {
        private readonly Container container;

        public QueryHandlerDispatcher(Container container)
        {
            this.container = container;
        }

        public async Task<TResult> HandleAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {

            var handler = container.GetInstance<IQueryHandlerAsync<TQuery, TResult>>();

            if (handler == null)
            {
                throw new Exception("Unable to find command handler");
            }

            return await handler.HandleAsync(query);
        }
    }
}