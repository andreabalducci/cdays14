using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.Resource;

namespace Bookings.Engine.Domain.Bookings.BookingRequest.Events
{
    public class BookingRequestCreated
    {
        public BookingRequestId BookingRequestId { get; private set; }
        public ResourceId ResourceId { get; private set; }
        public BookingInterval Interval { get; private set; }
        public UserId UserId { get; private set; }

        public BookingRequestCreated(BookingRequestId id, UserId userId, ResourceId resourceId, BookingInterval interval)
        {
            UserId = userId;
            BookingRequestId = id;
            ResourceId = resourceId;
            Interval = interval;
        }
    }
}