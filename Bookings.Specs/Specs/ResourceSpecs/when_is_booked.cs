using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest;
using Bookings.Engine.Domain.Bookings.Resource;
using Bookings.Engine.Domain.Bookings.Resource.Events;
using Machine.Specifications;

// ReSharper disable InconsistentNaming

namespace Bookings.Specs.Specs.ResourceSpecs
{
    [Subject("Given a resource without bookings")]
    public class when_is_booked : in_resource_context
    {
        private static readonly BookingRequestId _requestId = new BookingRequestId();
        
        private static readonly BookingTimeframe _timeframe = new BookingTimeframe(
            DateTime.Parse("2014-01-01"), 
            DateTime.Parse("2014-01-10")
        );

        private static readonly UserId _managerId = new UserId();

        Establish content = () => 
            SetUp(new ResourceState(){
                Id = new ResourceId(),
                Name = new ResourceName("Surface Pro"),
                Managers = new HashSet<UserId>(new[]{_managerId})
            });

        Because of = () =>
            Resource.Book(_requestId, _managerId,  _timeframe);

        It resource_booked_event_should_be_raised = () =>
            LastRaisedEventOfType<ResourceBooked>().ShouldNotBeNull();

        It resource_booked_event_should_have_the_timeframe_set = () =>
            LastRaisedEventOfType<ResourceBooked>().Timeframe.ShouldBeTheSameAs(_timeframe);

        It resource_booked_event_should_have_the_approving_user_id_set = () =>
            LastRaisedEventOfType<ResourceBooked>().ApprovedByUserId.ShouldBeLike(_managerId);

        It resource_booked_event_should_have_the_request_id_set = () =>
            LastRaisedEventOfType<ResourceBooked>().RequestId.ShouldBeLike(_requestId);


        It invariants_should_be_satisfied = () =>
            Resource.EnsureAllInvariants();
    }
}