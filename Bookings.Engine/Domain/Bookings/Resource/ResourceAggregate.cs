using System;
using System.Resources;
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
            if(State.HasBeenRegistered)
                throw new DomainException(string.Format(
                    "Resource {1} [{0}] has already been registered",
                    State.Id, 
                    State.Name));

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
                throw new DomainException("Reservation not allowed");
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
