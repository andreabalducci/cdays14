using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Domain;
using CommonDomain;
using CommonDomain.Core;

namespace Bookings.Engine.Support
{
    public abstract class AggreagateId
    {
        public Guid Id { get; private set; }

        public AggreagateId()
        {
            this.Id = Guid.NewGuid();
        }

        public static implicit operator Guid(AggreagateId id)
        {
            return id.Id;
        }
    }

    public abstract class AggregateState<TId> where TId : AggreagateId
    {
        public TId Id { get; protected set; }

        public virtual void EnsureAllInvariants()
        {
            if(this.Id == null)
                throw new DomainException("AggregateState Identifier is null");
        }
    }

    public abstract class Aggregate<TState, TId> : AggregateBase 
        where TState : AggregateState<TId> 
        where TId : AggreagateId
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

    public class EventRouter<TState, TId> : IRouteEvents
        where TState : AggregateState<TId>
        where TId : AggreagateId
    {
        private Aggregate<TState, TId> Aggregate { get; set; }

        public void Attach(Aggregate<TState, TId> aggregate)
        {
            this.Aggregate = aggregate;
        }

        public EventRouter()
        {
        }

        public void Register<T>(Action<T> handler)
        {
        }

        public void Register(IAggregate aggregate)
        {
        }

        public void Dispatch(object eventMessage)
        {
            ((dynamic)Aggregate.State).On((dynamic)eventMessage);
            if (Aggregate.Version == 0)
            {
                Aggregate.SetIdFromState();
            }
        }
    }
}
