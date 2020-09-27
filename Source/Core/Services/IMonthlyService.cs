using Core.Data;
using Core.Transactional;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IMonthlyService
    {
        Task<AsyncData<MonthlyStatement>> Add(MonthlyStatement user);
    }
}
