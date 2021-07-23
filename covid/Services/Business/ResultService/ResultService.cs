using Model.MasterModel;
using Persistence.Repositories.ResultRepository;
using System.Collections.Generic;
using System.Linq;

namespace Services.Business.ResultService
{
    public class ResultService : IResultService
    {
        private IResultRepository resultRepository;

        public ResultService(IResultRepository resultRepository)
        {
            this.resultRepository = resultRepository;
        }


        public Result getResultByDescription(string description)
        {
            return resultRepository.getByDescription(description);
        }

        public bool validateDna(List<Dna> dnas)
        {
            if (dnas == null)
                return false;

            int size = dnas.Count();

            foreach (Dna dna in dnas)
            {
                if (dna.Description.Length > Dna.MaxCharacters || !validateCharacters(dna.Description) || dna.Description.Length != size)
                    return false;
            }

            return true;
        }

     

        public Result generateResult(List<Dna> dnas)
        {
            int sequence = 0, idDna = 0;

            sequence = sequenceRow(dnas) + sequenceColumn(dnas);

            if (sequence >= 4)
                idDna = Result.INMUNE;
            else if (sequence < 2)
                idDna = Result.HELTHY;
            else
                idDna = Result.INFECTED;

            return resultRepository.getByID(idDna);
        }

        private int sequenceRow(List<Dna> dnas)
        {
            int sequence = 0;

            foreach (Dna dna in dnas)
            {

                if (countCounsecutive(dna.Description) == 4)
                    sequence++;

                if (sequence == 4)
                    break;

            }

            return sequence;
        }

        private int sequenceColumn(List<Dna> dnas)
        {
            int totalDnas = dnas.Count;
            int j = 0;
            string concatenate = "";
            List<Dna> newDnas = new List<Dna>();

            for (int i = 0; i < totalDnas; i++)
            {
                concatenate += dnas[i].Description.Substring(j, 1);

                if (i == totalDnas - 1)
                {
                    newDnas.Add(new Dna(concatenate));
                    concatenate = "";
                    if (j == totalDnas - 1)
                        break;

                    i = -1;
                    j++;
                }

            }

            return sequenceRow(newDnas);
        }


        private int countCounsecutive(string description)
        {
            char[] des = description.ToArray();
            char? prev = null;

            int auxRepeat = 0;
            int repeat = 0;

            foreach (char act in des)
            {
                if (prev != null && prev == act)
                    auxRepeat++;
                else
                {
                    if (auxRepeat > repeat)
                        repeat = auxRepeat;

                    auxRepeat = 0;
                }

                prev = act;

            }


            if (auxRepeat > repeat)
                repeat = auxRepeat;

            return repeat + 1;
        }


        private bool validateCharacters(string description)
        {
            int count = 0;

            for (int i = 0; i < Dna.Characters.Count(); i++)
                count += description.ToArray().Where(x => x.Equals(Dna.Characters[i])).Count();

            return count == Dna.MaxCharacters;
        }



    }
}
