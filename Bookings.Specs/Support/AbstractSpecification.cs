using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Support;
using CommonDomain;

namespace Bookings.Specs.Support
{
    public abstract class AbstractSpecification<TAggregate, TState, TId> 
        where TAggregate: Aggregate<TState, TId>, new() 
        where TState : AggregateState<TId> 
        where TId : AggreagateId
    {
        public static TAggregate Aggregate { get; private set; }

        protected static void SetUp(TAggregate aggregate = null)
        {
            Aggregate = aggregate ?? new TAggregate();
        }

        protected static TState State {
            get { return Aggregate.State;  }
        }

        protected static TEvent LastRaisedEventOfType<TEvent>() where TEvent : class
        {
            return UncommittedEvents.OfType<TEvent>().LastOrDefault();
        }

        protected static IEnumerable<object> UncommittedEvents
        {
            get
            {
                IAggregate agg = Aggregate;
                return agg.GetUncommittedEvents().Cast<object>();
            }
        }
    }
}
