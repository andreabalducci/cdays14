using System.Collections.Generic;
using System.Linq;
using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.Resource.Events;
using Bookings.Engine.Support;

namespace Bookings.Engine.Domain.Bookings.Resource
{
    public class ResourceState : AggregateState<ResourceId>
    {
        public ResourceName Name { get; private set; }
        public HashSet<UserId> Managers { get; private set; }

        public ResourceState()
        {
            this.Managers = new HashSet<UserId>();
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
    }
}