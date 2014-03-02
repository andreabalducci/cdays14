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
    [Subject("Given a resource with bookings")]
    public class resource_with_bookings
    {
        public class when_a_reservation_is_made_for_an_interval_already_reserved : in_resource_context
        {
            private static readonly BookingRequestId _requestId = new BookingRequestId();

            private static readonly BookingInterval Interval = new BookingInterval(
                DateTime.Parse("2014-01-01"),
                DateTime.Parse("2014-01-10")
            );

            private static readonly UserId _managerId = new UserId();

            private Establish context = () =>
            {
                var state = new ResourceState()
                {
                    Id = new ResourceId(),
                    Name = new ResourceName("Surface Pro"),
                    Managers = new HashSet<UserId>(new[] { _managerId })
                };

                state.Reservations.Add(
                    new ResourceState.Reservation(
                        new BookingRequestId(),
                        new BookingInterval(
                            DateTime.Parse("2014-01-03"),
                            DateTime.Parse("2014-01-07")
                        )
                    )
                );

                SetUp(state);
            };

            Because of = () =>
                Resource.AddReservation(_requestId, _managerId, Interval);

            It resource_reserved_event_should_not_be_raised = () =>
                LastRaisedEventOfType<ResourceReserved>().ShouldBeNull();

            It resource_reservation_failed_event_should_be_raised = () =>
                LastRaisedEventOfType<ResourceReservationFailed>().ShouldNotBeNull();

            It resource_reservation_failed_event_should_contain_the_request_id = () =>
                LastRaisedEventOfType<ResourceReservationFailed>().RequestId.ShouldBeLike(_requestId);

            It invariants_should_be_satisfied = () =>
                Resource.EnsureAllInvariants();
        }
    }
}
