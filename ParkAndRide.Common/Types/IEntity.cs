using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide.Common.Types
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
