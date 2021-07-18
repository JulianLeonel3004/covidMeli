using Model.MasterModel;
using Services.DTO_s.GenericDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO_s
{
    public class PersonDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string> Dna { get; set; }
        public string Result { get; set; }
    }
}
