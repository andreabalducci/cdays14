using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.Resource;
using Bookings.Engine.Domain.Bookings.Resource.Events;
using Machine.Specifications;

// ReSharper disable InconsistentNaming
namespace Bookings.Specs.Specs.ResourceSpecs
{
    [Subject("Given new Resource")]
    public class when_is_registered : in_resource_context
    {
        static readonly ResourceId _resourceId = new ResourceId();
        static readonly ResourceName _resourceName = new ResourceName("Surface Pro");
        static readonly UserId _managerId = new UserId();

        // Factory
        Establish context = () => 
            SetUp();    
        
        // Command
        Because of = () =>
            Resource.Register(_resourceId, _resourceName, _managerId);
        
        //
        // State changes
        //
        It the_identifier_should_be_set = () =>
            State.Id.ShouldBeLike(_resourceId);

        It the_name_should_be_set = () =>
            State.Name.ShouldBeLike(_resourceName);

        It the_manager_has_been_set = () =>
            State.IsManager(_managerId).ShouldBeTrue();

        //
        // Events
        //
        It ResourceRegistered_event_should_have_been_raised = () =>
            LastRaisedEventOfType<ResourceRegistered>().ShouldNotBeNull();

        It ResourceRegistered_event_shoud_have_the_resource_id_set = () =>
            LastRaisedEventOfType<ResourceRegistered>().ResourceId.ShouldBeLike(_resourceId);

        It ResourceRegistered_event_shoud_have_the_resource_name_set = () =>
            LastRaisedEventOfType<ResourceRegistered>().Name.ShouldBeLike(_resourceName);

        //
        // Invariants
        //
        It invariants_are_satisfied = () =>
            Resource.EnsureAllInvariants();
    }
}