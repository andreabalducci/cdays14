using System.Collections.Generic;
using System.Linq;
using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest;
using Bookings.Engine.Domain.Bookings.Resource.Events;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.Resource
{
    public class ResourceState : AggregateState<ResourceId>
    {
        public class Reservation
        {
            public BookingRequestId RequestId { get; private set; }
            public BookingTimeframe Timeframe { get; private set; }

            public Reservation(BookingRequestId requestId, BookingTimeframe timeframe)
            {
                RequestId = requestId;
                Timeframe = timeframe;
            }
        }

        public ResourceName Name { get; protected internal set; }
        public HashSet<UserId> Managers { get; protected internal set; }
        public IList<Reservation> Reservations { get; private set; }

        public ResourceState()
        {
            this.Managers = new HashSet<UserId>();
            this.Reservations = new List<Reservation>();
        }

        public void On(ResourceCreated e)
        {
            Id = e.ResourceId;
            Name = e.Name;
        }

        public void On(ResourceManagerAdded e)
        {
            Managers.Add(e.ManagerId);
        }

        public void On(ResourceBooked e)
        {
            this.Reservations.Add(new Reservation(e.RequestId, e.Timeframe));
        }

        public bool IsManager(UserId userId)
        {
            return Managers.Contains(userId);
        }

        public override void EnsureAllInvariants()
        {
            base.EnsureAllInvariants();

            if(this.Name == null)
                throw new DomainException("Resource name not set");

            if(!this.Managers.Any())
                throw new DomainException(string.Format("Resource {0} needs a manager", this.Name));
        }

        public bool IsResourceAvailable(BookingTimeframe timeframe)
        {
            return true;
        }
    }
}