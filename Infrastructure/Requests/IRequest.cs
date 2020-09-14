using Core.AsyncData;
using System.Threading.Tasks;

namespace Infrastructure.Requests
{
    public interface IRequest<T>
    {
        T RunAsync();
    }

    public interface IAyncRequest<T> : IRequest<Task<AsyncData<T>>> where T : class
    {

    }
}
