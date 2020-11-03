using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Data;
using Core.Transactional;

namespace Core.Services
{
    public interface IDivisionService
    {
        Task<AsyncData<Division>> Add(Division division, int userId);
        Task<AsyncData<Paginated<IList<Division>>>> Get(int userId);
    }
}
