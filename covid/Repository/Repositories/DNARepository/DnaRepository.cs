using Model.MasterModel;
using Persistence.Repositories.GenericRepository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories.DNARepository
{
    public class DnaRepository:GenericRepository<Dna>, IDnaRepository
    {
        public DnaRepository(AplicationDbContext context) : base(context)
        {
        }

        public override Dna getByID(int id)
        {
            try
            {
                var query = context.Set<Dna>().Where(x => x.Id == id);
                return query.Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Dna> getAllById(int id)
        {
            return context.Set<Dna>().Where(x => x.Id == id).ToList();
        }

    }
}
