using ParkAndRide.Common.Types;
using System.Threading.Tasks;

namespace ParkAndRide.Common.CQRS
{
    public interface IDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;

        Task<TResult> QueryAsync<TResult>(IQuery query);
    }
}