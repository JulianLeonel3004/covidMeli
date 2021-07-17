using Services.DTO_s.GenericDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO_s
{
    public class PersonDTO: GenericDTO
    {
        public CountryDTO Country { get; set; }
        public ResultDTO Result { get; set; }
        public List<DnaDTO> DnaDT { get; set; }
    }
}
