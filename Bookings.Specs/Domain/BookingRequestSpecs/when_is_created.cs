using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest;
using Bookings.Engine.Domain.Bookings.BookingRequest.Events;
using Bookings.Engine.Domain.Bookings.Resource;
using Machine.Specifications;

// ReSharper disable InconsistentNaming

namespace Bookings.Specs.Domain.BookingRequestSpecs
{
    [Subject("Given a new BookingRequest")]
    public class when_is_created : in_bookingRequest_context
    {
        private static readonly BookingRequestId _requestId = new BookingRequestId();
        private static readonly ResourceId _resourceId = new ResourceId();
        private static readonly UserId _userId = new UserId();

        Establish context = () =>
            SetUp();

        Because of = () =>
            Aggregate.Create(
                _requestId,
                _userId,
                _resourceId,
                new BookingTimeframe(
                    DateTime.Parse("2014-01-01"),
                    DateTime.Parse("2014-01-03")
                )
            );

        //
        // State 
        //
        It the_identifier_should_be_set = () =>
            State.Id.ShouldBeLike(_requestId);

        It request_is_unauthorized = () =>
            State.HasBeenAuthorized.ShouldBeFalse();

        //
        // Events
        // 
        It BookingRequestCreated_event_should_have_been_raised = () =>
            LastRaisedEventOfType<BookingRequestCreated>().ShouldNotBeNull();

        It BookingRequestCreated_event_shoud_have_the_resource_id_set = () =>
            LastRaisedEventOfType<BookingRequestCreated>()
                .BookingRequestId.ShouldBeLike(_requestId);

        It BookingRequestCreated_event_should_have_the_user_id_set = () =>
            LastRaisedEventOfType<BookingRequestCreated>()
                .UserId.ShouldBeLike(_userId);


        private It BookingRequestCreated_event_should_have_the_timeframe_set = () =>
        {
            var evt = LastRaisedEventOfType<BookingRequestCreated>();
            evt.Timeframe.From.ShouldBeLike(DateTime.Parse("2014-01-01"));
            evt.Timeframe.To.ShouldBeLike(DateTime.Parse("2014-01-03"));
        };

        //
        // Invariants
        //
        It invariants_are_satisfied = () =>
            Aggregate.EnsureAllInvariants();
    }
}
