using Bookings.Engine.Domain.Auth.Users;

namespace Bookings.Engine.Domain.Bookings.Resource.Events
{
    public class ResourceManagerAdded
    {
        public UserId ManagerId { get; private set; }

        public ResourceManagerAdded(UserId managerId)
        {
            ManagerId = managerId;
        }
    }
}