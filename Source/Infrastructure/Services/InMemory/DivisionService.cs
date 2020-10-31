

using Core.Data;
using Core.Services;
using Core.Transactional;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.InMemory
{
    public class DivisionService : IDivisionService
    {
        readonly IList<Division> divisions = new List<Division>();

        public DivisionService()
        {
            var div1 = new Division(0, "Salary", "", Categories.Parse(CategoryType.Salary), DateTime.Now, DateTime.Now);
            var div2 = new Division(0, "Others", "", Categories.Parse(CategoryType.Other), DateTime.Now, DateTime.Now);
            divisions.Add(div1);
            divisions.Add(div2);
        }


        public Task<AsyncData<Division>> Add(Division division, int userId)
        {
            divisions.Add(division);
            return Task.FromResult(AsyncData<Division>.Loaded(division));
        }

        public Task<AsyncData<IList<Division>>> Get(int userId) 
            => Task.FromResult(AsyncData<IList<Division>>.Loaded(divisions));
    }
}
