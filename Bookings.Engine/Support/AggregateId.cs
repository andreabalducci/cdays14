using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Engine.Support
{
    public abstract class AggregateId
    {
        public Guid Id { get; private set; }

        protected AggregateId()
        {
            this.Id = Guid.NewGuid();
        }

        public static implicit operator Guid(AggregateId id)
        {
            return id.Id;
        }
    }
}
