using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using NEventStore;
using NEventStore.Dispatcher;

namespace Bookings.Engine.Support
{
    public class Eventstore
    {
        private IStoreEvents _store;
        private readonly IDispatchCommits _dispatcher;

        public Eventstore(IDispatchCommits dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Start()
        {
            _store = Wireup.Init()
                .UsingInMemoryPersistence()
                .InitializeStorageEngine()
                .UsingSynchronousDispatchScheduler(_dispatcher)
                .Build();
        }

        public void Stop()
        {
            _store.Dispose();
            _store = null;
        }

        public IRepository GetRepository()
        {
            return new EventStoreRepository(
                _store, 
                new AggregateFactory(), 
                new ConflictDetector()
            );
        }
    }
}
