namespace Bookings.Engine.Domain.Bookings.Resource.Events
{
    public class ResourceCreated
    {
        public ResourceId ResourceId { get; private set; }

        public ResourceCreated(ResourceId resourceId)
        {
            ResourceId = resourceId;
        }
    }
}