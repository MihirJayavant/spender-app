
using System.Threading.Tasks;
using t = Core.Transactional;
using Infrastructure.Database;
using Core.Data;
using Infrastructure.Database.Entities;
using System;
using Infrastructure.Essentials;

namespace Infrastructure.Requests
{
    public class AddDivisionRequest : IAyncRequest<t.Division>
    {
        readonly int userId;
        readonly t.Division division;
        readonly IDbOption option;

        public AddDivisionRequest(int userId, t.Division division, IDbOption option)
            => (this.userId, this.division, this.option) = (userId, division, option);

        public async Task<AsyncData<t.Division>> RunAsync()
        {
            try
            {
                using var db = new ApplicationContext(option);
                var temp = Division.Parse(division);
                temp.UserId = userId;
                var result = await db.Divisions.AddAsync(temp);
                await db.SaveChangesAsync();
                return AsyncData<t.Division>.Loaded(result.Entity.ToCore());
            }
            catch (Exception e)
            {
                return AsyncData<t.Division>.ErrorMessage(e.Message);
            }
        }

    }
}
