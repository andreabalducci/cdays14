using Bookings.Engine.Domain.Bookings.Resource.Events;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.Resource
{
    public class ResourceState : AggregateState<ResourceId>
    {
        public void On(ResourceCreated e)
        {
            Id = e.ResourceId;
        }
    }
}