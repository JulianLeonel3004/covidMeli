using Model.MasterModel;
using Persistence.Repositories.DNARepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Business.DnaService
{
    public class DnaService:IDnaService
    {
        private IDnaRepository dnaRepository;
        public DnaService(IDnaRepository dnaRepository)
        {
            this.dnaRepository = dnaRepository;
        }
        public List<Dna> getDnaByDescriptions(IList<string> dnaDescriptions)
        {
            if (dnaDescriptions == null || dnaDescriptions.Count == 0)
                return null;

            List<Dna> dnas = new List<Dna>();

            foreach (string description in dnaDescriptions)
            {
                var dna = dnaRepository.getByDescription(description);
                if (dna != null)
                    dnas.Add(dna);
                else
                    dnas.Add(new Dna(description));
            }

            return dnas;
        }

        public void insertDnas(List<Dna> dnas)
        {
            List<Dna> dnaAux = dnas.Where(x => x.Id == 0).ToList();

            dnaRepository.insertList(dnaAux);


        }

        public Dna getById(int id)
        {
            return dnaRepository.getByID(id);
        }
    }
}
