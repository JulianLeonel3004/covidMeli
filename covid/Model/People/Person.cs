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
        public string IdCountry { get; set; }
        public string IdResult { get; set; }
        public string IdDna { get; set; }
        public Country Country { get; set; }
        public Result Result { get; set; }
        public List<Dna> Dna { get; set; }

    }
}
