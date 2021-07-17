using AutoMapper;
using Model.Generics;
using Services.DTO_s.GenericDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Services.Assembler.GenericAssembler
{
    public class GenericAssembler<T1, T2> : IGenericAssembler<T1, T2> where T1 : Generic where T2 : GenericDTO, new()
    {

        public virtual T2 dtoAssembler(T1 entity)
        {
            T2 dto = new T2();

            dto.Id = entity.Id;
            dto.Description = entity.Description;

            return dto;
        }

        public virtual IList<T2> listDtoAssembler(IList<T1> listEntity)
        {
            List<T2> listDto = new List<T2>();

            foreach(T1 value in listEntity)
            {
                listDto.Add(dtoAssembler(value));
            }

            return listDto;
        }

    }
}
