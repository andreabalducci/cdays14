namespace Bookings.Engine.Domain.Bookings.Resource.Events
{
    public class ResourceRegistered
    {
        public ResourceId ResourceId { get; private set; }
        public ResourceName Name { get; private set; }

        public ResourceRegistered(ResourceId resourceId, ResourceName name)
        {
            ResourceId = resourceId;
            Name = name;
        }
    }
}