using Model.MasterModel;
using Services.Assembler.GenericAssembler;
using Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Assembler.ResultAssembler
{
    public interface IResultAssembler:IGenericAssembler<Result,ResultDTO>
    {
    }
}
