using Model.Generics;
using Services.DTO_s.GenericDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Assembler.GenericAssembler
{
    public interface IGenericAssembler<T1, T2> where T1 : Generic where T2 : GenericDTO
    {
        T2 dtoAssembler(T1 entity);
        IList<T2> listDtoAssembler(IList<T1> listEntity);
        T1 entityAssembler(T2 dto);
        IList<T1> listentiTyAssembler(IList<T2> listDto);
    }
}
