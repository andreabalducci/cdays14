using Bookings.Engine.Domain.Bookings;
using Bookings.Engine.Domain.Bookings.Resource;
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
        
        It the_identifier_should_be_set = () =>
            State.Id.ShouldBeLike(_resourceId);

        It the_name_should_be_set = () =>
            State.Name.ShouldBeLike(_resourceName);
    }
}