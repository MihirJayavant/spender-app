using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Data;
using Core.Transactional;

namespace Core.Services
{
    public interface IDivisionService
    {
        Task<AsyncData<Division>> Add(Division receiver, int userId);
        Task<AsyncData<IReadOnlyList<Division>>> Get(int userId);
    }
}
