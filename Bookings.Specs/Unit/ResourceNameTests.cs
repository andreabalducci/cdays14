using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Domain;
using Bookings.Engine.Domain.Bookings.Resource;
using NUnit.Framework;

namespace Bookings.Specs.Unit
{
    [TestFixture]
    public class ResourceNameTests
    {
        [Test]
        public void creating_a_resource_name_with_a_name_shorter_than_expected_should_thow()
        {
            var ex = Assert.Throws<DomainException>(() =>
            {
                new ResourceName("short");
            });

            Assert.AreEqual("Resource name too short (min len = 6)", ex.Message);
        }

        [Test]
        public void creating_a_resource_name_with_a_null_name_should_throw()
        {
            var ex = Assert.Throws<System.ArgumentNullException>(() =>
            {
                new ResourceName(null);
            });
            Assert.AreEqual("Value cannot be null.\r\nParameter name: name", ex.Message);
        }

        [Test]
        public void creating_a_resource_name_with_a_valid_name_should_succeed()
        {
            var name = new ResourceName("long name");
            Assert.AreEqual(name.ToString(), "long name");
        }

        [Test]
        public void two_resource_names_with_same_value_should_be_equals()
        {
            var name1 = new ResourceName("I AM A RESOURCE!");
            var name2 = new ResourceName("I AM A RESOURCE!");

            Assert.AreEqual(name1, name2);
        }

        [Test]
        public void two_resource_names_with_different_value_should_be_equals()
        {
            var name1 = new ResourceName("I AM A RESOURCE!");
            var name2 = new ResourceName("I AM A DIFFERENT RESOURCE!");

            Assert.AreNotEqual(name1, name2);
        }

    }
}
