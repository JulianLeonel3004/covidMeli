﻿using Model.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.MasterModel
{
    public class Dna:Generic
    {
        public static char[] DNAC = { 'A', 'T', 'C', 'G' };
        public Dna() { }
        public Dna(string desctiption) 
        {
            this.Description = desctiption;
        }
    }
}
