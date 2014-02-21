using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest.Events;
using Bookings.Engine.Domain.Bookings.Resource;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingRequestAggregate : Aggregate<BookingRequestState, BookingRequestId>
    {
        public BookingRequestAggregate() : base(new BookingRequestState())
        {
        }

        public void Create(BookingRequestId id, UserId userId, ResourceId resourceId, BookingInterval interval)
        {
            RaiseEvent(new BookingRequestCreated(id, userId, resourceId, interval));
        }

        public void Authorize(UserId authorizedByUserId)
        {
            RaiseEvent(new BookingRequestAuthorized(authorizedByUserId));
        }
    }
}
