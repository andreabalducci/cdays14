using Bookings.Engine.Domain.Bookings.Resource.Events;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.Resource
{
    public class ResourceAggregate : Aggregate<ResourceState, ResourceId>
    {
        public ResourceAggregate(ResourceState state = null) : base(state ?? new ResourceState())
        {
        }

        public ResourceAggregate() : this(null)
        {
        }

        public void Create(ResourceId id, ResourceName name)
        {
            RaiseEvent(new ResourceCreated(id, name));
        }
    }
}
