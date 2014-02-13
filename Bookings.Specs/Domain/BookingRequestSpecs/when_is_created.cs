using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Domain.Bookings.BookingRequest;
using Bookings.Specs.Support;
using Machine.Specifications;

// ReSharper disable InconsistentNaming

namespace Bookings.Specs.Domain.BookingRequestSpecs
{
    public class when_is_created : in_bookingRequest_context
    {

    }

    [Subject("Given a new BookingRequest")]
    public class in_bookingRequest_context : AbstractSpecification<BookingRequestAggregate,BookingRequestState, BookingRequestId>
    {
        private static BookingRequestId _id = new BookingRequestId();
        
        Establish context = () => 
            SetUp();

        Because of = () => 
            Aggregate.Create(_id);

        //
        // State changes
        //
        It the_identifier_should_be_set = () =>
            State.Id.ShouldBeLike(_id);


        //
        // Events
        // 
        It ResourceCreated_event_should_be_raised = () =>
            LastRaisedEventOfType<BookingRequestCreated>().ShouldNotBeNull();

        It ResourceCreated_event_shoud_have_the_resource_id_set = () =>
            LastRaisedEventOfType<BookingRequestCreated>()
                .BookingRequestId.ShouldBeLike(_id);

        //
        // Invariants
        //
        It invariants_are_satisfied = () =>
            Aggregate.EnsureAllInvariants();
    }
}
