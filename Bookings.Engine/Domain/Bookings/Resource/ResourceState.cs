using Bookings.Engine.Domain.Bookings.Resource.Events;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.Resource
{
    public class ResourceState : AggregateState<ResourceId>
    {
        public ResourceName Name { get; private set; }

        public void On(ResourceCreated e)
        {
            Id = e.ResourceId;
            Name = e.Name;
        }


        public override void EnsureAllInvariants()
        {
            base.EnsureAllInvariants();

            if(this.Name == null)
                throw new DomainException("Resource name not set");
        }
    }
}