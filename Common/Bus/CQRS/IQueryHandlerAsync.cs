using eMobile.Common.Query;
using System.Threading.Tasks;

namespace eMobile.Common.Bus.CQRS
{
    public interface IQueryHandlerAsync<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
