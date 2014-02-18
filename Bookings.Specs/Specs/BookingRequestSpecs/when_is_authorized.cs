using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest;
using Machine.Specifications;

// ReSharper disable InconsistentNaming
namespace Bookings.Specs.Specs.BookingRequestSpecs
{
    [Subject("Given an unauthorized BookingRequest")]
    public class when_is_authorized : in_bookingRequest_context
    {
        static readonly UserId _adminId = new UserId();

        Establish context = () =>
            SetUp(new BookingRequestState() { Id = new BookingRequestId() });

        Because of = () =>
            BookingRequest.Authorize(_adminId);

        //
        // Event
        //
        It authorized_event_should_have_been_raised = () =>
            LastRaisedEventOfType<BookingRequestAuthorized>().ShouldNotBeNull();

        //
        // State
        //
        It request_is_authorized = () =>
            State.HasBeenAuthorized.ShouldBeTrue();
    }
}
