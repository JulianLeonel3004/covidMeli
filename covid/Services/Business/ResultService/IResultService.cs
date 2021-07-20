using Model.MasterModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business.ResultService
{
    public interface IResultService
    {
        Result generateResult(List<Dna> dnas);
        Result getResultByDescription(string description);
    }
}
