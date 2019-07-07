using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Common.Types
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public DateTime DateUpdated { get; protected set; }
    }
}
