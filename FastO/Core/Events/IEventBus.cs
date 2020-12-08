using System.Threading.Tasks;

namespace FastO.Core.Events
{
    public interface IEventBus
    {
        Task Publish(IEvent @event);
    }
}
