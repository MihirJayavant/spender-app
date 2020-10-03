using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Data;
using Core.Transactional;

namespace Core.Services
{
    public interface IReceiverService
    {
        Task<AsyncData<Receiver>> Add(Receiver receiver, int userId);
        Task<AsyncData<IReadOnlyList<Receiver>>> Get(int userId);
    }
}
