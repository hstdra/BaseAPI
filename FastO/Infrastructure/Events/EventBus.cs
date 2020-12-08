using FastO.Core.Events;
using System;
using System.Threading.Tasks;

namespace FastO.Infrastructure.Events
{
    public class EventBus : IEventBus
    {
        public Task Publish(IEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
