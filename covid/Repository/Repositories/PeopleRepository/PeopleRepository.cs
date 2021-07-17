using Microsoft.EntityFrameworkCore;
using Model.People;
using Persistence.Repositories.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Implementations
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AplicationDbContext context;  ///Inyección de dependencia del entity framework

        public PeopleRepository(AplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IList<Person>> GetAllAsync()
        {
           return await context.People
                    .Include(x => x.Country)
                    .Include(x => x.Result)
                    .OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}
