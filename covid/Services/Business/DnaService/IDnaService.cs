using Model.MasterModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business.DnaService
{
    public interface IDnaService
    {
        void insertDnas(List<Dna> dnas);
        List<Dna> getDnaByDescriptions(IList<string> dnaDescriptions);
    }
}
