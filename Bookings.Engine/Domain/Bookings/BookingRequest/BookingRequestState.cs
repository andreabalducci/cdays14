using Bookings.Engine.Domain.Bookings.BookingRequest.Events;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingRequestState : AggregateState<BookingRequestId>
    {
        public void On(BookingRequestCreated e)
        {
            this.Id = e.BookingRequestId;
        }
    }
}