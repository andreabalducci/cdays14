namespace Bookings.Engine.Domain.Bookings.Resource.Events
{
    public class ResourceCreated
    {
        public ResourceId ResourceId { get; private set; }
        public ResourceName Name { get; private set; }

        public ResourceCreated(ResourceId resourceId, ResourceName name)
        {
            ResourceId = resourceId;
            Name = name;
        }
    }
}