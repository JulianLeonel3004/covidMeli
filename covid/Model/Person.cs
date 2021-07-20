using Model.Generics;
using Model.MasterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.People
{
    public class Person : Generic
    {
        public const int FILTER_TYPE_COUNTRY = 1;
        public const int FILTER_TYPE_RESULT = 2;
        public const int FILTER_TYPE_BOTH = 3;
        public int IdCountry { get; set; }
        public int IdResult { get; set; }
        public Country Country { get; set; }
        public Result Result { get; set; }
        public List<Dna> Dna { get;set; } 

    }
}
