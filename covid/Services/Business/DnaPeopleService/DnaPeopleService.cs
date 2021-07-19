using Model;
using Model.MasterModel;
using Model.People;
using Persistence.Repositories.DnaPeopleRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business.DnaPeopleService
{
    public class DnaPeopleService : IDnaPeopleService
    {
        private IDnaPeopleRepository dnaPeopleRepository;

        public DnaPeopleService(IDnaPeopleRepository dnaPeopleRepository)
        {
            this.dnaPeopleRepository = dnaPeopleRepository;
        }

        public IList<DnaPeople> getByDna(int id)
        {
            return dnaPeopleRepository.getByIdDna(id);
        }

        public IList<DnaPeople> getByPeople(int id)
        {
            return dnaPeopleRepository.getByIdPeople(id);
        }

        public void insertDnaPeople(Person person)
        {

            if (person.Dna == null)
                return;

            List<DnaPeople> dnaPeople = new List<DnaPeople>();

            foreach (Dna dna in person.Dna)
            {
                dnaPeople.Add(new DnaPeople(dna.Id, person.Id));
            }

            dnaPeopleRepository.insertList(dnaPeople);
        }
    }
}
