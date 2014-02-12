using System;
using Bookings.Engine.Support;
using CommonDomain.Core;

namespace Bookings.Engine.Domain.Bookings
{
    public class ResourceId : AggreagateId
    {
    }

    public class ResourceState : AggregateState<ResourceId>
    {
        public void On(ResourceCreated e)
        {
             Id = e.ResourceId;
        }
    }

    public class Resource : Aggregate<ResourceState, ResourceId>
    {
        public Resource(ResourceState state = null) : base(state ?? new ResourceState())
        {
        }

        public Resource() : this(null)
        {
        }

        public void Create(ResourceId resourceId)
        {
            RaiseEvent(new ResourceCreated(resourceId));
        }
    }

    public class ResourceCreated
    {
        public ResourceId ResourceId { get; private set; }

        public ResourceCreated(ResourceId resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
