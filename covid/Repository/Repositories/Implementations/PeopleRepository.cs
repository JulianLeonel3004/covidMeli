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
        public IList<Person> GetAllAsync()
        {
            //var collection =  await _context.People
            //      .OrderByDescending(x => x.Id).ToListAsync();
            try
            {
                var collection = context.Set<Person>().ToList();
                return collection;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                
                return new List<Person>();
            }

            
;
        }
    }
}
