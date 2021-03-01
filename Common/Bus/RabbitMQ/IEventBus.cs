using Common.Events;

namespace Common.Bus.RabbitMQ
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
    }
}
