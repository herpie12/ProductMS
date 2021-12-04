using ProductMS.Domain.DomainEvents;

namespace ProductMS.Application.Services.EventBus
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }
}
