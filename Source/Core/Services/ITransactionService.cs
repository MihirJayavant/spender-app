using Core.Data;
using Core.Transactional;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITransactionService
    {
        Task<AsyncData<Transaction>> Add(Transaction transaction);
    }
}
