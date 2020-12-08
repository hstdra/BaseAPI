using FastO.Core.Events;
using MediatR;
using System;

namespace FastO.Infrastructure.Events
{
    public class Event : IEvent, INotification
    {
        public Guid Id { get; } = Guid.NewGuid();

        public DateTime CreatedUtc { get; } = DateTime.UtcNow;
    }
}
