using ParkAndRide.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkAndRide.Common.CQRS
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery 
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
