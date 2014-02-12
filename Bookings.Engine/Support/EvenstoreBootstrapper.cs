using NEventStore;

namespace Bookings.Engine.Support
{
    public class EvenstoreBootstrapper
    {
        private IStoreEvents _store;

        public void Start()
        {
            _store = Wireup.Init()
                .UsingInMemoryPersistence()
                .InitializeStorageEngine()
                .UsingSynchronousDispatchScheduler()
                .Build();
        }

        public void Stop()
        {
            _store.Dispose();
            _store = null;
        }
    }
}
