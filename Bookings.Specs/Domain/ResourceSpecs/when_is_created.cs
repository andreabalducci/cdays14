using Bookings.Engine.Domain.Bookings;
using Machine.Specifications;

// ReSharper disable InconsistentNaming
namespace Bookings.Specs.Domain.ResourceSpecs
{
    [Subject("Given new Resource")]
    public class when_is_created : in_resource_context
    {
        static readonly ResourceId _resourceId = new ResourceId();
        
        Establish context = () => 
            SetUp();
        
        Because of = () => 
            Aggregate.Create(_resourceId);
        
        It then_the_identifier_should_be_set = () =>
            State.Id.ShouldBeLike(_resourceId);
    }
}