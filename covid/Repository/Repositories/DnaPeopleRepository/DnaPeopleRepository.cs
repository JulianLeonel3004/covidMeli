using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories.DnaPeopleRepository
{
    public class DnaPeopleRepository : IDnaPeopleRepository
    {
        private AplicationDbContext context;
        public DnaPeopleRepository(AplicationDbContext context)
        {
            this.context = context;
        }
        public IList<DnaPeople> getAll()
        {
            return context.Set<DnaPeople>().ToList();
        }

        public IList<DnaPeople> getByIdDna(int idDna)
        {
            return context.Set<DnaPeople>().Where(x => x.IdDna == idDna).ToList();
        }

        public IList<DnaPeople> getByIdPeople(int idPeople)
        {
            return context.Set<DnaPeople>().Where(x => x.IdPeople == idPeople).ToList();
        }

        public void insert(DnaPeople dnaPeople)
        {
            context.Set<DnaPeople>().Add(dnaPeople);
            context.SaveChanges();
        }

        public void insertList(IList<DnaPeople> dnaPeople)
        {
            foreach(DnaPeople dnaP in dnaPeople)
            {
                context.Set<DnaPeople>().Add(dnaP);
            }

            context.SaveChanges();
        }
    }
}
