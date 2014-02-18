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
    public class BookingTimeframeTests
    {
        [Test]
        public void creating_timeframe_with_inverted_dates_should_throw()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var ex = Assert.Throws<DomainException>(() => new BookingTimeframe(tomorrow, today));

            Assert.AreEqual(ex.Message, "Invalid timeframe");
        }
    }
}
