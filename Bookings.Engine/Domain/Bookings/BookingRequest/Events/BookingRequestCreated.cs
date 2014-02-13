using Bookings.Engine.Domain.Bookings.Resource;

namespace Bookings.Engine.Domain.Bookings.BookingRequest.Events
{
    public class BookingRequestCreated
    {
        public BookingRequestId BookingRequestId { get; private set; }
        public ResourceId ResourceId { get; private set; }
        public BookingTimeframe Timeframe { get; private set; }

        public BookingRequestCreated(
            BookingRequestId id, 
            ResourceId resourceId, 
            BookingTimeframe timeframe
            )
        {
            BookingRequestId = id;
            ResourceId = resourceId;
            Timeframe = timeframe;
        }
    }
}