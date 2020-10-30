

using Core.Data;
using Core.Services;
using Core.Transactional;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.InMemory
{
    public class DivisionService : IDivisionService
    {
        public Task<AsyncData<Division>> Add(Division receiver, int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<AsyncData<IList<Division>>> Get(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
