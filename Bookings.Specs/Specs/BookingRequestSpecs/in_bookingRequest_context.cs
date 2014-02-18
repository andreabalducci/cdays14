using Bookings.Engine.Domain.Bookings.BookingRequest;
using Bookings.Specs.Support;

// ReSharper disable once InconsistentNaming
namespace Bookings.Specs.Specs.BookingRequestSpecs
{
    public abstract class in_bookingRequest_context : 
        AbstractSpecification<
            BookingRequestAggregate,
            BookingRequestState , 
            BookingRequestId
        >
    {
        protected static BookingRequestAggregate BookingRequest {
            get { return Aggregate; }
        }
    }
}