using System;

namespace FastO.Core.DDD
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
    }
}
