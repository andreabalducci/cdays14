using Bookings.Engine.Domain.Bookings.BookingRequest;

namespace Bookings.Engine.Domain.Bookings.Resource.Events
{
    public class ResourceBookingFailed
    {
        public BookingRequestId RequestId { get; private set; }
        public string Reason { get; private set; }

        public ResourceBookingFailed(BookingRequestId requestId, string reason)
        {
            RequestId = requestId;
            Reason = reason;
        }
    }
}