using Model.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.MasterModel
{
    public class Dna:Generic
    {
        public Dna() { }
        public Dna(string desctiption) 
        {
            this.Description = desctiption;
        }

        public Dna(int id, string desctiption)
        {
            this.Id = id;
            this.Description = desctiption;
        }
    }
}
