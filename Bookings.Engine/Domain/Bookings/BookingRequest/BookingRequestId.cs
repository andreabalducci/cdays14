using System;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingRequestId : AggreagateId
    {

    }

    public class BookingTimeframe
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public BookingTimeframe(DateTime from, DateTime to)
        {
            From = @from;
            To = to;
            if(to <= from)
                throw new DomainException("Invalid timeframe");
        }
    }
}