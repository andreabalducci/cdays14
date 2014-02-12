using Bookings.Engine.Support;
using Machine.Specifications;

namespace Bookings.Specs.Evenstore
{
    // ReSharper disable InconsistentNaming

    [Subject("Store")]
    public class StoreSpecs
    {
        private static EvenstoreBootstrapper _bootstrapper;

        Establish context = () =>
        {
            _bootstrapper = new EvenstoreBootstrapper();
        };
        
        Because of = () =>
        {
            _bootstrapper.Start();
        };

        It store_is_running = () =>
        {

        };
    }
}
