using Bookings.Engine.Domain.Bookings.BookingRequest.Events;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingRequestState : AggregateState<BookingRequestId>
    {
        public bool HasBeenAuthorized { get; private set; }

        public void On(BookingRequestCreated e)
        {
            this.Id = e.BookingRequestId;
        }

        public void On(BookingRequestAuthorized e)
        {
            HasBeenAuthorized = true;
        }
    }
}