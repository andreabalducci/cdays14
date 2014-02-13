using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingRequestAggregate : Aggregate<BookingRequestState, BookingRequestId>
    {
        public BookingRequestAggregate(BookingRequestState state) : base(state)
        {
        }

        public BookingRequestAggregate() : base(new BookingRequestState())
        {
        }

        public void Create(BookingRequestId id)
        {
            RaiseEvent(new BookingRequestCreated(id));
        }
    }

    public class BookingRequestCreated
    {
        public BookingRequestId BookingRequestId { get; set; }

        public BookingRequestCreated(BookingRequestId id)
        {
            BookingRequestId = id;
        }
    }

    public class BookingRequestState : AggregateState<BookingRequestId>
    {
        public void On(BookingRequestCreated e)
        {
            this.Id = e.BookingRequestId;
        }
    }

    public class BookingRequestId : AggreagateId
    {
    }
}
