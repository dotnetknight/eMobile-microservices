using eMobile.Common.Query;
using System.Threading.Tasks;

namespace eMobile.Common.Bus.CQRS
{
    public interface IQueryBusAsync
    {
        Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
