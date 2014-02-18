using System;
using Bookings.Engine.Domain;
using CommonDomain.Core;

namespace Bookings.Engine.Support
{
    public abstract class Aggregate<TState, TId> : AggregateBase 
        where TState : AggregateState<TId> 
        where TId : AggregateId
    {
        protected internal TState State { get; set; }

        protected Aggregate(TState state) :base(new EventRouter<TState,TId>())
        {
            if (state == null) throw new ArgumentNullException("state");
            State = state;

            ((EventRouter<TState,TId>)this.RegisteredRoutes).Attach(this);
        }

        internal void SetIdFromState()
        {
            this.Id = this.State.Id.Id;
        }

        public void EnsureAllInvariants()
        {
            if (this.Id == Guid.Empty)
                throw new DomainException("The aggregate Id must be set");

            this.State.EnsureAllInvariants();
        }
    }
}