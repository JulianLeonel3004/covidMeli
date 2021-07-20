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
        private readonly AplicationDbContext context; 

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

        public async Task<IList<Person>> GetByCountry(int id, int? id2)
        {
            return await context.People
                    .Include(x => x.Country)
                    .Include(x => x.Result)
                    .Where(x => x.IdCountry == id || x.IdCountry == id2)
                    .OrderByDescending(x => x.Id).ToListAsync();
        }
        public async Task<IList<Person>> GetByResult(int id, int? id2)
        {
            return await context.People
                   .Include(x => x.Country)
                   .Include(x => x.Result)
                   .Where(x => x.IdResult == id || x.IdResult == id2)
                   .OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await context.People
                   .Include(x => x.Country)
                   .Include(x => x.Result)
                   .Where(x => x.Id == id)
                   .OrderByDescending(x => x.Id).SingleAsync();
        }


        public void insert(Person person)
        {
            try
            {
                context.Set<Person>().Add(person);
                context.SaveChanges();

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
