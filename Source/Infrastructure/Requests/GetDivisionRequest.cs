﻿using System.Threading.Tasks;
using t = Core.Transactional;
using Infrastructure.Database;
using Core.Data;
using System;
using Infrastructure.Essentials;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Requests
{

    public class GetDivisionRequest : IAyncRequest<Paginated<IList<t.Division>>>
    {
        readonly Paginated<int> payload;
        readonly IDbOption option;

        public GetDivisionRequest(Paginated<int> payload, IDbOption option)
            => (this.payload, this.option) = (payload, option);

        public async Task<AsyncData<Paginated<IList<t.Division>>>> RunAsync()
        {
            try
            {
                using var db = new ApplicationContext(option);
                var result = await db.Divisions
                                .Where(d => d.UserId == payload.Data)
                                .Skip(payload.Offset)
                                .Take(payload.Limit)
                                .Select(d => d.ToCore())
                                .ToListAsync();
                return AsyncData<Paginated<IList<t.Division>>>.Loaded(
                    new Paginated<IList<t.Division>>(result, payload.Limit, payload.Offset)
                    );
            }
            catch (Exception e)
            {
                return AsyncData<Paginated<IList<t.Division>>>.ErrorMessage(e.Message);
            }
        }

    }
}
