using System;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingTimeframe
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public BookingTimeframe(DateTime from, DateTime to)
        {
            if(to < from)
                throw new DomainException("Invalid timeframe");
            
            From = from;
            To = to;
        }

        public bool Overlaps(BookingTimeframe other)
        {
            return this.From <= other.To && this.To >= other.From;
        }

        public static BookingTimeframe Build(DateTime from, int days)
        {
            return new BookingTimeframe(from, from.AddDays(days));
        }
    }
}