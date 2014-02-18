using System;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingTimeframe
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public BookingTimeframe(DateTime from, DateTime to)
        {
            if(to <= from)
                throw new DomainException("Invalid timeframe");
            
            From = from;
            To = to;
        }
    }
}