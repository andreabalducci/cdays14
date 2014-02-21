using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Engine.Domain;
using Bookings.Engine.Domain.Bookings.BookingRequest;
using NUnit.Framework;

namespace Bookings.Specs.Unit
{
    [TestFixture]
    public class BookingIntervalTests
    {
        [Test]
        public void creating_interval_with_inverted_dates_should_throw()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var ex = Assert.Throws<DomainException>(() => new BookingInterval(tomorrow, today));

            Assert.AreEqual(ex.Message, "Invalid Interval");
        }

        [Test]
        [TestCase("2014-01-01", "2014-01-02", "2014-02-01", "2014-02-02", false)]
        [TestCase("2014-01-01", "2014-01-01", "2014-01-01", "2014-01-01", true)]
        [TestCase("2014-01-01", "2014-01-01", "2014-01-01", "2014-01-02", true)]
        [TestCase("2014-01-01", "2014-01-05", "2014-01-04", "2014-01-10", true)]
        [TestCase("2014-01-01", "2014-01-05", "2014-01-05", "2014-01-10", true)]
        [TestCase("2014-01-01", "2014-12-31", "2014-01-05", "2014-01-10", true)]
        [TestCase("2014-12-01", "2014-12-31", "2014-01-05", "2014-01-10", false)]
        public void overlapping(DateTime start1, DateTime end1, DateTime start2, DateTime end2, bool overlaps)
        {
            var tf1 = new BookingInterval(start1, end1);
            var tf2 = new BookingInterval(start2, end2);

            Assert.AreEqual(overlaps, tf1.Overlaps(tf2));
        }
    }
}
