using Common.Command;
using System.Threading.Tasks;

namespace Common.Bus.CQRS
{
    public interface ICommandBusAsync
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> ExecuteAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }
}
