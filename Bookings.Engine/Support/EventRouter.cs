using System;
using CommonDomain;

namespace Bookings.Engine.Support
{
    public class EventRouter<TState, TId> : IRouteEvents
        where TState : AggregateState<TId>
        where TId : AggregateId
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