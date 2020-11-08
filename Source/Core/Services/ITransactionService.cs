using Core.Data;
using Core.Transactional;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITransactionService
    {
        Task<AsyncData<Transaction>> Add(int divisionId, Transaction transaction);
        Task<AsyncData<PaginatedResult<Transaction>>> GetAll(int divisionId, int limit, int offest);
    }
}
