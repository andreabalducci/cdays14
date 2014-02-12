using Bookings.Engine.Domain.Bookings;
using Bookings.Engine.Domain.Bookings.Resource;
using Bookings.Engine.Domain.Bookings.Resource.Events;
using Machine.Specifications;

// ReSharper disable InconsistentNaming
namespace Bookings.Specs.Domain.ResourceSpecs
{
    [Subject("Given new Resource")]
    public class when_is_created : in_resource_context
    {
        static readonly ResourceId _resourceId = new ResourceId();
        static readonly ResourceName _resourceName = new ResourceName("Surface Pro");
        
        Establish context = () => 
            SetUp();
        
        Because of = () =>
            Aggregate.Create(_resourceId, _resourceName);
        
        //
        // State changes
        //
        It the_identifier_should_be_set = () =>
            State.Id.ShouldBeLike(_resourceId);

        It the_name_should_be_set = () =>
            State.Name.ShouldBeLike(_resourceName);

        //
        // Events
        //
        It ResourceCreated_event_should_be_raised = () =>
            LastRaisedEventOfType<ResourceCreated>().ShouldNotBeNull();

        It ResourceCreated_event_shoud_have_the_resource_id_set = () =>
            LastRaisedEventOfType<ResourceCreated>().ResourceId.ShouldBeLike(_resourceId);

        It ResourceCreated_event_shoud_have_the_resource_name_set = () =>
            LastRaisedEventOfType<ResourceCreated>().Name.ShouldBeLike(_resourceName);

        //
        // Invariants
        //
        It invariants_are_satisfied = () =>
            Aggregate.EnsureAllInvariants();
    }
}