using Bookings.Engine.Domain;

namespace Bookings.Engine.Support
{
    public abstract class AggregateState<TId> where TId : AggregateId
    {
        public TId Id { get; protected internal set; }

        public virtual void EnsureAllInvariants()
        {
            if(this.Id == null)
                throw new DomainException("AggregateState Identifier is null");
        }
    }
}