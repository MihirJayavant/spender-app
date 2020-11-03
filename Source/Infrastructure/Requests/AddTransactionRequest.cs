
using System.Threading.Tasks;
using t = Core.Transactional;
using Infrastructure.Database;
using Core.Data;
using Infrastructure.Database.Entities;
using System;
using Infrastructure.Essentials;


namespace Infrastructure.Requests
{
    public class AddTransactionRequest : IAyncRequest<t.Transaction>
    {
        readonly int divisonId;
        readonly t.Transaction transaction;
        readonly IDbOption option;

        public AddTransactionRequest(int divisonId, t.Transaction transaction, IDbOption option)
            => (this.divisonId, this.transaction, this.option) = (divisonId, transaction, option);

        public async Task<AsyncData<t.Transaction>> RunAsync()
        {
            try
            {
                using var db = new ApplicationContext(option);
                var temp = Transaction.Parse(transaction);
                temp.DivisionId = divisonId;
                var result = await db.Transactions.AddAsync(temp);
                await db.SaveChangesAsync();
                return AsyncData<t.Transaction>.Loaded(result.Entity.ToCore());
            }
            catch (Exception e)
            {
                return AsyncData<t.Transaction>.ErrorMessage(e.Message);
            }
        }

    }
}
