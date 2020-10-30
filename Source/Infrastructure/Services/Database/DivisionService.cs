

using Core.Data;
using Core.Services;
using Core.Transactional;
using Infrastructure.Essentials;
using Infrastructure.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Database
{
    public class DivisionService : IDivisionService
    {
        readonly IDbOption options;
        public DivisionService(IDbOption option) => this.options = option;

        public async Task<AsyncData<Division>> Add(Division receiver, int userId) 
            => await new AddDivisionRequest(userId, receiver, options).RunAsync();

        public async Task<AsyncData<IList<Division>>> Get(int userId)
            => await new GetDivisionRequest(userId, options).RunAsync();
    }
}
