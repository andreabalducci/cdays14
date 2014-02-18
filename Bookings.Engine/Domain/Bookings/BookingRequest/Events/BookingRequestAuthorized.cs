using Bookings.Engine.Domain.Auth.Users;

namespace Bookings.Engine.Domain.Bookings.BookingRequest
{
    public class BookingRequestAuthorized
    {
        public UserId AuthorizedByUserId { get; private set; }

        public BookingRequestAuthorized(UserId authorizedByUserId)
        {
            AuthorizedByUserId = authorizedByUserId;
        }
    }
}