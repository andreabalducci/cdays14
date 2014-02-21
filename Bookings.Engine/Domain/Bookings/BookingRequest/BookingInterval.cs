using System;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingInterval
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public BookingInterval(DateTime from, DateTime to)
        {
            if(to < from)
                throw new DomainException("Invalid Interval");
            
            From = from;
            To = to;
        }

        public bool Overlaps(BookingInterval other)
        {
            return this.From <= other.To && this.To >= other.From;
        }

        public static BookingInterval Build(DateTime from, int days)
        {
            return new BookingInterval(from, from.AddDays(days));
        }
    }
}