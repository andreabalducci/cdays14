using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest;

namespace Bookings.Engine.Domain.Bookings.Resource.Events
{
    public class ResourceReserved
    {
        public BookingRequestId RequestId { get; private set; }
        public UserId ApprovedByUserId { get; private set; }
        public BookingInterval Interval { get; private set; }

        public ResourceReserved(
            BookingRequestId requestId,
            UserId approvedByUserId,
            BookingInterval interval
            )
        {
            RequestId = requestId;
            ApprovedByUserId = approvedByUserId;
            Interval = interval;
        }
    }
}