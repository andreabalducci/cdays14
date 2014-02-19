using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest;

namespace Bookings.Engine.Domain.Bookings.Resource.Events
{
    public class ResourceBooked
    {
        public BookingRequestId RequestId { get; private set; }
        public UserId ApprovedByUserId { get; private set; }
        public BookingTimeframe Timeframe { get; private set; }

        public ResourceBooked(
            BookingRequestId requestId,
            UserId approvedByUserId,
            BookingTimeframe timeframe
            )
        {
            RequestId = requestId;
            ApprovedByUserId = approvedByUserId;
            Timeframe = timeframe;
        }
    }
}