using System;
using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest;
using Bookings.Engine.Domain.Bookings.Resource.Events;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.Resource
{
    public class ResourceAggregate : Aggregate<ResourceState, ResourceId>
    {
        public ResourceAggregate() : base (new ResourceState())
        {
        }

        public void Register(ResourceId id, ResourceName name, UserId managerId)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            if (name == null)
                throw new ArgumentNullException("name");

            if (managerId == null)
                throw new ArgumentNullException("managerId");

            RaiseEvent(new ResourceRegistered(id, name));
            RaiseEvent(new ResourceManagerAdded(managerId));
        }

        public void AddReservation(
            BookingRequestId requestId,
            UserId approvedByUserId,
            BookingInterval interval
        )
        {
            if (!State.IsManager(approvedByUserId))
            {

                return;
            }

            if (State.IsResourceAvailable(interval))
            {
                RaiseEvent(new ResourceReserved(requestId, approvedByUserId, interval));
            }
            else
            {
                RaiseEvent(new ResourceReservationFailed(requestId, "Unavailable"));
            }
        }
    }
}
